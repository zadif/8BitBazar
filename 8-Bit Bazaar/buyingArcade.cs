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
    public partial class buyingArcade : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("8BitBazar");
        static IMongoCollection<User> users=db.GetCollection<User>("users");
        static IMongoCollection<Arcade> collection = db.GetCollection<Arcade>("arcades");
        public buyingArcade(Arcade a)
        {
            InitializeComponent();
            showInfo(a);

            button2.Click += (sender, e) =>
            { //when this button is clicked it's respective forum will be loaded
                rateArcade a1 = new rateArcade( a);
                a1.Show();
                this.Hide();
            };
            button1.Click += (sender, e) =>
            {
                Form6 f = new Form6();
                this.Hide();
                f.Show();
            };
        }
        public buyingArcade()
        {
            InitializeComponent();
           
        }
        public buyingArcade(Arcade a,bool x)
        {//when admin wants to view the forum

            InitializeComponent();
            label1.Text = "View an Arcade";
            showInfo(a);

            button1.Click += (sender, e) =>
            {
                viewArcadesAdmin n = new viewArcadesAdmin();
                n.Show();
                this.Hide();
            };
            button2.Hide();
        }
        private void showInfo(Arcade a)
        {
            if (a == null) { MessageBox.Show("Error"); }
            textBox1.Text = a.CName;
            textBox2.Text=a.Model    ;
            textBox3.Text=a.Price.ToString()    ;
            textBox4.Text=a.Year.ToString()   ;
            textBox5.Text=a.Games    ;
            textBox6.Text = a.Description    ;

           

            User seller = users.Find(x => x.Id == a.Seller).FirstOrDefault();
            string sellerName = seller.Username;
            
            Label l = new Label();
            l.Location = new Point(14, 631);
            l.Size =new Size (700, 70);
            l.Text = "Seller: " + sellerName;
            l.Font = new Font("Segoe UI Semibold", 14.75f, FontStyle.Bold); 
            l.ForeColor = Color.White;
            this.Controls.Add(l);

        }
        
    }
}
