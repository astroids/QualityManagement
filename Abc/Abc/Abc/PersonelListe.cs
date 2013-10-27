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
    public partial class PersonelListe : Form
    {
        private SqlConnection con = new SqlConnection();
        public PersonelListe()
        {
            InitializeComponent();
            p_grid.Visible = true;
            con.ConnectionString = "Server=NAGASH; Database=Personel; Integrated Security=true;";
            listele(null);

        }
        private void listele(string ser){

            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            if (ser == null)
            {
                 cmd.CommandText = "Select * From Tbl_Personel";
            }
            else
            {
                 cmd.CommandText = "Select * From Tbl_Personel p Where p.P_Adi like @Title";
                 cmd.Parameters.AddWithValue("@Title", ser);
            }
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            p_grid.DataSource = null;
            p_grid.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
            
                        
            
        }

        private void p_Ekle_Click(object sender, EventArgs e)
        {
            PersonelEkle asd= new PersonelEkle(1,0);
            asd.Show();
            this.Hide();
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonelEkle asd = new PersonelEkle(1, 0);
            asd.Show();
          //  this.Hide();
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



        private void p_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         //   InitializeComponent();
            listele(textBox1.Text);

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void PersonelListe_Load(object sender, EventArgs e)
        {

        }


    }
}
