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
using System.ComponentModel;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Sifre.xaml
    /// </summary>
    public partial class Sifre : MetroWindow
    {

        private SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public Sifre()
        {
            InitializeComponent();
            con.ConnectionString = yet.ki.con;


        }

        private void kaydet_Click(object sender, RoutedEventArgs e)
        {

            if (eski.Text == GirisEkrani.ilksifre)
            {
                lbl.Content = "Şifre doğru";
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    con.ConnectionString = yet.ki.con;
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"update Tbl_Personel set P_Sifre=@yeni.Password where P_id=@GirisEkrani.kulAdi";
                    cmd.Parameters.AddWithValue("@P_Sifre", yeni.Password);
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adap.Fill(dt);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Şifre Başarıyla Değiştirildi");
                }
                catch
                {
                    MessageBox.Show("Hatalı Girdi");
                }
            }
            else
            {
                MessageBox.Show(" eski şifre hatalı!!!");
            }

        }

    }
}

