using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_Bit_Bazaar
{
    public partial class updateProfile : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("8BitBazar");
        static IMongoCollection<User> collection = db.GetCollection<User>("users");
        public updateProfile()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
           
            textBox1.Font = new Font("Bahnschrift SemiLight Condensed", 20.75f, FontStyle.Bold);
            textBox2.Font = new Font("Bahnschrift SemiLight Condensed", 20.75f, FontStyle.Bold);
            textBox3.Font = new Font("Bahnschrift SemiLight Condensed", 20.75f, FontStyle.Bold);

            textBox1.Text = userInfo.user.Username;
            textBox2.Text = userInfo.user.Email;
            textBox3.Text = userInfo.user.Number.ToString();
            string gender = userInfo.user.Gender;
            if (gender == "Female")
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text)) 
                {
                    MessageBox.Show("Please fill in all fields");
                    return;
                }


                string radioInput = "";
                if (radioButton1.Checked)
                {
                    radioInput = radioButton1.Text;
                }
                else
                {
                    radioInput = radioButton2.Text;
                }

                double phone;
                if (!Double.TryParse(textBox3.Text, out phone))
                {
                    MessageBox.Show("Enter valid Phone number");
                    return;
                }

                if (phone.ToString().Length > 11)
                {
                    MessageBox.Show("Enter valid Phone number");
                    return;
                }

                var updateDef = Builders<User>.Update.Set("username", textBox1.Text).Set("email", textBox3.Text).Set("number", textBox3.Text).Set("gender", radioInput);
                collection.UpdateOne(s => s.Id == userInfo.user.Id, updateDef);
                MessageBox.Show("Profile updated");
                userInfo.user.Username = textBox1.Text;
                userInfo.user.Email=textBox2.Text;
                userInfo.user.Number = phone;
                userInfo.user.Gender = radioInput;
                this.Hide();
                hero h = new hero();
                h.Show();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updatePassword u = new updatePassword();
            u.Show();

        }
    }
}
