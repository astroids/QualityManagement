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
                egRapor.Visibility = Visibility.Visible;


            }
            else if (cagiranmenutipi == 4|| cagiranmenutipi == 5 || cagiranmenutipi == 6||cagiranmenutipi==7 || cagiranmenutipi==8)                     
            {
                egEkle.Content = "Seç";
                egEkle.Visibility = Visibility.Visible;
                
            }
            else if (cagiranmenutipi == 9)
            {
                yenile.Visibility = Visibility.Hidden;
            }


            con.ConnectionString = "Server=ERSINBM-8; Database=Personel; Integrated Security=true;";

            
            listele(null);
        }


        

        private void listele(string ser)
        {

            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            ///-------------------------------------------------------------------------arama kutusu cagirma tipi
            if (cagiranmenutipi == 1 || cagiranmenutipi == 2 || cagiranmenutipi == 4 || cagiranmenutipi == 5 || cagiranmenutipi == 6 || cagiranmenutipi == 7 || cagiranmenutipi == 8)
            {

                if (ser == null || ser.Length == 0)
                {
                    cmd.CommandText = "Select * From Tbl_Personel where P_Silindi='Hayır'";
                }
                else
                {
                    cmd.CommandText = "Select * From Tbl_Personel p Where p.P_Adi like @Title and p.P_Silindi='Hayır'";
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
                    cmd.CommandText = "select E_id as 'id', e.E_Adi as 'Egitim Adı',e.E_BasTarih as 'Başlangış tarihi', e.E_BitTarih as 'Bitiş Tarihi',p.P_Adi as 'Egitim Veren',p.P_Soyadi as 'soyadı' from Tbl_Egitim e, Tbl_Personel p where e.E_Egi_Veren=p.P_id and e.E_Adi like @Title; and p.P_Silindi='Hayır'";
                    cmd.Parameters.AddWithValue("@Title", '%' + ser + '%');
                }

            }
            else if (cagiranmenutipi == 9)
            {

                if (ser == null || ser.Length == 0)
                {
                    cmd.CommandText = "Select * From Tbl_Personel where P_Silindi='Evet'";
                }
                else
                {
                    cmd.CommandText = "Select * From Tbl_Personel p Where p.P_Adi like @Title and p.P_Silindi='Evet'";
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






        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
              listele(SEARCH.Text);

        }

        private void ekle_Click_1(object sender, RoutedEventArgs e)
        {
            ekleDuzenle dzn = new ekleDuzenle(1,0);
            dzn.Show();
        }


        //eski ekle
        private void duzenle_Click_1(object sender, RoutedEventArgs e)
        {
            
            object item = p_grid.SelectedItem;
            if (item != null)
            {
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                selectedID = Convert.ToInt32(ID);
                ekleDuzenle dzn = new ekleDuzenle(2, selectedID);
                dzn.Show();
            }
            else
            {
                MessageBox.Show("Deiştirmek için bir kişi seçinz");
            }
        }
        //sil eski
        private void iziniste_Click_1(object sender, RoutedEventArgs e)
        {
            object item = p_grid.SelectedItem;
            if (item != null)
            {
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
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
            else
            {
                MessageBox.Show("İzin almak için için bir kişi seçinz");
            }
        }

        private void izindeolanlar_Click_1(object sender, RoutedEventArgs e)
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
        //burası-------------------------------------------
        private void izingecmisi_Click(object sender, RoutedEventArgs e)
        {
            object item = p_grid.SelectedItem;
            if (item != null)
            {
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
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
            else
            {
                MessageBox.Show("İzin Geçmişini görmek için için için bir kişi seçinz");
            }
        }

        private void onaybekliyenler_Click(object sender, RoutedEventArgs e)
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
        private void onayla_Click(object sender, RoutedEventArgs e)
        {
            /*
            object item = p_grid.SelectedItem;
            if (item != null)
            {
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                selectedID = Convert.ToInt32(ID);
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select pe.P_id as 'Sicil No', pe.P_Adi as 'Adı', pe.P_Soyadi as 'soyadı', PI_BasTarih as 'Başlangıç Tarihi',iz.PI_BitTarih 'Bitiş Tarihi',t.IT_adi as 'İzin Türü' ,iz.PI_Onay as 'Onay durumu',p2.P_Adi as 'Onay Veren Adi',p2.P_Soyadi as 'Soyadı' From Tbl_Personel_Izin iz, Tbl_Personel pe ,Tbl_Personel p2,Tbl_Izin_Tur t where pe.P_id =iz.PI_Pers_id and  iz.PI_Pers_id=@sid and p2.P_id=iz.PI_OnayVeren_id and t.IT_id = iz.PI_Izin_Tur;";
                cmd.Parameters.AddWithValue("@sid", selectedID);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                p_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                MessageBox.Show("İzin Geçmişini görmek için için için bir kişi seçinz");
            }

            */
            MessageBox.Show("in progress");
        }



        private static void pers_Closing(object sender, CancelEventArgs e)
        {
            //sil
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
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                selectedID = Convert.ToInt32(ID);
                ekleDuzenle dzn = new ekleDuzenle(2, selectedID);
                dzn.Show();
            }
            else
            {
                MessageBox.Show("Deiştirmek için bir kişi seçinz");
            }
        }

        private void iziniste_Click(object sender, RoutedEventArgs e)
        {
            object item = p_grid.SelectedItem;
            if (item != null)
            {
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
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
            else
            {
                MessageBox.Show("İzin almak için için bir kişi seçinz");
            }
        }

        private void izingecmisi_Click_1(object sender, RoutedEventArgs e)
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


        // ---------------------------------------------------------------Egitim-----------------------------------------------------------------------------------

        private void egDegistir_Click(object sender, RoutedEventArgs e)
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
        private void egCikar_Click(object sender, RoutedEventArgs e)
        {


        }
        private void egIncele_Click(object sender, RoutedEventArgs e)
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


                    //con.ConnectionString = "Server=ERSINBM-8; Database=Personel; Integrated Security=true;";


                    con.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update Tbl_Personel set P_Silindi='Evet' where P_id = @P_id";

                    cmd.Parameters.AddWithValue("@P_id", selectedID);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Silme Yapıldı..");

                    con.Close();

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










    }
}
