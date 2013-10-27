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
    public partial class PersonelEkle : Form
    {
        private SqlConnection con = new SqlConnection();
        public PersonelEkle(int tip, int sid)
        {
            InitializeComponent();
            con.ConnectionString = "Server=NAGASH; Database=Personel; Integrated Security=true;";
            if (tip == 2)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Personel where P_id = @id";
		       
                cmd.Parameters.AddWithValue("@id", sid);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    p_isim.Text = reader["P_Adi"].ToString();
                }
                
                con.Close();
            }
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

            string quer = "insert into Tbl_Personel values(@p_isim,@p_soyisim,@p_tc,@p_tel1,@p_tel2,@p_email,@comboBox1,@dateTimePicker1,@p_dogyer,@comboBox2,@comboBox3,5,@comboBox4); ";
            
            
            SqlCommand cmd = new SqlCommand(quer, con);
            cmd.CommandText=quer;
            cmd.Parameters.Add("@p_isim", SqlDbType.VarChar, 20).Value = p_isim.Text;
            cmd.Parameters.Add("@p_soyisim", SqlDbType.VarChar, 20).Value = p_soyisim.Text;
            cmd.Parameters.Add("@p_tc", SqlDbType.VarChar, 11).Value = p_tc.Text;
            cmd.Parameters.Add("@p_tel1", SqlDbType.VarChar, 11).Value = p_tel1.Text;
            cmd.Parameters.Add("@p_tel2", SqlDbType.VarChar, 11).Value = p_tel2.Text;
            cmd.Parameters.Add("@p_email", SqlDbType.VarChar, 20).Value = p_email.Text;
            cmd.Parameters.Add("@comboBox1", SqlDbType.Bit).Value = comboBox1.SelectedItem;
            cmd.Parameters.Add("@dateTimePicker1", SqlDbType.Date).Value = dateTimePicker1.Text;
            cmd.Parameters.Add("@p_dogyer", SqlDbType.VarChar, 25).Value = p_dogyer.Text;
            cmd.Parameters.Add("@comboBox2", SqlDbType.VarChar, 20).Value = comboBox2.SelectedItem;
            cmd.Parameters.Add("@comboBox3", SqlDbType.VarChar, 20).Value = comboBox3.SelectedItem;
            cmd.Parameters.Add("@comboBox4", SqlDbType.VarChar, 20).Value = comboBox4.SelectedItem;


            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            con.Close();
            PersonelListe asd = new PersonelListe();
            asd.Show();
            this.Hide();
        }

        private void PersonelEkle_Load(object sender, EventArgs e)
        {

        }

    }
}
