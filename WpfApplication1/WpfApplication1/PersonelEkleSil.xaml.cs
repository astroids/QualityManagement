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
using System.Windows.Xps.Packaging;
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for PersonelEkleSil.xaml
    /// </summary>
    public partial class PersonelEkleSil : MetroWindow
    {
        public int cagiranmenutipi;
        private SqlConnection con = new SqlConnection();
        private int selectedID = 0;


        //1 ekle sil 2 izin  3 egitim görüntüle  4 id seç ve dön
        public PersonelEkleSil(int vers)
        {
            InitializeComponent();
            // this.Closing += pers_Closing; // pers kapama silindi ---
                
            cagiranmenutipi = vers;
            decideVisuals();
            listele(null);

        }
        private void decideVisuals()
        {
            if (GirisEkrani.yetki == "1")
            {
                if (cagiranmenutipi == 1)
                {

                    Title = "Personel Kayıt";
                    perskayit.Visibility = Visibility.Visible;

                    persedit.Visibility = Visibility.Visible;

                    silme.Visibility = Visibility.Visible;

                }
                else if (cagiranmenutipi == 2)
                {
                    Title = "Personel İzin";
                    iziniste.Visibility = Visibility.Visible;
                    izindeolanlar.Visibility = Visibility.Visible;
                    onaybekliyenler.Visibility = Visibility.Visible;
                    izingecmisi.Visibility = Visibility.Visible;
                    onaybekliyenler.Visibility = Visibility.Visible;
                    onayla.Visibility = Visibility.Visible;
                }
                else if (cagiranmenutipi == 3)
                {
                    Title = "Personel Egitim";
                    SEARCH.IsEnabled = false;// ------------------------------bu menuye ozel olmali

                    egEkle.Visibility = Visibility.Visible;
                    egDegistir.Visibility = Visibility.Visible;
                    egCikar.Visibility = Visibility.Visible;
                    egIncele.Visibility = Visibility.Visible;




                }
                else if (cagiranmenutipi == 4 || cagiranmenutipi == 5 || cagiranmenutipi == 6 || cagiranmenutipi == 7 || cagiranmenutipi == 8)
                {
                    egEkle.Content = "Seç";
                    egEkle.Visibility = Visibility.Visible;

                }
                else if (cagiranmenutipi == 9)
                {
                    yenile.Visibility = Visibility.Hidden;

                }

                else if (cagiranmenutipi == 10)
                {
                    p_grid.Visibility = Visibility.Visible;
                    egRapor.Visibility = Visibility.Visible;
                }
                else if (cagiranmenutipi == 11)
                {
                    secim.Visibility = Visibility.Visible;
                    arama.Visibility = Visibility.Hidden;
                    SEARCH.Visibility = Visibility.Hidden;
                    yenile.Visibility = Visibility.Visible;
                }
                else if (cagiranmenutipi == 12)
                {
                    p_grid.Visibility = Visibility.Visible;
                    egRapor.Visibility = Visibility.Visible;
                }


            }
            if (GirisEkrani.yetki == "2")
            {
                if (cagiranmenutipi == 1)
                {

                    Title = "Personel Kayıt";
                    perskayit.Visibility = Visibility.Visible;
                    perskayit.IsEnabled = false;
                    persedit.Visibility = Visibility.Visible;
                    //   persedit.IsEnabled = false;
                    silme.Visibility = Visibility.Visible;
                    silme.IsEnabled = false;
                }
                else if (cagiranmenutipi == 2)
                {
                    Title = "Personel İzin";
                    iziniste.Visibility = Visibility.Visible;
                    izindeolanlar.Visibility = Visibility.Visible;
                    onaybekliyenler.Visibility = Visibility.Visible;
                    izingecmisi.Visibility = Visibility.Visible;
                    onaybekliyenler.Visibility = Visibility.Visible;
                    onayla.Visibility = Visibility.Visible;
                }
                else if (cagiranmenutipi == 3)
                {
                    Title = "Personel Egitim";
                    SEARCH.IsEnabled = false;// ------------------------------bu menuye ozel olmali

                    egEkle.Visibility = Visibility.Visible;
                    egDegistir.Visibility = Visibility.Visible;
                    egCikar.Visibility = Visibility.Visible;
                    egIncele.Visibility = Visibility.Visible;

                    egCikar.IsEnabled = false;
                    egDegistir.IsEnabled = false;


                }
                else if (cagiranmenutipi == 4 || cagiranmenutipi == 5 || cagiranmenutipi == 6 || cagiranmenutipi == 7 || cagiranmenutipi == 8)
                {
                    egEkle.Content = "Seç";
                    egEkle.Visibility = Visibility.Visible;

                }
                else if (cagiranmenutipi == 9)
                {
                    yenile.Visibility = Visibility.Hidden;

                }

                else if (cagiranmenutipi == 10)
                {
                    p_grid.Visibility = Visibility.Visible;
                    egRapor.Visibility = Visibility.Visible;
                }
                else if (cagiranmenutipi == 11)
                {
                    secim.Visibility = Visibility.Visible;
                    arama.Visibility = Visibility.Hidden;
                    SEARCH.Visibility = Visibility.Hidden;
                    yenile.Visibility = Visibility.Visible;
                }
                else if (cagiranmenutipi == 12)
                {
                    p_grid.Visibility = Visibility.Visible;
                    egRapor.Visibility = Visibility.Visible;
                }


            }
            if (GirisEkrani.yetki == "3")
            {
                if (cagiranmenutipi == 1)
                {

                    Title = "Personel Kayıt";
                    perskayit.Visibility = Visibility.Visible;
                    perskayit.IsEnabled = false;
                    persedit.Visibility = Visibility.Visible;
                    //   persedit.IsEnabled = false;
                    silme.Visibility = Visibility.Visible;
                    silme.IsEnabled = false;
                }
                else if (cagiranmenutipi == 2)
                {
                    Title = "Personel İzin";
                    iziniste.Visibility = Visibility.Visible;
                    izindeolanlar.Visibility = Visibility.Visible;
                    izindeolanlar.IsEnabled = false;
                    onaybekliyenler.Visibility = Visibility.Visible;
                    onaybekliyenler.IsEnabled = false;
                    izingecmisi.Visibility = Visibility.Visible;
                    onaybekliyenler.Visibility = Visibility.Visible;
                    onaybekliyenler.IsEnabled = false;
                    onayla.Visibility = Visibility.Visible;
                    onayla.IsEnabled = false;
                }
                else if (cagiranmenutipi == 3)
                {
                    Title = "Personel Egitim";
                    SEARCH.IsEnabled = false;// ------------------------------bu menuye ozel olmali

                    egEkle.Visibility = Visibility.Visible;
                    egDegistir.Visibility = Visibility.Visible;
                    egCikar.Visibility = Visibility.Visible;
                    egIncele.Visibility = Visibility.Visible;
                    egEkle.IsEnabled = false;
                    egCikar.IsEnabled = false;
                    egDegistir.IsEnabled = false;


                }
                else if (cagiranmenutipi == 4 || cagiranmenutipi == 5 || cagiranmenutipi == 6 || cagiranmenutipi == 7 || cagiranmenutipi == 8)
                {
                    egEkle.Content = "Seç";
                    egEkle.Visibility = Visibility.Visible;
                    egEkle.IsEnabled = false;
                }
                else if (cagiranmenutipi == 9)
                {
                    yenile.Visibility = Visibility.Hidden;

                }

                else if (cagiranmenutipi == 10)
                {
                    p_grid.Visibility = Visibility.Visible;
                    egRapor.Visibility = Visibility.Visible;
                    egRapor.IsEnabled = false;
                }
                else if (cagiranmenutipi == 11)
                {
                    secim.Visibility = Visibility.Visible;
                    arama.Visibility = Visibility.Hidden;
                    SEARCH.Visibility = Visibility.Hidden;
                    yenile.Visibility = Visibility.Visible;
                    arama.IsEnabled = false;
                }
                else if (cagiranmenutipi == 12)
                {
                    p_grid.Visibility = Visibility.Visible;
                    egRapor.Visibility = Visibility.Visible;
                    egRapor.IsEnabled = false;
                }

            }
            con.ConnectionString = yet.ki.con;


        }



        private void listele(string ser)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                ///-------------------------------------------------------------------------arama kutusu cagirma tipi
                if (cagiranmenutipi == 1 || cagiranmenutipi == 2 || cagiranmenutipi == 4 || cagiranmenutipi == 5 || cagiranmenutipi == 6 || cagiranmenutipi == 7 || cagiranmenutipi == 8 || cagiranmenutipi == 11)
                {

                    if (ser == null || ser.Length == 0)
                    {
                        cmd.CommandText = "select p.P_id as 'Personel ID',p.P_Adi as 'Personel Adi',p.P_Soyadi as 'Soyadı',d.DPT_adi as 'Departmanı',p.P_Pozisyon as 'Pozisyonu',p.P_Email as 'E-Mail',p.P_Tel1 as 'Telefon',p.P_Aday as 'Aday Durumu' from Tbl_Personel p join Tbl_Departman d on p.P_Dept = d.DPT_id where P_Silindi = 0;";

                    }
                    else
                    {
                        cmd.CommandText = "select p.P_id as 'Personel ID',p.P_Adi as 'Personel Adi',p.P_Soyadi as 'Soyadı',d.DPT_adi as 'Departmanı',p.P_Pozisyon as 'Pozisyonu',p.P_Email as 'E-Mail',p.P_Tel1 as 'Telefon',p.P_Aday as 'Aday Durumu' from Tbl_Personel p join Tbl_Departman d on p.P_Dept = d.DPT_id where P_Silindi = 0 and p.P_Adi like @Title";
                        cmd.Parameters.AddWithValue("@Title", '%' + ser + '%');
                    }
                }
                else if (cagiranmenutipi == 3)                                               //3 else           ???
                {

                    if (ser == null || ser.Length == 0)
                    {
                        cmd.CommandText = "select E_id as 'id', e.E_Adi as 'Egitim Adı',e.E_BasTarih as 'Başlangış tarihi', e.E_BitTarih as 'Bitiş Tarihi',p.P_Adi as 'Egitim Veren',p.P_Soyadi as 'soyadı' from Tbl_Egitim e, Tbl_Personel p where e.E_Egi_Veren=p.P_id";
                    }
                    else
                    {
                        cmd.CommandText = "select E_id as 'id', e.E_Adi as 'Egitim Adı',e.E_BasTarih as 'Başlangış tarihi', e.E_BitTarih as 'Bitiş Tarihi',p.P_Adi as 'Egitim Veren',p.P_Soyadi as 'soyadı' from Tbl_Egitim e, Tbl_Personel p where e.E_Egi_Veren=p.P_id and e.E_Adi like @Title; and p.P_Silindi='0'";
                        cmd.Parameters.AddWithValue("@Title", '%' + ser + '%');
                    }

                }
                else if (cagiranmenutipi == 9)
                {

                    if (ser == null || ser.Length == 0)
                    {
                        cmd.CommandText = "Select * From Tbl_Personel where P_Silindi='1'";
                    }
                    else
                    {
                        cmd.CommandText = "Select * From Tbl_Personel p Where p.P_Adi like @Title and p.P_Silindi='1'";
                        cmd.Parameters.AddWithValue("@Title", '%' + ser + '%');
                    }
                }
                else if (cagiranmenutipi == 10)
                {
                    if (ser == null || ser.Length == 0)
                    {
                        cmd.CommandText = "Select * From Tbl_Personel";
                    }
                    else
                    {
                        cmd.CommandText = "Select * From Tbl_Personel p Where p.P_Adi like @Title";
                        cmd.Parameters.AddWithValue("@Title", '%' + ser + '%');
                    }
                }
                else if (cagiranmenutipi == 12)                                               //3 else           ???
                {

                    if (ser == null || ser.Length == 0)
                    {
                        cmd.CommandText = "select E_id as 'id', e.E_Adi as 'Egitim Adı',e.E_BasTarih as 'Başlangış tarihi', e.E_BitTarih as 'Bitiş Tarihi',p.P_Adi as 'Egitim Veren',p.P_Soyadi as 'soyadı' from Tbl_Egitim e, Tbl_Personel p where e.E_Egi_Veren=p.P_id";
                    }
                    else
                    {
                        cmd.CommandText = "select E_id as 'id', e.E_Adi as 'Egitim Adı',e.E_BasTarih as 'Başlangış tarihi', e.E_BitTarih as 'Bitiş Tarihi',p.P_Adi as 'Egitim Veren',p.P_Soyadi as 'soyadı' from Tbl_Egitim e, Tbl_Personel p where e.E_Egi_Veren=p.P_id and e.E_Adi like @Title;";
                        cmd.Parameters.AddWithValue("@Title", '%' + ser + '%');
                    }

                }
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                p_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Listeleme İslemi Sirasinda Bir Hata Oluştu");
            }



        }






        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            listele(SEARCH.Text);

        }

        private void ekle_Click_1(object sender, RoutedEventArgs e)
        {
            ekleDuzenle dzn = new ekleDuzenle(1, 0);
            dzn.Show();
 

        }


        //eski ekle
        private void duzenle_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = p_grid.SelectedItem;
                if (item != null)
                {
                    string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    if (GirisEkrani.yetki == "3")
                    {
                        if (GirisEkrani.kulAdi != ID)
                        {
                            MessageBox.Show("Bu kişi üzerinde işlem yapamazsınız, Lütfen kendi bilgilerinizi seçiniz");
                        }
                    }
                    selectedID = Convert.ToInt32(ID);
                    
                    ekleDuzenle dzn = new ekleDuzenle(2, selectedID);
                    dzn.Show();
                }
                else
                {
                    MessageBox.Show("Değiştirmek için bir kişi seçinz");
                }
            }
            catch
            {
                MessageBox.Show("Düzenleme İslemi Sirasinda Bir Hata Oluştu");
            }
        }
        //sil eski
        private void iziniste_Click_1(object sender, RoutedEventArgs e)
        {
            object item = p_grid.SelectedItem;
            if (item != null)
            {
                try
                {
                    string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    if (ID != GirisEkrani.kulAdi) {
                      
                        MessageBox.Show("Böyle bir seçim yapmaya yetkiniz yoktur, Lütfen kendi bulundugunuz satırı seçiniz");
                    }
                    selectedID = Convert.ToInt32(ID);
                    izinIste iz = new izinIste(selectedID);
                    iz.Show();
                    //SqlCommand cmd = new SqlCommand();
                    //con.Open();
                    //cmd.Connection = con;
                    //cmd.CommandType = CommandType.Text;
                    //cmd.CommandText = "Select * From Tbl_Personel p Where p.P_id = @id";
                    //cmd.Parameters.AddWithValue("@id", selectedID);
                    //SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    //DataTable dt = new DataTable();
                    //adap.Fill(dt);
                    //cmd.ExecuteNonQuery();
                    //con.Close();
                }
                catch
                {
                    MessageBox.Show("Izin İsteme Sirasinda Bir Hata Oluştu");
                }

            }
            else
            {
                MessageBox.Show("İzin almak için için bir kişi seçinz");
            }
        }

        private void izindeolanlar_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string d = DateTime.Now.ToString("yyyy-MM-dd");


                SqlCommand cmd = new SqlCommand();
                // MessageBox.Show(d);
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CTime", d);
                cmd.CommandText = "select p.P_Adi , p.P_id,i.PI_BasTarih,i.PI_BasTarih,t.IT_adi from Tbl_Personel_Izin i, Tbl_Personel p,Tbl_Izin_Tur t where (@CTime between  i.PI_BasTarih and i.PI_BitTarih ) and p.P_id= i.PI_Pers_id and t.IT_id= i.PI_Izin_Tur and not i.PI_Onay is null;";

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                p_grid.ItemsSource = null;
                p_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Izınde Olanlar Ekrana Getirilirken Bir Hata Oluştu");
            }


        }
        //burası-------------------------------------------
        private void izingecmisi_Click(object sender, RoutedEventArgs e)
        {
            
            object item = p_grid.SelectedItem;
            if (item != null)
            {
                try
                { 
                 
                    string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    if (ID != GirisEkrani.kulAdi)
                    {

                        MessageBox.Show("Böyle bir seçim yapmaya yetkiniz yoktur, Lütfen kendi bulundugunuz satırı seçiniz");
                    }
                    selectedID = Convert.ToInt32(ID);
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select pe.P_id as 'Sicil No', pe.P_Adi as 'Adı', pe.P_Soyadi as 'Soyadı', PI_BasTarih as 'Başlangıç Tarihi',iz.PI_BitTarih 'Bitiş Tarihi',t.IT_adi as 'İzin Türü' ,iz.PI_Onay as 'Onay durumu',p2.P_Adi as 'Onay Veren Adi',p2.P_Soyadi as 'Onay Veren Soyadı' From Tbl_Personel_Izin iz, Tbl_Personel pe ,Tbl_Personel p2,Tbl_Izin_Tur t where pe.P_id =iz.PI_Pers_id and  iz.PI_Pers_id=@sid and p2.P_id=iz.PI_OnayVeren_id and t.IT_id = iz.PI_Izin_Tur;";
                    cmd.Parameters.AddWithValue("@sid", selectedID);
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adap.Fill(dt);
                    p_grid.ItemsSource = dt.DefaultView;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch
                {
                    MessageBox.Show("Izin Gecmisi Ekrana Getirilirken Bir Hata Oluştu");
                }

            }
            else
            {
                MessageBox.Show("İzin Geçmişini görmek için için için bir kişi seçinz");
            }
        }

        private void onaybekliyenler_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select p.P_Adi , p.P_id,i.PI_BasTarih,i.PI_BasTarih,t.IT_adi from Tbl_Personel p , Tbl_Personel_Izin i ,Tbl_Izin_Tur t where p.P_id=i.PI_id and i.PI_Izin_Tur=t.IT_id and i.PI_Onay is null";

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                p_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Onay Bekleyenler Ekrana Getirilirken Bir Hata Oluştu");
            }

        }
        private void onayla_Click(object sender, RoutedEventArgs e)
        {

            object item = p_grid.SelectedItem;
            if (item != null)
            {
                try
                {
                    string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    selectedID = Convert.ToInt32(ID);
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update Tbl_Personel_Izin set PI_Onay=1,PI_OnayVeren_id =7003 where PI_id = @sid";
                    cmd.Parameters.AddWithValue("@sid", selectedID);
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adap.Fill(dt);
                    p_grid.ItemsSource = dt.DefaultView;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Onay Veren Personeli Loginle Yap Kayıt Başarılı");
                }
                catch
                {
                    MessageBox.Show("Guncelleme Sirasinda Bir Hata Oluştu");
                }

            }
            else
            {
                MessageBox.Show("İzin Geçmişini görmek için için için bir kişi seçinz");
            }


            // MessageBox.Show("in progress");
        }



        private static void pers_Closing(object sender, CancelEventArgs e)
        {
            WPersonel p = new WPersonel();
            p.Show();
        }

        private void perskayit_Click(object sender, RoutedEventArgs e)
        {
            ekleDuzenle dzn = new ekleDuzenle(1, 0);
            dzn.Show();
            this.Close();
        }

        private void persedit_Click(object sender, RoutedEventArgs e)
        {
            object item = p_grid.SelectedItem;
            if (item != null)
            {
                try
                {
                    string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    selectedID = Convert.ToInt32(ID);
                    ekleDuzenle dzn = new ekleDuzenle(2, selectedID);
                    dzn.Show();
                }
                catch
                {
                    MessageBox.Show("Bir Hata Oluştu");
                }

            }
            else
            {
                MessageBox.Show("Değiştirmek için bir kişi seçinz");
            }
        }

        private void iziniste_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                object item = p_grid.SelectedItem;
                if (item != null)
                {
                    string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    selectedID = Convert.ToInt32(ID);
                    izinIste iz = new izinIste(selectedID);
                    iz.Show();

                }
                else
                {
                    MessageBox.Show("İzin almak için için bir kişi seçinz");
                }
            }
            catch
            {
                MessageBox.Show("Izin İsteme Sirasinda Bir Hata Oluştu");
            }

        }

        private void izingecmisi_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = p_grid.SelectedItem;
                if (item != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select pe.P_id as 'Sicil No', pe.P_Adi as 'Adı', pe.P_Soyadi as 'soyadı', PI_BasTarih as 'Başlangıç Tarihi',iz.PI_BitTarih 'Bitiş Tarihi',iz.PI_Onay as 'Onay durumu' From Tbl_Personel_Izin iz, Tbl_Personel pe where pe.P_id =2 and  iz.PI_Pers_id=2";
                    MessageBox.Show("buraya kimin izin verdigini  ve izin tipinide ekle");
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adap.Fill(dt);
                    p_grid.ItemsSource = dt.DefaultView;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("İzin Geçmişini Görmek için bir kişi seçinz");
                }
            }
            catch
            {
                MessageBox.Show("Izın Gecmisi Ekrana Getirme Sirasinda Bir Hata Oluştu");
            }

        }


        // ---------------------------------------------------------------Egitim-----------------------------------------------------------------------------------

        private void egDegistir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = p_grid.SelectedItem;
                if (item != null)
                {
                    string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    selectedID = Convert.ToInt32(ID);
                    WegitimDegistir incele = new WegitimDegistir(selectedID);
                    incele.Show();

                }
                else
                {
                    MessageBox.Show("Lütfen İncelencek İzini Seçiniz");
                }
            }
            catch
            {
                MessageBox.Show("Egitim Degistime İslemi Sirasinda Bir Hata Oluştu");
            }



        }
        private void egCikar_Click(object sender, RoutedEventArgs e)
        {


        }
        private void egIncele_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = p_grid.SelectedItem;
                if (item != null)
                {
                    string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    selectedID = Convert.ToInt32(ID);
                    Wegitimincele incele = new Wegitimincele(selectedID);
                    incele.Show();

                }
                else
                {
                    MessageBox.Show("Lütfen İncelencek İzini Seçiniz");
                }
            }
            catch
            {
                MessageBox.Show("Egitim Inceleme İslemi Sirasinda Bir Hata Oluştu");
            }


        }







        private void egRapor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void egEkle_Click_1(object sender, RoutedEventArgs e)
        {
            if (cagiranmenutipi == 3)
            {
                egitimEkleme egi = new egitimEkleme();
                egi.Show();
            }
            else if (cagiranmenutipi == 4)
            {
                object item = p_grid.SelectedItem;
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                sel.ected.setSelect(Convert.ToInt32(ID));
                this.Close();


            }
            else if (cagiranmenutipi == 5)
            {
                object item = p_grid.SelectedItem;
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                sel.ected.personel_ekle(Convert.ToInt32(ID));
                this.Close();

            }
            else if (cagiranmenutipi == 6)
            {
                object item = p_grid.SelectedItem;
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                sel.ected.personel_Degistirekle(Convert.ToInt32(ID));
                this.Close();
            }
            else if (cagiranmenutipi == 7)
            {
                object item = p_grid.SelectedItem;
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                sel.ected.setDegistirEitim(Convert.ToInt32(ID));
                this.Close();


            }
            else if (cagiranmenutipi == 8)
            {
                object item = p_grid.SelectedItem;
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                sel.ected.personel_degistirEkle(Convert.ToInt32(ID));
                this.Close();
            }
            else if (cagiranmenutipi == 11)
            {
                object item = p_grid.SelectedItem;
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                sel.ected.personel_degistirEkle(Convert.ToInt32(ID));
                this.Close();
            }
            else if (cagiranmenutipi == 10)
            {
                object item = p_grid.SelectedItem;
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                sel.ected.personel_degistirEkle(Convert.ToInt32(ID));
                this.Close();
            }

        }

        private void sec_Click(object sender, RoutedEventArgs e)
        {
            PersonelEkleSil se = new PersonelEkleSil(4);
            se.Show();
        }

        private void onaybekliyenler_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Meneger only");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select pe.P_id as 'Sicil No', pe.P_Adi as 'Adı', pe.P_Soyadi as 'soyadı',iz.PI_id as 'İzin No' , PI_BasTarih as 'Başlangıç Tarihi',iz.PI_BitTarih 'Bitiş Tarihi',t.IT_adi as 'İzin Türü' from Tbl_Personel_Izin iz , Tbl_Personel pe,Tbl_Izin_Tur t where iz.PI_Pers_id=pe.P_id and iz.PI_Onay is NULL and iz.PI_Izin_Tur=t.IT_id;";
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            p_grid.ItemsSource = dt.DefaultView;
            cmd.ExecuteNonQuery();
            con.Close();


        }

        private void egCikar_Click_1(object sender, RoutedEventArgs e)
        {
            object item = p_grid.SelectedItem;
            if (item != null)
            {

                if (MessageBox.Show("Eğitim Kaldırmak Gerçekten İstiyormusunuz?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                    try
                    {
                        string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                        selectedID = Convert.ToInt32(ID);
                        SqlCommand cmd = new SqlCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "delete Tbl_Egitim where E_id =@sid";
                        cmd.Parameters.AddWithValue("@sid", selectedID);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        listele(null);
                        MessageBox.Show("İşleminiz Başarıyla gerçekleştirildi");
                    }
                    catch
                    {
                        MessageBox.Show("İşleminiz Sırasında Bir Hata Oluştu");
                    }


                }

            }
            else
            {
                MessageBox.Show("After Edit BRB");
            }
        }

        private void silme_Click(object sender, RoutedEventArgs e)
        {
            object item = p_grid.SelectedItem;
            if (item != null)
            {


                if (MessageBox.Show("Silmek istediğinize eminmisiniz", "Onay", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    //if(MessageBox.Show("Devam etmek istiyormusunuz ?", "Uyarı", MessageBoxButton.YesNo);
                    string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    selectedID = Convert.ToInt32(ID);


                    //con.ConnectionString = "Server=MURAT-HP; Database=Personel; Integrated Security=true;";


                    con.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update Tbl_Personel set P_Silindi='1' where P_id = @P_id";

                    cmd.Parameters.AddWithValue("@P_id", selectedID);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Silme Yapıldı..");

                    con.Close();
                    listele(null);
                    //rows number of record got deleted

                }


            }
            else
            {
                MessageBox.Show("Silmek için bir kişi seçinz");
            }
        }

        private void yenile_Click(object sender, RoutedEventArgs e)
        {
            listele(null);
        }

        private void egRapor_Click_1(object sender, RoutedEventArgs e)
        {
            if (cagiranmenutipi == 10)
            {
                Personel_Raporu_Departma_Secme rap = new Personel_Raporu_Departma_Secme();
                rap.Show();
            }
            else
            {

                EgitimRaporToplu rap = new EgitimRaporToplu();
                rap.Show();
            }

        }

        private void PerRapor_Click_1(object sender, RoutedEventArgs e)
        {
            object item = p_grid.SelectedItem;
            if (item != null)
            {
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                int selected_personel = Convert.ToInt32(ID);
                PersonelRapor rap = new PersonelRapor(selected_personel);
                rap.Show();
                selected_personel = Convert.ToInt32(-1);
            }

            else
            {
                MessageBox.Show("Lütfen bir kişi seçinz");
            }


        }

        private void p_grid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            con.ConnectionString = yet.ki.con;
            con.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Tbl_Personel where P_id = @id";

            //  cmd.Parameters.AddWithValue("@id", idd);
            SqlDataReader reader = cmd.ExecuteReader();
        }

        private void secim_Click(object sender, RoutedEventArgs e)
        {
            object item = p_grid.SelectedItem;
            if (item != null)
            {
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                selectedID = Convert.ToInt32(ID);
                //   ToplantiEkle x = new ToplantiEkle(selectedID, 1);                                                                                             //TOPLANTI EKLE
                //x.Show();
                this.Hide();

                /*con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Toplanti where Top_id = @Top_id";
                cmd.Parameters.AddWithValue("@Top_id", selectedID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    //isim.Text = reader["P_Adi"].ToString();

                }
                con.Close();
                */



            }
            else
            {
                MessageBox.Show("Secim yapmadiniz!\n");
            }
        }





    }
}
