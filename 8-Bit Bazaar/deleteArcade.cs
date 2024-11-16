using MongoDB.Bson;
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
    public partial class deleteArcade : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("8BitBazar");
        static IMongoCollection<Arcade> arcadecollection = db.GetCollection<Arcade>("arcades");
        static IMongoCollection<User> collection = db.GetCollection<User>("users");
        public deleteArcade()
        {
            InitializeComponent();

        }
        public deleteArcade(Arcade arc)
        {
            InitializeComponent();
            button4.Click += (sender, e) =>
            {
                arcadecollection.DeleteOne(s => s.Id == arc.Id);
                MessageBox.Show("Arcade deleted");

                
                userInfo.user.Sell.Remove(arc.Id.ToString());

                var filter = Builders<User>.Filter.Eq(u1 => u1.Id, userInfo.user.Id);
                var update = Builders<User>.Update.Set(u1 => u1.Sell, userInfo.user.Sell);

                collection.UpdateOne(filter, update);

                editListing e3 = new editListing();
                this.Hide();
                e3.Show();
            };
        }

    }
}
