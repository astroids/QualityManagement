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
    public partial class p_List : Form
    {

        private SqlConnection con = new SqlConnection();
        public p_List()
        {
            InitializeComponent();
            con.ConnectionString = "Server=ACER; Database=Personel; Integrated Security=true;";
            p_grid.Visible = true;


            con.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select * from Tbl_Personel ", con);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            p_grid.DataSource = dt;
            con.Close();

        }

        private void p_Ekle_Click(object sender, EventArgs e)
        {
            p_Ekle asd= new p_Ekle(1,0);
            asd.Show();
            this.Hide();
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p_Ekle asd = new p_Ekle(1, 0);
            asd.Show();
            this.Hide();
        }

        private void p_Duzen_Click(object sender, EventArgs e)
        {

        }

        private void onaylanmamişIzinlerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ızinIsteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ızinOnaylaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


    }
}
