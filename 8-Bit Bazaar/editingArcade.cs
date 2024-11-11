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
    public partial class editingArcade : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("8BitBazar");
        static IMongoCollection<Arcade> collection = db.GetCollection<Arcade>("arcades");

        Arcade a;
        public editingArcade(Arcade arc)
        {
            InitializeComponent();
            a = arc;
            read();
        }

        private void read()
        {
            if (a == null) { MessageBox.Show("Error"); }
            textBox1.Text = a.CName;
            textBox2.Text = a.Model;
            textBox3.Text = a.Price.ToString();
            textBox4.Text = a.Year.ToString();
            textBox5.Text = a.Games;
            textBox6.Text = a.Description;


        }

        public editingArcade()
        {
            InitializeComponent();
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

                double price, year;
                if (!Double.TryParse(textBox3.Text, out price))
                {
                    MessageBox.Show("Enter valid price");
                    return;
                }
                if (price < 0)
                {
                    MessageBox.Show("Enter valid price");
                    return;
                }

                if (!Double.TryParse(textBox4.Text, out year))
                {
                    MessageBox.Show("Enter valid year");
                    return;
                }
                if (year < 1970)
                {
                    MessageBox.Show("Machine is too old");
                    return;
                }
                if (year > DateTime.Now.Year)
                {
                    MessageBox.Show("Futuristic Machine spotted");
                    return;
                }
                var updateDef = Builders<Arcade>.Update.Set("cname", textBox1.Text).Set("model", textBox2.Text).Set("price", textBox3.Text).Set("year", textBox4.Text).Set("games", textBox5.Text).Set("description", textBox6.Text);
                collection.UpdateOne(s => s.Id == a.Id, updateDef);
                MessageBox.Show("Arcade updated");
                this.Hide();
                editListing e22 = new editListing();
                e22.Show();
            }
            catch
            {
                MessageBox.Show("Error");
            }


           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            editListing e22 = new editListing();
            e22.Show();
        }
    }
}
