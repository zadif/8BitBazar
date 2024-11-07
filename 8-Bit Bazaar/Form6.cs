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

    public partial class Form6 : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("8BitBazar");
        static IMongoCollection<Arcade> collection = db.GetCollection<Arcade>("arcades");

        public Form6()
        {
            
            InitializeComponent();
            read();

        }
        int count = 1;
        int countt = 1;
        int countl = 1;
        private Panel Adddd(Arcade arc)
        {
            if (count > 3)
            {
                countt ++;
                countl = 1;
                count = 1;
            }
            Panel p=new Panel();
            p.BackColor = Color.White;
            p.Size = new Size(125, 155);
            p.Margin = new Padding(30);
            
            p.Top = countt * 170;
            p.Left = countl*160;
            
            Label title=new Label();
            title.Location = new Point(14, 10);
            title.Text = arc.CName;
            title.Font = new Font("Arial", 15);
            Label title2 = new Label();
            title2.Location = new Point(16, 45);
            
            title2.Text = arc.Model.ToString();
            title2.Font = new Font("Arial", 10);
            Label price = new Label();
            price.Location = new Point(14, 70);
            price.Text = "$"+arc.Price;
            price.Font = new Font("Arial", 15, FontStyle.Bold);
            Button btn = new Button();
            btn.Text = "Buy Me";
            btn.Location = new Point(18, 100);
            btn.AutoSize = true;
            btn.BackColor = Color.DodgerBlue;
            btn.Padding = new Padding(6);
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI Black, MT", 10);
            btn.Anchor = AnchorStyles.None;
            btn.Click += (sender, e) =>
            { //when this button is clicked it's respective forum will be loaded
                buyingArcade a = new buyingArcade(arc);
                this.Hide();
                a.Show();
            };
            count++ ;
            countl++ ;
            p.Controls.Add(title);
            p.Controls.Add(title2);
            p.Controls.Add(price);
            p.Controls.Add(btn);

            this.Controls.Add(p);
            return p;
        }
       public bool read()
        {
            bool flag = false;
            List<Arcade> list = collection.AsQueryable().ToList<Arcade>();
            try
            {
                foreach(var arcade in list)
                { 
                    if(!arcade.isSold && arcade.Seller!=userInfo.user.Id)
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

            if(list.Count == 0 || !flag)
            {
                MessageBox.Show("No Arcade currently for sale");
                return false ;
            }
            return true;
        }

       
        private void button1_Click_1(object sender, EventArgs e)
        {
            hero heroForm = new hero();
            this.Hide();
            heroForm.Show();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
