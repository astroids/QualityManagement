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
            if (yet.ki.yetki == 1)
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
                    izindeolanlar.Visibility = Visibility.Visible;
                    onaybekliyenler.Visibility = Visibility.Visible;
                    izingecmisi.Visibility = Visibility.Visible;
                    onaybekliyenler.Visibility = Visibility.Visible;
                    onayla.Visibility = Visibility.Visible;
                    reddet.Visibility = Visibility.Visible;
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
            if (yet.ki.yetki == 2)
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

                else if (cagiranmenutipi == 13)
                {
                    p_grid.Visibility = Visibility.Visible;
                    egRapor.Visibility = Visibility.Visible;
                }
            }
            if (yet.ki.yetki == 3)
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
                else if (cagiranmenutipi == 13)
                {
                    p_grid.Visibility = Visibility.Visible;
                    egRapor.Visibility = Visibility.Visible;
                    egRapor.IsEnabled = false;
                    perRapor.Visibility = Visibility.Visible;
                }

            }
            con.ConnectionString = yet.ki.con;


        }



        private void listele(string ser)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                ///-------------------------------------------------------------------------arama kutusu cagirma tipi
                if (cagiranmenutipi == 1 || cagiranmenutipi == 2 || cagiranmenutipi == 4 || cagiranmenutipi == 5 || cagiranmenutipi == 6 || cagiranmenutipi == 7 || cagiranmenutipi == 8 || cagiranmenutipi == 11)
                {

                    if (ser == null || ser.Length == 0)
                    {
                        cmd.CommandText = "SPgetPersonel";

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
                        cmd.CommandText = "SPgetTumEgitim";
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
                        cmd.CommandText = "SPgetSilinen";
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
                else if (cagiranmenutipi == 13)
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
                        cmd.CommandText = "SPgetTumEgitim";
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
                 if (con.State == ConnectionState.Open){con.Close();}
            }
            catch
            {
                MessageBox.Show("Listeleme İslemi Sirasinda Bir Hata Oluştu");
                 if (con.State == ConnectionState.Open){con.Close();}
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
                    if (yet.ki.yetki == 3)
                    {
                        if (yet.ki.kulID != ID)
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



        private void izindeolanlar_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string d = DateTime.Now.ToString("yyyy-MM-dd");


                SqlCommand cmd = new SqlCommand();
                // MessageBox.Show(d);
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CTime", d);
                cmd.CommandText = "SPgetIzindeOlanlar @CTime";
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                p_grid.ItemsSource = null;
                p_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                 if (con.State == ConnectionState.Open){con.Close();}
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
                 
                    //string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    //if (ID != GirisEkrani.yet.ki.kulID)
                    //{

                    //    MessageBox.Show("Böyle bir seçim yapmaya yet.ki.yetkiniz yoktur, Lütfen kendi bulundugunuz satırı seçiniz");
                    //}
                    string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    selectedID = Convert.ToInt32(ID);
                    SqlCommand cmd = new SqlCommand();
                    if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SPizinGecmisi @ID";
                    cmd.Parameters.AddWithValue("@ID", selectedID);
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adap.Fill(dt);
                    p_grid.ItemsSource = dt.DefaultView;
                    cmd.ExecuteNonQuery();
                     if (con.State == ConnectionState.Open){con.Close();}
                }
                catch ( Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                   // MessageBox.Show("Izin Gecmisi Ekrana Getirilirken Bir Hata Oluştu");
                }

            }
            else
            {
                MessageBox.Show("İzin Geçmişini görmek için için için bir kişi seçinz");
            }
        }

        private void onaybekleyenlerlistele()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SPgetIzinOnayListele";

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                p_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch
            {
                MessageBox.Show("Onay Bekleyenler Ekrana Getirilirken Bir Hata Oluştu");
            }
        }

        private void onaybekliyenler_Click(object sender, RoutedEventArgs e)
        {
            onaybekleyenlerlistele();

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
                    if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update Tbl_Personel_Izin set PI_Onay=1,PI_OnayVeren_id =@OverID where PI_id = @sid";
                    cmd.Parameters.AddWithValue("@sid", selectedID);
                    cmd.Parameters.AddWithValue("@OverID", yet.ki.kulID);
                   

                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adap.Fill(dt);
                    p_grid.ItemsSource = dt.DefaultView;
                    cmd.ExecuteNonQuery();
                     if (con.State == ConnectionState.Open){con.Close();}
                     onayBek();
                    MessageBox.Show("Personel İzni Başarıyla Onaylandı");
                }
                catch 
                {
                    //commenti kaldır yet.ki.yetkiliyi id olark yolla          //trigger buraya olabilir onay verenin departman başkanı olduğuna bakan
                     if (con.State == ConnectionState.Open){con.Close();}
                     MessageBox.Show("Onay işlemi sırasında bir sorun oluştu lütfen yetkinizi konrol ediniz");

                }

            }
            else
            {
                MessageBox.Show("Onaylanacak izini seçiniz");
            }


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
        private void onayBek()
        {
            try
            {
                MessageBox.Show("Meneger only");
                SqlCommand cmd = new SqlCommand();
                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SPizinOnayiBekleyenPersonel";
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                p_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch
            {
                MessageBox.Show("Onay Bekliyenler Ekrana Getirilirken Bir Hata Olustu");
            }
        }


        private void onaybekliyenler_Click_1(object sender, RoutedEventArgs e)
        {
            onayBek();

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
                        if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "delete Tbl_Egitim where E_id =@sid";
                        cmd.Parameters.AddWithValue("@sid", selectedID);
                        cmd.ExecuteNonQuery();
                         if (con.State == ConnectionState.Open){con.Close();}
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
                    try
                    {
                        //if(MessageBox.Show("Devam etmek istiyormusunuz ?", "Uyarı", MessageBoxButton.YesNo);
                        string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                        selectedID = Convert.ToInt32(ID);


                        //con.ConnectionString = "Server=ERSINBM-8; Database=Personel; Integrated Security=true;";


                        if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SPistenCikarma @P_id";

                        cmd.Parameters.AddWithValue("@P_id", selectedID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Silme Yapıldı..");

                         if (con.State == ConnectionState.Open){con.Close();}
                        listele(null);
                        //rows number of record got deleted
                    }
                    catch
                    {
                        MessageBox.Show("Silme Islemi Sirasinda Bir Hata Olustu");
                    }

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
            try
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
            catch
            {
                MessageBox.Show("Personel Raporlama Sirasinda Bir Hata Olustu");
            }


        }

        private void p_grid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                con.ConnectionString = yet.ki.con;
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Personel where P_id = @id";

                //  cmd.Parameters.AddWithValue("@id", idd);
                SqlDataReader reader = cmd.ExecuteReader();
            }
            catch
            {
                MessageBox.Show("Personel Tablosundan Kisi Secimi Sirasinda Bir Hata Olustu");
            }
        }

        private void secim_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = p_grid.SelectedItem;
                if (item != null)
                {
                    string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    selectedID = Convert.ToInt32(ID);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Secim yapmadiniz!\n");
                }
            }
            catch
            {
                MessageBox.Show("Personel Tablosundan Kisi Secimi Sirasinda Bir Hata Olustu");
            }

        }

        private void reddet_Click(object sender, RoutedEventArgs e)
        {
            object item = p_grid.SelectedItem;
            if (item != null)
            {
                try
                {
                    string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    selectedID = Convert.ToInt32(ID);
                    SqlCommand cmd = new SqlCommand();
                    if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update Tbl_Personel_Izin set PI_Onay=0,PI_OnayVeren_id =@OverID where PI_id = @sid";
                    cmd.Parameters.AddWithValue("@sid", selectedID);
                    cmd.Parameters.AddWithValue("@OverID", yet.ki.kulID);


                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adap.Fill(dt);
                    p_grid.ItemsSource = dt.DefaultView;
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open) { con.Close(); }
                    onayBek();
                    MessageBox.Show("Personeli İzini Reddedildi");
                }
                catch (Exception ex)
                {
                    //commenti kaldır yet.ki.yetkiliyi id olark yolla          //trigger buraya olabilir onay verenin departman başkanı olduğuna bakan
                    if (con.State == ConnectionState.Open) { con.Close(); }
                    MessageBox.Show("Red işlemi sırasında bir sorun oluştu lütfen yetkinizi konrol ediniz");

                }

            }
            else
            {
                MessageBox.Show("Onaylanacak izini seçiniz");
            }



        }

        private void perRapor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = p_grid.SelectedItem;
                if (item != null)
                {
                    string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    int selected_personel = Convert.ToInt32(ID);
                    PersonelRaporu rap = new PersonelRaporu(selected_personel--);
                    rap.Show();
                    selected_personel = Convert.ToInt32(-1);
                }

                else
                {
                    MessageBox.Show("Lütfen bir kişi seçinz");
                }
            }
            catch
            {
                MessageBox.Show("Personel Raporlama Sirasinda Bir Hata Olustu");
            }
        }

    }
}
