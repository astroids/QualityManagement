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
    /// Interaction logic for ekleDuzenle.xaml
    /// </summary>
    public partial class ekleDuzenle : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();

        int x;
        int idd;
        public ekleDuzenle(int tur, int id)
        {

            InitializeComponent();
            x = tur;
            idd = id;
            con.ConnectionString = "Server=MURAT-HP; Database=Personel; Integrated Security=true;";

        }

        private void isim_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void kaydetbutonu_Click(object sender, RoutedEventArgs e)
        {



            if (x == 1)
            {
 
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandText = @"Insert Into Tbl_Personel(P_Adi,P_Soyadi,P_TcKimlik,P_Tel1,P_Tel2,P_Email,P_Cinsiyet,P_D_Tar,P_D_Yer,P_Pozisyon,P_Dept,P_Med_Hal,P_Aday) 
                                 values (@P_Adi,@P_Soyadi,@P_TcKimlik,@P_Tel1,@P_Tel2,@P_Email,@P_Cinsiyet,@P_D_Tar,@P_D_Yer,@P_Pozisyon,@P_Dept,@P_Med_Hal,@P_Aday)";

                cmd.Parameters.AddWithValue("@P_Adi", isim.Text);
                cmd.Parameters.AddWithValue("@P_Soyadi", soyisim.Text);
                cmd.Parameters.AddWithValue("@P_TcKimlik", tckimlik.Text);
                cmd.Parameters.AddWithValue("@P_Tel1", telefonno.Text);
                cmd.Parameters.AddWithValue("@P_Tel2", ceptelefon.Text);
                cmd.Parameters.AddWithValue("@P_Email", email.Text);
                cmd.Parameters.AddWithValue("@P_Cinsiyet", cinsiyet.Text);
                cmd.Parameters.AddWithValue("@P_D_Tar", dogumtarihi.SelectedDate.Value);
                cmd.Parameters.AddWithValue("@P_D_Yer", dogumyeri.Text);
                cmd.Parameters.AddWithValue("@P_Pozisyon", pozisyon.Text);
                cmd.Parameters.AddWithValue("@P_Dept", departman.Text);
                cmd.Parameters.AddWithValue("@P_Med_Hal", medenihal.Text);
                cmd.Parameters.AddWithValue("@P_Aday", adaydurumu.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Kayıt Yapıldı..");
                this.Hide();
                PersonelEkleSil ek = new PersonelEkleSil(1);
                ek.Show();
                con.Close();



            }


        }
    }
}
