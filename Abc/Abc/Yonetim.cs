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
    public partial class Yonetim : Form
    {
        public Yonetim()
        {
            InitializeComponent();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinizden Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            AnaMenu frm2 = new AnaMenu();
            frm2.Show();
            this.Hide();
        }    
    }
}
