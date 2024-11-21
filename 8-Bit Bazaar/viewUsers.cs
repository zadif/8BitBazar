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
    public partial class viewUsers : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("8BitBazar");
        static IMongoCollection<User> collection = db.GetCollection<User>("users");
        static IMongoCollection<Arcade> arcadeCollection = db.GetCollection<Arcade>("arcades");
        public viewUsers()
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
            List<User> list = collection.AsQueryable().ToList<User>();
            try
            {
                foreach (var user in list)
                {
                    Adddd(user);
                    flag = true;

                }
            }
            catch
            {
                MessageBox.Show("Error jnab Error");
            }

            if (list.Count == 0 || !flag)
            {
                MessageBox.Show("No user present in the system");
                return false;
            }
            return true;
        }
        public Panel Adddd(User arc)
        {

            if (count > 3)
            {
                countt++;
                countl = 1;
                count = 1;
            }
            Panel p = new Panel();
            p.BackColor = Color.White;
            p.Size = new Size(125, 235);
            p.Margin = new Padding(30);

            p.Top = countt * 200;
            p.Left = countl * 160;

            Label title = new Label();
            title.Location = new Point(14, 10);
            title.Text = arc.Username;
            title.Font = new Font("Arial", 15);
            Label title2 = new Label();
            title2.Location = new Point(16, 45);
            title2.Text = arc.Gender;
            title2.Font = new Font("Arial", 10);
            Label price = new Label();
            price.Location = new Point(14, 70);
            price.Text = "Rating: "+arc.Rating;
            price.Font = new Font("Arial", 15, FontStyle.Bold);
            Label sold = new Label();
            sold.Location = new Point(14, 100);
            sold.Text = "Arcades owned: " + arc.Sell.Count;
            sold.Font = new Font("Arial", 15, FontStyle.Bold);
            Label buy = new Label();
            buy.Location = new Point(14, 150);
            buy.Text = "Arcades bought: " + arc.Buy.Count;
            buy.Font = new Font("Arial", 15, FontStyle.Bold);
            Button btn2 = new Button();
            btn2.AutoSize = true;
            btn2.Text = "Delete";
            btn2.Location = new Point(18, 220);
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
            p.Controls.Add(sold);
            p.Controls.Add(buy);
            p.Controls.Add(btn2);

            this.Controls.Add(p);
            return p;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminMenu m = new adminMenu();
            m.Show();
            this.Hide();
        }
    }
}
