﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abc
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          /*  if ((textBox1.Text == "Beşiktaş") && (textBox2.Text == "1903"))
            {
                Form2 frm2 = new Form2();
                frm2.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı !");
            }
           */
            AnaMenu frm2 = new AnaMenu();
            frm2.Show();
            this.Hide();
        }
    }
}
