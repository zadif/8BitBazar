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
using static MongoDB.Driver.WriteConcern;

namespace _8_Bit_Bazaar
{
    public partial class transactions : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("8BitBazar");
        static IMongoCollection<User> collection = db.GetCollection<User>("users");
        static IMongoCollection<Arcade> arcadeCollection = db.GetCollection<Arcade>("arcades");
        public transactions()
        {
            InitializeComponent();
            read();
        }
      
        int count = 1;
        int countt = 1;
        int countl = 1;
        public Panel Adddd(Arcade arc)
        {

            string machineName = arc.CName +" "+arc.Model +" sold by ";
            User owner=collection.Find(a => a.Id==arc.Seller).FirstOrDefault();
            User buyer = collection.Find(a => a.Id == arc.Buyer).FirstOrDefault();
            string ownerName = owner.Username+ " to ";
            string buyerName = buyer.Username + " for $";

            if (count > 3)
            {
                countt++;
                countl = 1;
                count = 1;
            }
           
            Panel p = new Panel();
            p.BackColor = Color.White;
            p.Size = new Size(145, 170);
            p.Margin = new Padding(30);

            p.Top = countt * 170;
            p.Left = countl * 160;

            Label title = new Label();
            title.Location = new Point(14, 10);
            title.Size = new Size(130, 170);
            title.Text = machineName+ownerName+buyerName+arc.Price;
            title.Font = new Font("Arial", 15);
            
            
            count++;
            countl++;
            p.Controls.Add(title);
            

            this.Controls.Add(p);
            return p;
        }
        public bool read()
        {
            bool flag = false;
            List<Arcade> list = arcadeCollection.AsQueryable().ToList<Arcade>();
            try
            {
                foreach (var arcade in list)
                {
                    if (arcade.isSold )
                    {
                        Adddd(arcade);
                        flag = true;
                    }

                }
            }
            catch
            {
                MessageBox.Show("Error jnab Error");
            }

            if (list.Count == 0 || !flag)
            {
                MessageBox.Show("No Arcade currently sold");
                return false;
            }
            return true;
        }

    }
}
