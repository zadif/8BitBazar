﻿using System;
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
    public partial class hero : Form
    {
        public hero()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            this.Hide();
            f5.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            this.Hide();
            f6.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            logout l = new logout(this);
            l.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userHistory u = new userHistory();
            u.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            updateProfile u = new updateProfile();
            this.Hide();
            u.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            editListing e2 = new editListing();
            e2.Show();
            this.Hide();
        }
    }
}
