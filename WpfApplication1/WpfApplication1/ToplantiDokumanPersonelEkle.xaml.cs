using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
using System.Drawing;
namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for ToplantiDokumanPersonelEkle.xaml
    /// </summary>
    public partial class ToplantiDokumanPersonelEkle : MetroWindow
    {

        SqlConnection con = new SqlConnection();

        public ToplantiDokumanPersonelEkle()
        {
            InitializeComponent();
            con.ConnectionString = yet.ki.con;
            fillGrids();
        }

        private void fillGrids()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select d.DKM_id as 'Doküman ID', d.DKM_Adi as 'Doküman Adı',d.DKM_Baslik as 'Doküman Başlığı',t.DKMT_Adi as 'Doküman Tipi'  from Tbl_Dokuman d join  Tbl_Dokuman_Tipi t on d.DKM_Tip=t.DKMT_id";
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                docALL.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Doküman Listesini Doldururken bir sorun oluştu!");
            }

            try
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select p.P_id as 'Personel ID',p.P_Adi as 'Personel Adi',p.P_Soyadi as 'Soyadı',d.DPT_adi as 'Departmanı',p.P_Pozisyon as 'Pozisyonu',p.P_Email as 'E-Mail',p.P_Tel1 as 'Telefon',p.P_Aday as 'Aday Durumu' from Tbl_Personel p join Tbl_Departman d on p.P_Dept = d.DPT_id where P_Silindi = 0;";
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                persALL.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Persone Listesini Doldurma Islemi Sirasinda Bir Hata Olustu");
            }
        }



        private void kaydet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cikar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
