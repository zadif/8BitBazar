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
        static IMongoCollection<Arcade> collection = db.GetCollection<Arcade>("arcades");
        static IMongoCollection<User> usercollection = db.GetCollection<User>("users");

        public deleteArcade()
        {
            InitializeComponent();
            
        }
        public deleteArcade(Arcade arc)
        {
            InitializeComponent();
            button4.Click += (sender, e) =>
            {
                collection.DeleteOne(s => s.Id == arc.Id);
                MessageBox.Show("Arcade deleted");
                
                userInfo.user.Sell.Remove(arc.Id.ToString());

                var filter = Builders<User>.Filter.Eq(u1 => u1.Id, userInfo.user.Id);
                var update = Builders<User>.Update.Set(u1 => u1.Sell, userInfo.user.Sell);

                usercollection.UpdateOne(filter, update);

                editListing e3 = new editListing();
                this.Hide();
                e3.Show();
            };
        }
        public deleteArcade(Arcade arc ,bool x)
        {
            InitializeComponent();
            button4.Click += (sender, e) =>
            {
                User owner = usercollection.Find(a => a.Id == arc.Seller).FirstOrDefault();

                collection.DeleteOne(s => s.Id == arc.Id);
                MessageBox.Show("Arcade deleted");

                owner.Sell.Remove(arc.Id.ToString());

                var filter = Builders<User>.Filter.Eq(u1 => u1.Id, owner.Id);
                var update = Builders<User>.Update.Set(u1 => u1.Sell, owner.Sell);

                usercollection.UpdateOne(filter, update);

                viewArcadesAdmin e3 = new viewArcadesAdmin();
                this.Hide();
                e3.Show();
            };
        }
        public deleteArcade(User usr)
        {
            List<Arcade> list = collection.AsQueryable().ToList<Arcade>();

            InitializeComponent();
            button4.Click += (sender, e) =>
            {

                foreach(var arcade in usr.Sell)
                {
                    Arcade arc = collection.Find(a => a.Id.ToString() == arcade).FirstOrDefault();
                    if(!arc.isSold){
                collection.DeleteOne(s => s.Id == arc.Id);
                    }
                }
                foreach (var arcade in usr.Buy)
                {
                    Arcade arc = collection.Find(a => a.Id.ToString() == arcade).FirstOrDefault();
                    
                   collection.DeleteOne(s => s.Id == arc.Id);
                    
                }
                usercollection.DeleteOne(s => s.Id == usr.Id);
                MessageBox.Show("User deleted");

                viewUsers e3 = new viewUsers();
                this.Hide();
                e3.Show();
            };
        }
    }
}
