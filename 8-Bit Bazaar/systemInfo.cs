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
    public partial class systemInfo : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("8BitBazar");
        static IMongoCollection<User> collection = db.GetCollection<User>("users");
        static IMongoCollection<Arcade> arcadeCollection = db.GetCollection<Arcade>("arcades");
        public systemInfo()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            //long totalArcades = arcadeCollection.CountDocuments(_ => true);
            //var filter = Builders<Arcade>.Filter.Eq(a => a.isSold, true);
            //long totalArcadesSold = arcadeCollection.CountDocuments(filter);
            
            
            long totalUsers = collection.CountDocuments(_ => true);
            double totalSales=0;
            long totalArcades = 0;
            long totalArcadesSold =0;
            var arcades = arcadeCollection.Find(_ => true).ToList();
            foreach (var arcade in arcades)
            {
                if (arcade.isSold)
                {
                    totalSales += arcade.Price;
                    totalArcadesSold++;
                }
                totalArcades++;
            }
            double totalProfit = totalSales/20;
               


            Label l = new Label();
            l.Location = new Point(22, 110);
            l.Size = new Size(700, 60);
            l.Text = "Total arcades in the system: " + totalArcades;
            l.Font = new Font("Bahnschrift SemiLight Condensed", 20.75f, FontStyle.Bold);
            l.ForeColor = Color.White;
            Label l2 = new Label();
            l2.Location = new Point(22, 180);

            l2.Size = new Size(700, 60);
            l2.Text = "Total users in the system: " + totalUsers;
            l2.Font = new Font("Bahnschrift SemiLight Condensed", 20.75f, FontStyle.Bold);
            l2.ForeColor = Color.White;
            Label l5 = new Label();
            l5.Location = new Point(22, 250);
            l5.Size = new Size(700, 60);
            l5.Text = "Total machines sold: " + totalArcadesSold;
            l5.Font = new Font("Bahnschrift SemiLight Condensed", 20.75f, FontStyle.Bold);
            l5.ForeColor = Color.White;
            Label l3 = new Label();
            l3.Location = new Point(22, 320);
            l3.Size = new Size(700, 60);
            l3.Text = "Total Sales Summary: $" + totalSales;
            l3.Font = new Font("Bahnschrift SemiLight Condensed", 20.75f, FontStyle.Bold);
            l3.ForeColor = Color.White;
            Label l4 = new Label();
            l4.Location = new Point(22, 390);
            l4.Size = new Size(700, 60);
            l4.Text = "Net Profit made: $" + totalProfit;
            l4.Font = new Font("Bahnschrift SemiLight Condensed", 20.75f, FontStyle.Bold);
            l4.ForeColor = Color.White;

            this.Controls.Add(l);
            this.Controls.Add(l2);
            this.Controls.Add(l3);
            this.Controls.Add(l4);
            this.Controls.Add(l5);


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
