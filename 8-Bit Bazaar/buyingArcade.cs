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
        }
        public buyingArcade()
        {
            InitializeComponent();
           
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
        private void buyingArcade_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { 
            Form6 f = new Form6();
            this.Hide();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           
        }
    }
}
