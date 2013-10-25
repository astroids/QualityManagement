using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abc
{
    public partial class p_Ekle : Form
    {
        private SqlConnection con = new SqlConnection();
        public p_Ekle()
        {
            InitializeComponent();
            con.ConnectionString = "Server=ACER; Database=Personel; Integrated Security=true;";
           // p_grid.Visible = true;
        }

        private void Ekle_Click(object sender, EventArgs e)
        {
            /*
            if (textBox1.Text == "")
            {
                MessageBox.Show("Adını boş geçemezsiniz!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("Soyadını boş geçemezsiniz!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("Telefonu boş geçemezsiniz!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox3.Text.Length > 11 || textBox3.Text.Length < 11)
            {
                MessageBox.Show("Telefon Eksik yada Fazla!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBox4.Text == "")
            {
                MessageBox.Show("E-Maili boş geçemezsiniz!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
            con.Open();

            string quer = "insert into Tbl_Personel values(2,'werwerewr','sdfsdf','12345678901','12345678901','12345678901','12345678901','2','12-Jun-1999','dsfsdf','dagitim','dasda',123,'1','3');";
            SqlDataAdapter adap = new SqlDataAdapter(quer, con);
            con.Close();
            p_List asd = new p_List();
            asd.Show();
            this.Hide();
        }
    }
}
