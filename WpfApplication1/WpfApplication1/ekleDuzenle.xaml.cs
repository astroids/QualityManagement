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
        private string dep;
        private int x;
        private int idd;
        public ekleDuzenle(int tur, int id)
        {

            InitializeComponent();
            x = tur;
            idd = id;
            con.ConnectionString = "Server=NAGASH; Database=Personel; Integrated Security=true;";

            if (x == 2)
             {
                con.Open();
                SqlCommand cmd = new SqlCommand();
  
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Personel where P_id = @id";
  
                cmd.Parameters.AddWithValue("@id", idd);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    isim.Text = reader["P_Adi"].ToString();
                    soyisim.Text = reader["P_Soyadi"].ToString();
                    tckimlik.Text = reader["P_TcKimlik"].ToString();
                    telefonno.Text = reader["P_tel1"].ToString();
                    ceptelefon.Text = reader["P_tel2"].ToString();
                    email.Text = reader["P_Email"].ToString();
                    cinsiyet.Text = reader["P_Cinsiyet"].ToString();
                    dogumtarihi.Text = reader["P_D_Tar"].ToString();
                    dogumyeri.Text = reader["P_D_Yer"].ToString();
                    pozisyon.Text = reader["P_Pozisyon"].ToString();
                    medenihal.Text = reader["P_Med_Hal"].ToString();
                    adaydurumu.Text = reader["P_Aday"].ToString();
                }
                con.Close();
            }
            fillCombo();
        }
        private void fillCombo()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Tbl_Departman";
            cmd.Connection = con;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            adap.Fill(dt);
            departman.ItemsSource = dt.DefaultView;
            departman.DisplayMemberPath = "DPT_adi";
            departman.SelectedValuePath = "DPT_id";
            con.Close();

        }
        private void depSec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dep = departman.SelectedValue.ToString();
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

                if (isim.Text == "")
                {
                    MessageBox.Show("Adını boş geçemezsiniz!!");
                    return;
                }

                if (soyisim.Text == "")
                {
                    MessageBox.Show("Soyadını boş geçemezsiniz!!");
                    return;
                }

                if (tckimlik.Text == "")
                {
                    MessageBox.Show("TC Kimliğini boş geçemezsiniz!!");
                    return;
                }

                if (tckimlik.Text.Length != 11)
                {
                    MessageBox.Show("TC Kimlik eksik yada fazla olamaz!!");
                    return;
                }

                if (telefonno.Text == "")
                {
                    MessageBox.Show("Telefon no yu boş geçemezsiniz!!");
                    return;
                }

                if (ceptelefon.Text == "")
                {
                    MessageBox.Show("Cep Telefon u boş geçemezsiniz!!");
                    return;
                }

                if (telefonno.Text.Length != 11)
                {
                    MessageBox.Show("Telefon no eksik yada fazla olamaz!!");
                    return;
                }

                if (ceptelefon.Text.Length != 11)
                {
                    MessageBox.Show("Cep Telefon no eksik yada fazla olamaz!!");
                    return;
                }

                if (email.Text == "")
                {
                    MessageBox.Show("E-Mail i boş geçemezsiniz!!");
                    return;
                }

                if (cinsiyet.Text == "")
                {
                    MessageBox.Show("Cinsiyet i seciniz!!");
                    return;
                }

                if (dogumtarihi.Text == "")
                {
                    MessageBox.Show("Dogum tarihini boş geçemezsiniz!!");
                    return;
                }

                if (dogumyeri.Text == "")
                {
                    MessageBox.Show("Dogum yerini boş geçemezsiniz!!");
                    return;
                }

                if (pozisyon.Text == "")
                {
                    MessageBox.Show("Pozisyon u boş geçemezsiniz!!");
                    return;
                }

                if (departman.Text == "")
                {
                    MessageBox.Show("Departman ı seciniz!!");
                    return;
                }

                if (medenihal.Text == "")
                {
                    MessageBox.Show("Medeni Hal i seciniz!!");
                    return;
                }

                if (adaydurumu.Text == "")
                {
                    MessageBox.Show("Aday durumunu seciniz!!");
                    return;
                }

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandText = @"Insert Into Tbl_Personel(P_Adi,P_Soyadi,P_TcKimlik,P_Tel1,P_Tel2,P_Email,P_Cinsiyet,P_D_Tar,P_D_Yer,P_Pozisyon,P_Dept,P_Med_Hal,P_Aday,P_Silindi) 
                                 values (@P_Adi,@P_Soyadi,@P_TcKimlik,@P_Tel1,@P_Tel2,@P_Email,@P_Cinsiyet,@P_D_Tar,@P_D_Yer,@P_Pozisyon,@P_Dept,@P_Med_Hal,@P_Aday,@P_Sil)";

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
                cmd.Parameters.AddWithValue("@P_Dept", dep);
                cmd.Parameters.AddWithValue("@P_Med_Hal", medenihal.Text);
                string drm = (adaydurumu.Text == "Çalışan") ? "0" : "1";
                cmd.Parameters.AddWithValue("@P_Aday", drm);
                cmd.Parameters.AddWithValue("@P_Sil", "0");
                cmd.ExecuteNonQuery();

                MessageBox.Show("Kayıt Yapıldı..");
                this.Hide();

                PersonelEkleSil ek = new PersonelEkleSil(1);
                ek.Show();
                con.Close();



                }
 if (x == 2)
                        {
                            if (con.State == ConnectionState.Closed)
                           {
                                con.Open();
                           }
                            
                            cmd.Connection = con;
                            cmd.CommandText = @"update Tbl_Personel set P_Adi=@P_Adi,P_Soyadi=@P_Soyadi,P_TcKimlik=@P_TcKimlik,P_Tel1=@P_Tel1,P_Tel2=@P_Tel2,P_Email=@P_Email,
                                               P_Cinsiyet=@P_Cinsiyet,P_D_Tar=@P_D_Tar,P_D_Yer=@P_D_Yer,P_Pozisyon=@P_Pozisyon,P_Dept=@P_Dept,P_Med_Hal=@P_Med_Hal,P_Aday=@P_Aday where P_id=@P_id";
              
                            
                            cmd.Parameters.AddWithValue("P_id", idd);
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
                            cmd.Parameters.AddWithValue("@P_Dept", dep);
                            cmd.Parameters.AddWithValue("@P_Med_Hal", medenihal.Text);
                            string drm = (adaydurumu.Text == "Çalışan") ? "0" : "1";
                            cmd.Parameters.AddWithValue("@P_Aday", drm);
            
                            cmd.ExecuteNonQuery();
            
                            MessageBox.Show("Degisiklik Yapildi..");
                            this.Hide();
                            PersonelEkleSil ek = new PersonelEkleSil(1);
                            ek.Show();
                            con.Close();
                       }
            
               }


        }
}
