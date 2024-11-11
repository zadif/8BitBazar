using CuoreUI;
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
    public partial class editListing : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("8BitBazar");
        static IMongoCollection<Arcade> collection = db.GetCollection<Arcade>("arcades");
        public editListing()
        {
            InitializeComponent();
            read();
        }
        int count = 1;
        int countt = 1;
        int countl = 1;
        public bool read()
        {
            bool flag = false;
            List<Arcade> list = collection.AsQueryable().ToList<Arcade>();
            try
            {
                foreach (var arcade in userInfo.user.Sell)
                {
                Arcade arc = collection.Find(x => x.Id.ToString() == arcade).FirstOrDefault();
                    if (!arc.isSold)
                    {
                    Adddd(arc);
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
                MessageBox.Show("You dont have an arcade for selling");
                return false;
            }
            return true;
        }
        public Panel Adddd(Arcade arc)
        {
            if (count > 3)
            {
                countt++;
                countl = 1;
                count = 1;
            }
            Panel p = new Panel();
            p.BackColor = Color.White;
            p.Size = new Size(125, 205);
            p.Margin = new Padding(30);

            p.Top = countt * 170;
            p.Left = countl * 160;

            Label title = new Label();
            title.Location = new Point(14, 10);
            title.Text = arc.CName;
            title.Font = new Font("Arial", 15);
            Label title2 = new Label();
            title2.Location = new Point(16, 45);

            title2.Text = arc.Model.ToString();
            title2.Font = new Font("Arial", 10);
            Label price = new Label();
            price.Location = new Point(14, 70);
            price.Text = "$" + arc.Price;
            price.Font = new Font("Arial", 15, FontStyle.Bold);
            Button btn = new Button();
            btn.Text = "Edit Me";
            btn.Location = new Point(18, 100);
            btn.AutoSize = true;
            btn.BackColor = Color.DodgerBlue;
            btn.Padding = new Padding(6);
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI Black, MT", 10);
            btn.Anchor = AnchorStyles.None;
            btn.Click += (sender, e) =>
            { //when this button is clicked it's respective forum will be loaded
                editingArcade a = new editingArcade(arc);
                this.Hide();
                a.Show();
            };
            Button btn2 = new Button();
            btn2.AutoSize = true;
            btn2.Text = "Delete";
            btn2.Location = new Point(18, 150);
            btn2.BackColor = Color.Red;
            btn2.Padding = new Padding(10);
            btn2.FlatStyle = FlatStyle.Flat;
            btn2.Font = new Font("Segoe UI Black, MT", 10);
            btn2.Anchor = AnchorStyles.None;
            btn2.Click += (sender, e) =>
            { 
               deleteArcade a = new deleteArcade(arc);
                this.Hide();
                a.Show();
            };
            count++;
            countl++;
            p.Controls.Add(title);
            p.Controls.Add(title2);
            p.Controls.Add(price);
            p.Controls.Add(btn);
            p.Controls.Add(btn2);

            this.Controls.Add(p);
            return p;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            hero heroForm = new hero();
            this.Hide();
            heroForm.Show();
        }
    }
}
