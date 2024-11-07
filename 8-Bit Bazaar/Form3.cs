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
    public partial class Form3 : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("8BitBazar");
        static IMongoCollection<User> collection = db.GetCollection<User>("users");
        public Form3()
        {
            InitializeComponent();
            textBox4.UseSystemPasswordChar = true;
            textBox5.UseSystemPasswordChar = true;

        }
        public bool flag=true;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text) ||
                string.IsNullOrEmpty(textBox5.Text))
                {
                    MessageBox.Show("Please fill in all fields");
                    return;
                }


                string pass = textBox4.Text;
                if (pass.Length < 5)
                {
                    MessageBox.Show("Minimum 5 digit Password is required. Re-enter them.");
                    return;
                }



                if (textBox4.Text != textBox5.Text)
                {
                    MessageBox.Show("Passwords don't match. Re-enter them.");
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
                if (!Double.TryParse(textBox3.Text,out phone)) {
                    MessageBox.Show("Enter valid Phone number");
                    return;
                }
               
                if(phone.ToString().Length>11)
                {
                    MessageBox.Show("Enter valid Phone number");
                    return;
                }

                User u = new User(textBox1.Text, textBox4.Text, Double.Parse(textBox3.Text), radioInput, textBox2.Text);
                collection.InsertOne(u);

                textBox1.Text += "!";
                string str = "Welcome ";
                str += textBox1.Text;
                MessageBox.Show(str);

                MessageBox.Show("Now, you can login");
                this.Hide();
                Form1 form1 = new Form1();
                form1.Show();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                textBox4.UseSystemPasswordChar = !flag;
                textBox5.UseSystemPasswordChar = !flag;
                flag = !flag;
            if (flag)
            {
                button1.Text = "Show";
            }
            else
            {
                button1.Text = "Hide";
            }
            
        }

        
    }
}
