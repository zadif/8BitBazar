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
    public partial class updatePassword : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("8BitBazar");
        static IMongoCollection<User> collection = db.GetCollection<User>("users");
        public updatePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!= userInfo.user.Password)
            {
                MessageBox.Show("Re-enter correct old password");
                return;
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("New Passwords don't match. Re-enter them.");
                return;
            }
            if (textBox2.Text.Length < 5)
            {
                MessageBox.Show("Minimum 5 digit Password is required. Re-enter them.");
                return;
            }
            userInfo.user.Password = textBox2.Text;
            var updateDef = Builders<User>.Update.Set("password", textBox2.Text);
            collection.UpdateOne(s => s.Id == userInfo.user.Id, updateDef);
            MessageBox.Show("Password updated");
            this.Hide();
        }
    }
}
