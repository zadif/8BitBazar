using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace _8_Bit_Bazaar
{
    public partial class Form5 : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("8BitBazar");
        static IMongoCollection<Arcade> collection = db.GetCollection<Arcade>("arcades");
        static IMongoCollection<User> usercollection = db.GetCollection<User>("users");
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text) ||
                string.IsNullOrEmpty(textBox6.Text) ||
                string.IsNullOrEmpty(textBox5.Text))
                {
                    MessageBox.Show("Please fill in all fields");
                    return;
                }

                double price,year;
                if (!Double.TryParse(textBox3.Text, out price) )
                {
                    MessageBox.Show("Enter valid price");
                    return;
                }
                if(price<0)
                {
                    MessageBox.Show("Enter valid price");
                    return;
                }

                if (!Double.TryParse(textBox4.Text, out year))
                {
                    MessageBox.Show("Enter valid year");
                    return;
                }
                if(year<1970)
                {
                    MessageBox.Show("Machine is too old");
                    return;
                }
                if (year > DateTime.Now.Year)
                {
                    MessageBox.Show("Futuristic Machine spotted");
                    return;
                }

                Arcade a = new Arcade(textBox1.Text, textBox2.Text, Double.Parse(textBox3.Text), Double.Parse(textBox4.Text), textBox5.Text, textBox6.Text, userInfo.user.Id.ToString());
                collection.InsertOne(a);
                User u = userInfo.user;
                userInfo.user.Sell.Add(a.Id.ToString());

                var filter = Builders<User>.Filter.Eq(u1 => u1.Id, userInfo.user.Id);
                var update = Builders<User>.Update.Set(u1 => u1.Sell, userInfo.user.Sell);

                usercollection.UpdateOne(filter, update);

                hero f1 = new hero();
                this.Hide();
                f1.Show();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
