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
            
            p.Top = countt * 160;
            p.Left = countl*140;
            
            Label title=new Label();
            title.Location = new Point(12, 10);
            title.Text = arc.CName;
            Label title2 = new Label();
            title2.Location = new Point(12, 35);
            title2.Text = arc.Model;

            Label price = new Label();
            price.Location = new Point(12, 70);
            price.Text = "$"+arc.Price;

            Button btn = new Button();
            btn.Text = "Buy Me";
            btn.Location = new Point(12, 100);

            
            count++ ;
            countl++ ;
            p.Controls.Add(title);
            p.Controls.Add(price);
            p.Controls.Add(btn);

            this.Controls.Add(p);
            return p;
        }
       public void read()
        {
            List<Arcade> list = collection.AsQueryable().ToList<Arcade>();
            try
            {
                foreach(var arcade in list)
                {
                    Adddd(arcade);
                }
            }
            catch
            {
                MessageBox.Show("Error jnab Error");
            }

            Button btn = new Button();
            btn.Text = "Go Back";
            btn.Margin = new Padding(20);
            btn.Name = "goback";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
