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
    public partial class logout : Form
    {
        public logout(hero h)
        {
            InitializeComponent();

            button4.Click += (sender, e) =>
            {

                userInfo.IsLogin = false;
                userInfo.user = null;
                Form1 f = new Form1();
                this.Hide();
                f.Show();
                h.Hide();
            };
        }
        public logout(adminMenu a)
        {
            InitializeComponent();
            button4.Click += (sender, e) =>
            {
                Form1 f = new Form1();
                this.Hide();
                f.Show();
                a.Hide();
            };
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
