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
    public partial class Form4 : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("8BitBazar");
        static IMongoCollection<User> collection = db.GetCollection<User>("users");
        public Form4()
        {
            InitializeComponent();
        }

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


                // Creates a filter for all documents that have a "name" value of "Bagels N Buns"
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
    }
}
