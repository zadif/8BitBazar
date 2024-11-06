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
            title.Location = new Point(12, 10);
            title.Text = arc.CName;
            title.Font = new Font("Arial", 15);
            Label title2 = new Label();
            title2.Location = new Point(12, 35);
            title2.Text = arc.Model;
            title2.Font = new Font("Arial", 15);
            Label price = new Label();
            price.Location = new Point(12, 70);
            price.Text = "$"+arc.Price;
            price.Font = new Font("Arial", 17, FontStyle.Bold);
            Button btn = new Button();
            btn.Text = "Buy Me";
            btn.Location = new Point(12, 100);
            btn.AutoSize = true;
            btn.BackColor = Color.White;
            btn.Padding = new Padding(6);
            btn.Font = new Font("Segoe UI Black, MT", 10);
            //btn.Location = new Point((p.Width - btn.Width) / 2);
            btn.Anchor = AnchorStyles.None;
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
            btn.Text = "Buy34";
            btn.Location = new Point(this.ClientSize.Width - btn.Width - 12, this.ClientSize.Height - btn.Height - 12);
            btn.AutoSize = true;
            btn.BackColor = Color.White;
            btn.Padding = new Padding(6);
            btn.Font = new Font("Segoe UI Black, MT", 10);
            btn.Anchor = AnchorStyles.None;
            this.Scroll += (sender, e) => { btn.Location = new Point(this.ClientSize.Width - btn.Width - 20, this.ClientSize.Height - btn.Height - 20); };
         
            btn.Click += new EventHandler(this.Btn_Click);
            this.Controls.Add(btn);
        }

        private void Btn_Click(object sender, EventArgs e){ 
            hero heroForm = new hero(); 
            heroForm.Show();
        }
            private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
