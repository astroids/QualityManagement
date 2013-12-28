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
        private int ilkyetki;
        private int ilksifre;
        private string yeniKullID;
        public ekleDuzenle(int tur, int id)
        {

            InitializeComponent();
            x = tur;
            idd = id;
            con.ConnectionString = yet.ki.con;
            if (yet.ki.yetki == 3) {
                isim.IsEnabled = false;
                soyisim.IsEnabled = false;
                tckimlik.IsEnabled = false;
              //  telefonno.IsEnabled = false;
                email.IsEnabled = false;
                dogumtarihi.IsEnabled = false;
                dogumyeri.IsEnabled = false;
                cinsiyet.IsEnabled = false;
                pozisyon.IsEnabled = false;
                departman.IsEnabled = false;
                adaydurumu.IsEnabled = false;
                checkmudur.IsEnabled = false;
                checkmYardım.IsEnabled=false;
                checkper.IsEnabled=false;
            
            
            }
            try
            {
                if (x == 2)
                {


                    if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
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
                     if (con.State == ConnectionState.Open){con.Close();}
                }
                fillCombo();
            }
            catch
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                MessageBox.Show("Duzenleme Sırasında Bir Hata Oluştu");
            }
        }
        private void fillCombo()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Departman";
                cmd.Connection = con;
                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                DataTable dt = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);

                adap.Fill(dt);
                departman.ItemsSource = dt.DefaultView;
                departman.DisplayMemberPath = "DPT_adi";
                departman.SelectedValuePath = "DPT_id";
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch
            {
                MessageBox.Show("Doldurma İşlemi Sırasında Bir Hata Oluştu");
            }

        }
        private void depSec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dep = departman.SelectedValue.ToString();
        }



        private void kaydetbutonu_Click(object sender, RoutedEventArgs e)
        {
            if (yet.ki.yetki != 3)
            {
                if (x == 1)
                {

                    if (isim.Text == "")
                    {
                        MessageBox.Show("Adını Boş Geçemezsiniz !!");
                        return; 
                    }

                    if (soyisim.Text == "")
                    {
                        MessageBox.Show("Soyadını Boş Geçemezsiniz !!");
                        return;
                    }

                    if (tckimlik.Text == "")
                    {
                        MessageBox.Show("TC Kimlik Numarasını Boş Geçemezsiniz !!");
                        return;
                    }

                    if (tckimlik.Text.Length != 11)
                    {
                        MessageBox.Show("TC Kimlik Eksik ya da Fazla Olamaz !!");
                        return;
                    }

                    if (telefonno.Text == "")
                    {
                        MessageBox.Show("Telefon Numarasını Boş Geçemezsiniz !!");
                        return;
                    }

                    if (ceptelefon.Text == "")
                    {
                        MessageBox.Show("Cep Telefonunu Boş Geçemezsiniz !!");
                        return;
                    }

                    if (telefonno.Text.Length != 11)
                    {
                        MessageBox.Show("Telefon No Eksik ya da Fazla Olamaz !!");
                        return;
                    }

                    if (ceptelefon.Text.Length != 11)
                    {
                        MessageBox.Show("Cep Telefon No Eksik ya da Fazla Olamaz !!");
                        return;
                    }

                    if (email.Text == "")
                    {
                        MessageBox.Show("E-Mail i Boş Geçemezsiniz !!");
                        return;
                    }

                    if (cinsiyet.Text == "")
                    {
                        MessageBox.Show("Cinsiyeti seciniz !!");
                        return;
                    }

                    if (dogumtarihi.Text == "")
                    {
                        MessageBox.Show("Doğum Tarihini Boş Geçemezsiniz !!");
                        return;
                    }

                    if (dogumyeri.Text == "")
                    {
                        MessageBox.Show("Doğum Yerini Boş Geçemezsiniz !!");
                        return;
                    }

                    if (pozisyon.Text == "")
                    {
                        MessageBox.Show("Pozisyonu Boş Geçemezsiniz !!");
                        return;
                    }
                    if (yet.ki.yetki != 3)
                    {
                        if (departman.Text == "")
                        {
                            MessageBox.Show("Departmanı Seçiniz !!");
                            return;
                        }
                    }
                    if (medenihal.Text == "")
                    {
                        MessageBox.Show("Medeni Hali Seciniz !!");
                        return;
                    }
                    if (yet.ki.yetki != 3)
                    {
                        if (adaydurumu.Text == "")
                        {
                            MessageBox.Show("Aday Durumunu Seciniz !!");
                            return;
                        }
                    }
                    if (checkmudur.IsChecked == true)
                    {
                       ilkyetki=1;
                        // yet.ki.yetki = 1;
                    }
                    if (checkmYardım.IsChecked == true)
                    {
                       ilkyetki=2;

                        // yet.ki.yetki = 2;

                    }
                    if (checkper.IsChecked == true)
                    { 
                        ilkyetki=3;
                        //yet.ki.yetki = 3;
                    }
                    Random rn = new Random();
                    ilksifre=rn.Next(1000, 9999);
                    if ((checkmudur.IsChecked == true && checkmYardım.IsChecked == true) || (checkmudur.IsChecked == true && checkper.IsChecked == true) || (checkmYardım.IsChecked == true && checkper.IsChecked == true) || (checkmudur.IsChecked == true && checkmYardım.IsChecked == true && checkper.IsChecked == true))
                    {
                        MessageBox.Show("En Fazla Bir Pozisyon Seçebilirsiniz");
                    }
                    if (con.State == ConnectionState.Closed)
                    {
                        if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                    }

                    try
                    {
                        cmd.Connection = con;
                        cmd.CommandText = @"Insert Into Tbl_Personel(P_Adi,P_Soyadi,P_TcKimlik,P_Tel1,P_Tel2,P_Email,P_Cinsiyet,P_D_Tar,P_D_Yer,P_Pozisyon,P_Dept,P_Med_Hal,P_Aday,P_Silindi,P_Yetki,P_Sifre) 
                                 values (@P_Adi,@P_Soyadi,@P_TcKimlik,@P_Tel1,@P_Tel2,@P_Email,@P_Cinsiyet,@P_D_Tar,@P_D_Yer,@P_Pozisyon,@P_Dept,@P_Med_Hal,@P_Aday,@P_Sil,@P_yet,@P_Sifre)SELECT SCOPE_IDENTITY();";


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
                        int drm = (adaydurumu.Text == "Çalışan") ? 0 : 1;
                        cmd.Parameters.AddWithValue("@P_Aday", drm.ToString());
                        cmd.Parameters.AddWithValue("@P_Sil", "0");
                        cmd.Parameters.AddWithValue("@P_Sifre", ilksifre);
                        if (drm == 1)
                        {
                            cmd.Parameters.AddWithValue("@P_yet", 4);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@P_yet", ilkyetki);
                        }
                        if (dep == null)
                        {
                            MessageBox.Show("Departmanı Seçmediniz !!");

                            return;

                        }

                        yeniKullID = cmd.ExecuteScalar().ToString();

                        MessageBox.Show("Kayıt Yapıldı");

                        MessageBox.Show("Kullanıcı ID niz" + yeniKullID +"\n İlk Şifreniz: " + ilksifre.ToString());
                        this.Hide();

                        PersonelEkleSil ek = new PersonelEkleSil(1);
                        ek.Show();
                         if (con.State == ConnectionState.Open){con.Close();}
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        MessageBox.Show("Kayıt Yapılırken Bir Hata Oluştu");
                        if (con.State == ConnectionState.Open) { con.Close(); }

                    }
                }
            }
            if (yet.ki.yetki != 3)
            {

                if (x == 2)
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                    }
                    try
                    {
                        cmd.Connection = con;
                        cmd.CommandText = @"update Tbl_Personel set P_Adi=@P_Adi,P_Soyadi=@P_Soyadi,P_TcKimlik=@P_TcKimlik,P_Tel1=@P_Tel1,P_Tel2=@P_Tel2,P_Email=@P_Email,
                                               P_Cinsiyet=@P_Cinsiyet,P_D_Tar=@P_D_Tar,P_D_Yer=@P_D_Yer,P_Pozisyon=@P_Pozisyon,P_Dept=@P_Dept,P_Med_Hal=@P_Med_Hal,P_Aday=@P_Aday where P_id=@P_id";
                        if (isim.Text == "")
                        {
                            MessageBox.Show("Adını Boş Geçemezsiniz !!");
                            return;
                        }

                        if (soyisim.Text == "")
                        {
                            MessageBox.Show("Soyadını Boş Geçemezsiniz !!");
                            return;
                        }

                        if (tckimlik.Text == "")
                        {
                            MessageBox.Show("TC Kimliğini Boş Geçemezsiniz !!");
                            return;
                        }

                        if (tckimlik.Text.Length != 11)
                        {
                            MessageBox.Show("TC Kimlik Eksik ya da Fazla Olamaz !!");
                            return;
                        }

                        if (telefonno.Text == "")
                        {
                            MessageBox.Show("Telefon No yu Boş Geçemezsiniz !!");
                            return;
                        }

                        if (ceptelefon.Text == "")
                        {
                            MessageBox.Show("Cep Telefonunu Boş Geçemezsiniz !!");
                            return;
                        }

                        if (telefonno.Text.Length != 11)
                        {
                            MessageBox.Show("Telefon No Eksik ya da Fazla Olamaz !!");
                            return;
                        }

                        if (ceptelefon.Text.Length != 11)
                        {
                            MessageBox.Show("Cep Telefon No Eksik ya da Fazla Olamaz !!");
                            return;
                        }

                        if (email.Text == "")
                        {
                            MessageBox.Show("E-Mail i Boş Geçemezsiniz !!");
                            return;
                        }

                        if (cinsiyet.Text == "")
                        {
                            MessageBox.Show("Cinsiyeti Seçiniz !!");
                            return;
                        }

                        if (dogumtarihi.Text == "")
                        {
                            MessageBox.Show("Doğum Tarihini Boş Geçemezsiniz !!");
                            return;
                        }

                        if (dogumyeri.Text == "")
                        {
                            MessageBox.Show("Doğum Yerini Boş Geçemezsiniz !!");
                            return;
                        }

                        if (pozisyon.Text == "")
                        {
                            MessageBox.Show("Pozisyonu Boş Geçemezsiniz !!");
                            return;
                        }
                      
                            if (departman.Text == "")
                            {
                                MessageBox.Show("Departmanı Seçiniz !!");
                                return;
                            }
                        

                        if (medenihal.Text == "")
                        {
                            MessageBox.Show("Medeni Hali Seçiniz !!");
                            return;
                        }
                        
                            if (adaydurumu.Text == "")
                            {
                                MessageBox.Show("Aday Durumunu Seçiniz !!");
                                return;
                            }
                        
                        if (checkmudur.IsChecked == true)
                        {
                            yet.ki.yetki = 1;
                        }

                        if (checkmYardım.IsChecked == true)
                        {
                            yet.ki.yetki = 2;

                        }

                        if (checkper.IsChecked == true)
                        {
                            yet.ki.yetki = 3;
                        }

                        if ((checkmudur.IsChecked == true && checkmYardım.IsChecked == true) || (checkmudur.IsChecked == true && checkper.IsChecked == true) || (checkmYardım.IsChecked == true && checkper.IsChecked == true) || (checkmudur.IsChecked == true && checkmYardım.IsChecked == true && checkper.IsChecked == true))
                        {
                            MessageBox.Show("En Fazla Bir Pozisyon Seçebilirsiniz");
                        }

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
                        int drm = (adaydurumu.Text == "Çalışan") ? 0 : 1;
                        cmd.Parameters.AddWithValue("@P_Aday", drm.ToString());
                        if (drm == 1)
                        {
                            cmd.Parameters.AddWithValue("@P_yet", 4);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@P_yet", "NULL");
                        }
                       
                            if (dep == null)
                            {
                                MessageBox.Show("Departmanı Seçmediniz !!");

                                return;

                            }
                        

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Değişiklik Yapıldı");
                        this.Hide();
                        PersonelEkleSil ek = new PersonelEkleSil(1);
                        ek.Show();
                         if (con.State == ConnectionState.Open){con.Close();}
                    }
                    catch
                    {
                        MessageBox.Show("Guncelleme Yapılırken Bir Hata Oluştu");
                    }

                }

            }
            if (yet.ki.yetki == 3)
            {

                if (x == 2)
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                    }
                    try
                    {
                        cmd.Connection = con;
                        cmd.CommandText = @"update Tbl_Personel set P_Tel1=@P_Tel1,P_Tel2=@P_Tel2,P_Email=@P_Email,
                                             P_Med_Hal=@P_Med_Hal P_id=@P_id";
                        if (telefonno.Text == "")
                        {
                            MessageBox.Show("Telefon No yu Boş Geçemezsiniz !!");
                            return;
                        }

                        if (ceptelefon.Text == "")
                        {
                            MessageBox.Show("Cep Telefonu Boş Geçemezsiniz !!");
                            return;
                        }

                        if (telefonno.Text.Length != 11)
                        {
                            MessageBox.Show("Telefon No Eksik ya da Fazla Olamaz !!");
                            return;
                        }

                        if (ceptelefon.Text.Length != 11)
                        {
                            MessageBox.Show("Cep Telefon No Eksik ya da Fazla Olamaz !!");
                            return;
                        }

                        if (email.Text == "")
                        {
                            MessageBox.Show("E-Mail i Boş Geçemezsiniz !!");
                            return;
                        }
                        if (medenihal.Text == "")
                        {
                            MessageBox.Show("Medeni Hali Seçiniz !!");
                            return;
                        }
                        cmd.Parameters.AddWithValue("@P_TcKimlik", tckimlik.Text);
                        cmd.Parameters.AddWithValue("@P_Tel1", telefonno.Text);
                        cmd.Parameters.AddWithValue("@P_Tel2", ceptelefon.Text);
                        cmd.Parameters.AddWithValue("@P_Email", email.Text);
                        cmd.Parameters.AddWithValue("@P_Med_Hal", medenihal.Text);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Değişiklik Yapıldı");
                        this.Hide();
                        PersonelEkleSil ek = new PersonelEkleSil(1);
                        ek.Show();
                         if (con.State == ConnectionState.Open){con.Close();}
                    }
                    catch
                    {
                        MessageBox.Show("Güncelleme Yapılırken Bir Hata Oluştu");
                    }

                }
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sifre sfr = new Sifre();
            sfr.Show();
        }


    }
}
