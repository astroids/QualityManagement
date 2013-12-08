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
    /// Interaction logic for WPersonelcs.xaml
    /// </summary>
    public partial class WPersonel : MetroWindow
    {

        public WPersonel()
        {
            InitializeComponent();
            if (yet.ki.al == 0)
            {
                PersIs.IsEnabled = false;
            }
            im.Source = sir.ket;

        }


        private void PersIs_Button_Click(object sender, RoutedEventArgs e)
        {

            PersonelAraMenu ek = new PersonelAraMenu(this);
            ek.Show();
            //this.Hide();

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

        private void persegButton_Click(object sender, RoutedEventArgs e)
        {
            PersonelEkleSil eg = new PersonelEkleSil(3);
            eg.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PersonelEkleSil pr = new PersonelEkleSil(10);
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                ///-------------------------------------------------------------------------arama kutusu cagirma tipi
                if (cagiranmenutipi == 1 || cagiranmenutipi == 2 || cagiranmenutipi == 3 || cagiranmenutipi == 4 || cagiranmenutipi == 5 || cagiranmenutipi == 6 || cagiranmenutipi == 7 || cagiranmenutipi == 8)
                {

                    if (ser == null || ser.Length == 0)
                    {
                        cmd.CommandText = "WPersonel";

                    }
                    else
                    {
                        cmd.CommandText = "select p.P_id as 'WPersonel ID',p.P_Adi as 'WPersonel Adi',p.WP_Soyadi as 'Soyadı',d.DPT_adi as 'Departmanı',p.WP_Pozisyon as 'Pozisyonu',p.WP_Email as 'E-Mail',p.WP_Tel1 as 'Telefon',p.WP_Aday as 'Aday Durumu' from Tbl_Personel p join Tbl_Departman d on p.P_Dept = d.DPT_id where P_Silindi = 0 and p.P_Adi like @Title";
                        cmd.Parameters.AddWithValue("@Title", '%' + ser + '%');
                    }
                }
                else if (cagiranmenutipi == 9)                                               //3 else           ???
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
                else if (cagiranmenutipi == 10)
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
                else if (cagiranmenutipi == 11)
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
                con.Close();
            }
            catch
            {
                MessageBox.Show("Personel siralama İslemi Sirasinda Bir Hata Oluştu");
            }
          pr.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            PersonelEkleSil pe = new PersonelEkleSil(12);
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                
      if (cagiranmenutipi == 1 || cagiranmenutipi == 2 || cagiranmenutipi == 3 || cagiranmenutipi == 4 || cagiranmenutipi == 5 || cagiranmenutipi == 6 || cagiranmenutipi == 7 || cagiranmenutipi == 8)
                {

                    if (ser == null || ser.Length == 0)
                    {
                        cmd.CommandText = "WPersonel";

                    }
                    else
                    {
                        cmd.CommandText = "select p.P_id as 'WPersonel ID',p.P_Adi as 'WPersonel Adi',p.WP_Soyadi as 'Soyadı',d.DPT_adi as 'Departmanı',p.WP_Pozisyon as 'Pozisyonu',p.WP_Email as 'E-Mail',p.WP_Tel1 as 'Telefon',p.WP_Aday as 'Aday Durumu' from Tbl_Personel p join Tbl_Departman d on p.P_Dept = d.DPT_id where P_Silindi = 0 and p.P_Adi like @Title";
                        cmd.Parameters.AddWithValue("@Title", '%' + ser + '%');
                    }
                }
                else if (cagiranmenutipi == 9)                                               //3 else           ???
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
                else if (cagiranmenutipi == 10)
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
                else if (cagiranmenutipi == 11)
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
                con.Close();
            }
            catch
            {
                MessageBox.Show("Personel siralama İslemi Sirasinda Bir Hata Oluştu");
            }
            pe.Show();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow bac = new MainWindow();
            bac.Show();
            this.Close();
        }

    }
}
