using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_Bit_Bazaar
{
    public partial class rateArcade : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("8BitBazar");
        static IMongoCollection<Arcade> collection = db.GetCollection<Arcade>("arcades");
        static IMongoCollection<User> usercollection = db.GetCollection<User>("users");
        public rateArcade(Arcade a)
        {
            InitializeComponent();
            button2.Click += (sender, e) =>
            {

                this.Hide();
                MessageBox.Show("Arcade Successfully purchased");

                Updater(a);

                Form6 f = new Form6();
                this.Hide();
                f.Show();
            };

        }

        private void Updater(Arcade a)
        {
            //1->Seller
            var updateDef = Builders<User>.Update.Set("rating", cuiSlider1.Value / 10);
            usercollection.UpdateOne(s => s.Id == a.Seller, updateDef);
            //2->Machine 
            var updateDef2 = Builders<Arcade>.Update.Set("isSold", true).Set("buyer", userInfo.user.Id);
            collection.UpdateOne(s => s.Id == a.Id, updateDef2);
            //3->Buyer
            var updateDef3 = Builders<User>.Update.Set(u1 => u1.Buy, userInfo.user.Buy);
            userInfo.user.Buy.Add(a.Id.ToString());
            usercollection.UpdateOne(s => s.Id == userInfo.user.Id, updateDef3);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
