﻿using MongoDB.Driver;
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
    public partial class Form4 : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("8BitBazar");
        static IMongoCollection<User> collection = db.GetCollection<User>("users");
        public Form4()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;

        }
        public bool flag = true;

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private async void  button2_Click(object sender, EventArgs e)
        {
            try {

                if (string.IsNullOrEmpty(textBox1.Text) ||
               string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Please fill in all fields");
                    return;
                }


                var filter = Builders<User>.Filter
                    .Eq(u => u.Email, textBox1.Text);
                // Asynchronously retrieves the first document that matches the filter
                User user1= await collection.Find(filter).FirstOrDefaultAsync();
                if (user1 != null)
                {
                    if(user1.Password== textBox2.Text)
                    {
                        MessageBox.Show("Login Successfully");
                        userInfo.IsLogin = true;
                        userInfo.user = user1;
                    }
                    else { MessageBox.Show("Enter correct Password"); }
                    
                }
                else {
                    MessageBox.Show("Wrong email");
                }

            } 
            catch {
                MessageBox.Show("Error");
                return;
            }

           if(userInfo.IsLogin == true)
            {
                this.Hide();
                hero her = new hero();
                her.Show();
            }
           
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
            Form3 f = new Form3();
            this.Hide();
            f.Show();
        }
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !flag;
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
