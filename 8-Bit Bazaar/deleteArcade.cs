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
                editListing e3 = new editListing();
                this.Hide();
                e3.Show();
            };
        }
       
    }
}
