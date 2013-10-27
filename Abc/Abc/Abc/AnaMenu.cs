using System;
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
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Dokuman frm3 = new Dokuman();
            frm3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dof frm4 = new Dof();
            frm4.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IcDenetim frm5 = new IcDenetim();
            frm5.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bakim frm6 = new Bakim();
            frm6.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Personel frm8 = new Personel();
            frm8.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Toplanti frm10 = new Toplanti();
            frm10.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Araclar frm11 = new Araclar();
            frm11.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Yonetim frm12 = new Yonetim();
            frm12.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinizden Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

    }
}
