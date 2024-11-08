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
    public partial class userHistory : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("8BitBazar");
        static IMongoCollection<User> collection = db.GetCollection<User>("users");
        static IMongoCollection<Arcade> arcadeCollection = db.GetCollection<Arcade>("arcades");

        public userHistory()
        {
            InitializeComponent();
           
            load();
        }

        
        private void load()
        {
            int totalArcades = userInfo.user.Sell.Count;
            int totalArcadesSold = 0;
            double totalProfit = 0;
            int totalArcadesBought = userInfo.user.Buy.Count;
            foreach (var arcade in userInfo.user.Sell)
            {
            Arcade arc = arcadeCollection.Find(x => x.Id.ToString() == arcade).FirstOrDefault();
                if (arc.isSold == true)
                {
                    totalArcadesSold++;
                    totalProfit += arc.Price;
                }

            }
           

            Label l = new Label();
            l.Location = new Point(22, 110);
            l.Size = new Size(700, 60);
            l.Text = "Total arcades owned: "+totalArcades;
            l.Font = new Font("Bahnschrift SemiLight Condensed", 20.75f, FontStyle.Bold);
            l.ForeColor = Color.White;
            Label l2 = new Label();
            l2.Location = new Point(22, 180);
            l2.Size =new Size(700, 60);
            l2.Text = "Total arcades sold: "+ totalArcadesSold;
            l2.Font = new Font("Bahnschrift SemiLight Condensed", 20.75f, FontStyle.Bold);
            l2.ForeColor = Color.White;
            Label l5 = new Label();
            l5.Location = new Point(22, 250);
            l5.Size = new Size(700, 60);
            l5.Text = "Total arcades Bought: " + totalArcadesBought;
            l5.Font = new Font("Bahnschrift SemiLight Condensed", 20.75f, FontStyle.Bold);
            l5.ForeColor = Color.White;
            Label l3 = new Label();
            l3.Location = new Point(22, 320);
            l3.Size = new Size(700, 60);
            l3.Text = "Total profit earned: $"+ totalProfit;
            l3.Font = new Font("Bahnschrift SemiLight Condensed", 20.75f, FontStyle.Bold);
            l3.ForeColor = Color.White;
            Label l4 = new Label();
            l4.Location = new Point(22, 390);
            l4.Size = new Size(700, 60);
            l4.Text = "Average rating: "+ Math.Round(userInfo.user.Rating, 2);
            l4.Font = new Font("Bahnschrift SemiLight Condensed", 20.75f, FontStyle.Bold);
            l4.ForeColor = Color.White;

            this.Controls.Add(l);
            this.Controls.Add(l2);
            this.Controls.Add(l3);
            this.Controls.Add(l4);
            this.Controls.Add(l5);


        }

        private void userHistory_Load(object sender, EventArgs e)
        {

        }
    }
}
