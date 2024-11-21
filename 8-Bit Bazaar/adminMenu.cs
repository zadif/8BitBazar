using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Util;
using System.Windows.Forms;

namespace _8_Bit_Bazaar
{
    public partial class adminMenu : Form
    {
        public adminMenu()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            logout l = new logout(this);
            l.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            systemInfo i = new systemInfo();
            i.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            transactions t = new transactions();
            t.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewArcadesAdmin n = new viewArcadesAdmin();
            n.Show();
            this.Hide();
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            viewUsers v = new viewUsers();
            v.Show();
            this.Hide();
        }
    }
}
