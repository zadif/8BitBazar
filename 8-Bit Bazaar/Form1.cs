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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
        }

       

        private void label1_Click(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2();
            form2.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            this.Hide();
            form4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
