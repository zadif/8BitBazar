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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if((textBox1.Text=="zadif" || textBox1.Text == "Zadif" || textBox1.Text == "ZADIF") && textBox2.Text == "123")
            {
                MessageBox.Show("Loged in as admin");
                adminMenu a = new adminMenu();
                a.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong credentials");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
