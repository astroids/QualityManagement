using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Egitim_Rapor.xaml
    /// </summary>
    public partial class Egitim_Rapor : MetroWindow
    {

       
        private SqlConnection con = new SqlConnection();
        private int selected_egitim;


        public Egitim_Rapor(int sid)
        {
            selected_egitim = sid;
            InitializeComponent();
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = "Server=Mustafa-HP; Database=Personel; Integrated Security=true;";

            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Egitim e,Tbl_Personel p where e.E_id =@id and p.P_id = e.E_Egi_Veren";
                cmd.Parameters.AddWithValue("@id", sid);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    baslik.Text = reader["E_Adi"].ToString();
                    icerik.Text = reader["E_Icerik"].ToString();
                    baslan.Text = reader["E_BasTarih"].ToString();
                    bitis.Text = reader["E_BitTarih"].ToString();
                    eVeren.Text = reader["P_Adi"].ToString() + " " + reader["P_Soyadi"].ToString();

                }
                con.Close();

                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select eg.P_id as 'Sicil No', eg.P_Adi as 'Adı', eg.P_Soyadi as 'Soyadı' ,eg.P_Dept as 'Departmanı' ,eg.PE_Egitim_Degerlendirme as 'Egitim Degerlendirme' from(select * from Tbl_Personel_Egitim e,Tbl_Personel p where p.P_id = e.PE_id)as eg where eg.PE_Egitim_id = @id;";
                cmd.Parameters.AddWithValue("@id", selected_egitim);
                DataTable dt = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

                eAlanPers.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Raporlama Sirasinda Bir Hata Oluştu");
            }
            logoS.Source = sir.ket;
            sadi.Text = sir.lname;
            stel.Text = sir.tel;
            sweb.Text = sir.web;
            semail.Text = sir.email;
            sadres.Text = sir.adress;
            tarih.Text = DateTime.Now.ToString("M/d/yyyy");

        }
    }
}
