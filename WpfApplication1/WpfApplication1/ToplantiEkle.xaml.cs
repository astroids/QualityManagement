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
    /// Interaction logic for ToplantiEkle.xaml
    /// </summary>
    public partial class ToplantiEkle : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        private int idd = 0;
        int x = 0;
        public ToplantiEkle(int id, int secim)
        {
            x = secim;
            idd = id;
            InitializeComponent();
            con.ConnectionString = "Server=NAGASH; Database=Personel; Integrated Security=true;";
            if (secim == 1)
            {
                no.Visibility = Visibility.Visible;


                no.IsEnabled = true;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Personel where P_id = @P_id";
                cmd.Parameters.AddWithValue("@P_id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    baskan.Text = reader["P_Adi"].ToString();
                    baskan.Text += " ";
                    baskan.Text += reader["P_Soyadi"].ToString();
                    //isim.Text = reader["P_Adi"].ToString();

                }

                con.Close();
            }
            else if (secim == 2)
            {
                gizli_no.Visibility = Visibility.Visible;
                no.Visibility = Visibility.Hidden;
                gizli_no.IsEnabled = false;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Toplanti where Top_id = @Top_id";
                cmd.Parameters.AddWithValue("@Top_id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    gizli_no.Text = reader["Top_id"].ToString();
                    baskan.Text = reader["Top_Baskani"].ToString();
                    tarih.Text = reader["Top_Tar"].ToString();
                    gundem.Text = reader["Top_Gundem"].ToString();
                    katilan.Text = reader["Top_Katilanlar"].ToString();
                    aciklama.Text = reader["Top_Aciklama"].ToString();
                    yapilanlar.Text = reader["Top_Yapilanlar"].ToString();
                }

                con.Close();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (x == 1)
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Connection = con;
                cmd.CommandText = @"Insert Into Tbl_Toplanti(Top_id,Top_Tar,Top_Baskani,Top_Katilanlar,Top_Gundem,Top_Aciklama,Top_Yapilanlar)
                            values(@Top_id,@Top_Tar,@Top_Baskani,@Top_Katilanlar,@Top_Gundem,@Top_Aciklama,@Top_Yapilanlar)";
                cmd.Parameters.AddWithValue("@Top_id", no.Text);
                cmd.Parameters.AddWithValue("@Top_Tar", tarih.SelectedDate.Value);
                cmd.Parameters.AddWithValue("@Top_Baskani", baskan.Text);
                cmd.Parameters.AddWithValue("@Top_Katilanlar", katilan.Text);
                cmd.Parameters.AddWithValue("@Top_Gundem", gundem.Text);
                cmd.Parameters.AddWithValue("@Top_Aciklama", aciklama.Text);
                cmd.Parameters.AddWithValue("@Top_Yapilanlar", yapilanlar.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Kayıt Yapıldı..");
                this.Hide();

                con.Close();
            }
            else if (x == 2)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Connection = con;
                cmd.CommandText = @"Update Tbl_Toplanti set Top_Tar=@Top_Tar,Top_Baskani=@Top_Baskani,Top_Katilanlar=@Top_Katilanlar,
                                  Top_Gundem=@Top_Gundem,Top_Aciklama=@Top_Aciklama,Top_Yapilanlar=@Top_Yapilanlar 
                                  where Top_id=@Top_id";

                cmd.Parameters.AddWithValue("@Top_id", idd);
                cmd.Parameters.AddWithValue("@Top_Tar", tarih.SelectedDate.Value);
                cmd.Parameters.AddWithValue("@Top_Baskani", baskan.Text);
                cmd.Parameters.AddWithValue("@Top_Katilanlar", katilan.Text);
                cmd.Parameters.AddWithValue("@Top_Gundem", gundem.Text);
                cmd.Parameters.AddWithValue("@Top_Aciklama", aciklama.Text);
                cmd.Parameters.AddWithValue("@Top_Yapilanlar", yapilanlar.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Kayıt Yapıldı..");
                this.Hide();

                con.Close();


            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PersonelEkleSil secim = new PersonelEkleSil(11);
            secim.Show();
        }

    }
}
