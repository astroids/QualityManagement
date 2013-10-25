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
            con.ConnectionString = "Server=NAGASH; Database=Personel; Integrated Security=true;";
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

            SqlDataAdapter adap = new SqlDataAdapter("insert into Personel values(3232,'mali vveli','55555555555','6666666666','2222222222','fsdf@gasd.com','E','isci','dagidim',10001,0);", con);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            con.Close();
            this.Hide();
            p_List temp = new p_List();
            temp.Show();
        }
    }
}
