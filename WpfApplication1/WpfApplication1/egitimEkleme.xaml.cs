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
    /// Interaction logic for egitimEkleme.xaml
    /// </summary>
    public partial class egitimEkleme : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        private int egitimverenid;
        //private List<int> selectedpers;
        private DateTime baslngic;
        private DateTime bitisTar;
        private int egitimno;
        public egitimEkleme()
        {
            InitializeComponent();
            con.ConnectionString = "Server=NAGASH; Database=Personel; Integrated Security=true;";
        }

        private void eVerenSec_Click(object sender, RoutedEventArgs e)
        {
            sel.ected.setOpenwindow(this);
            PersonelEkleSil sec = new PersonelEkleSil(4);
            sec.Show();
        }

        private void kaydet_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Tbl_Egitim values (@adi,@icerik,@verenid,@btr,@sontr);";
                cmd.Parameters.AddWithValue("@adi", eAdi.Text);
                cmd.Parameters.AddWithValue("@verenid", egitimverenid);
                cmd.Parameters.AddWithValue("@icerik", eIcerik.Text);
                cmd.Parameters.AddWithValue("@btr", baslngic.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@sontr", bitisTar.ToString("yyyy-MM-dd"));
                cmd.ExecuteNonQuery();
                con.Close();


                //izinin idsini bul
                con.Open();
                cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select max(e.E_id) as next from Tbl_Egitim e ";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    egitimno = Convert.ToInt32(reader["next"].ToString());
                }


                //cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(egitimno.ToString());

                Wegitimincele n = new Wegitimincele(egitimno);
                n.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Kaydetme Sirasinda Bir Hata Oluştu");
            }



        }

        private void pEkle_Click(object sender, RoutedEventArgs e)
        {
            sel.ected.setOpenwindow(this);
            PersonelEkleSil sec = new PersonelEkleSil(4);
            sec.Show();
        }
        public void setEgitimVeren(int i)
        {
            egitimverenid = i;
            MessageBox.Show(egitimverenid.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Tbl_Personel where P_id = @id";

            cmd.Parameters.AddWithValue("@id", egitimverenid);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                eVAdi.Content = reader["P_Adi"].ToString();
                eVSoyadi.Content = reader["p_Soyadi"].ToString();
            }

            con.Close();


        }
        public void basla_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            baslngic = (DateTime)basla.SelectedDate;
            MessageBox.Show(baslngic.ToString());
        }
      
        public void bitis_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            bitisTar = (DateTime)basla.SelectedDate;
            MessageBox.Show(baslngic.ToString());
        }


    }
}
