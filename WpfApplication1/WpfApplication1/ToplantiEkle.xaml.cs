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
        private int toplanti_baskani;
        private string toplanti_departmani;
        public ToplantiEkle()
        {
            InitializeComponent();
            con.ConnectionString = "Server=MURAT-HP; Database=Personel; Integrated Security=true;";
            fillCombo();


            //if (secim == 1)
            //{
            //    no.Visibility = Visibility.Visible;


            //    no.IsEnabled = true;
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.Connection = con;
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = "select * from Tbl_Personel where P_id = @P_id";
            //    cmd.Parameters.AddWithValue("@P_id", id);
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        baskan.Text = reader["P_Adi"].ToString();
            //        baskan.Text += " ";
            //        baskan.Text += reader["P_Soyadi"].ToString();
            //        //isim.Text = reader["P_Adi"].ToString();

            //    }

            //    con.Close();
            //}
            //else if (secim == 2)
            //{
            //    gizli_no.Visibility = Visibility.Visible;
            //    no.Visibility = Visibility.Hidden;
            //    gizli_no.IsEnabled = false;
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.Connection = con;
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = "select * from Tbl_Toplanti where Tpl_id = @Tpl_id";
            //    cmd.Parameters.AddWithValue("@Tpl_id", id);
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        gizli_no.Text = reader["Tpl_id"].ToString();
            //        baskan.Text = reader["Tpl_Baskani"].ToString();
            //        tarih.Text = reader["Tpl_Tar"].ToString();
            //        gundem.Text = reader["Tpl_Gundem"].ToString();
            //        katilan.Text = reader["Tpl_Katilanlar"].ToString();
            //        aciklama.Text = reader["Tpl_Aciklama"].ToString();
            //        yapilanlar.Text = reader["Tpl_Yapilanlar"].ToString();
            //    }

            //    con.Close();
            //}

        }
        void fillCombo()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Departman";
                cmd.Connection = con;
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);

                adap.Fill(dt);
                depSec.ItemsSource = dt.DefaultView;
                depSec.DisplayMemberPath = "DPT_adi";
                depSec.SelectedValuePath = "DPT_id";
                con.Close();
            }
            catch
            {
                MessageBox.Show("Doldurma Sirasinda Bir Hata Olustu");
            }

        }

        public void baskaniSec(int _toplanti_baskani)
        {
            try
            {
                toplanti_baskani = _toplanti_baskani;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Personel p where p.P_id = @id";
                cmd.Parameters.AddWithValue("@id", toplanti_baskani);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    baskanN.Text = reader["P_Adi"].ToString();
                    baskanS.Text = reader["P_Soyadi"].ToString();
                    baskanC.Text = reader["P_Pozisyon"].ToString();

                }
                con.Close();
            }
            catch
            {
                MessageBox.Show("Baskan Secimi Sirasinda Bir Hata Olustu");
            }
        }



        //        private void Button_Click_1(object sender, RoutedEventArgs e)
        //        {

        //            else if (x == 2)
        //            {
        //                if (con.State == ConnectionState.Closed)
        //                {
        //                    con.Open();
        //                }

        //                cmd.Connection = con;
        //                cmd.CommandText = @"Update Tbl_Toplanti set Tpl_Tar=@Tpl_Tar,Tpl_Baskani=@Tpl_Baskani,Tpl_Katilanlar=@Tpl_Katilanlar,
        //                                  Tpl_Gundem=@Tpl_Gundem,Tpl_Aciklama=@Tpl_Aciklama,Tpl_Yapilanlar=@Tpl_Yapilanlar 
        //                                  where Tpl_id=@Tpl_id";

        //                cmd.Parameters.AddWithValue("@Tpl_id", idd);
        //                cmd.Parameters.AddWithValue("@Tpl_Tar", tarih.SelectedDate.Value);
        //                cmd.Parameters.AddWithValue("@Tpl_Baskani", baskan.Text);
        //                cmd.Parameters.AddWithValue("@Tpl_Katilanlar", katilan.Text);
        //                cmd.Parameters.AddWithValue("@Tpl_Gundem", gundem.Text);
        //                cmd.Parameters.AddWithValue("@Tpl_Aciklama", aciklama.Text);
        //                cmd.Parameters.AddWithValue("@Tpl_Yapilanlar", yapilanlar.Text);

        //                cmd.ExecuteNonQuery();

        //                MessageBox.Show("Kayıt Yapıldı..");
        //                this.Hide();

        //                con.Close();


        //            }
        //        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PersonelEkleSil secim = new PersonelEkleSil(11);
            secim.Show();
        }

        private void kaydet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.CommandText = @"Insert Into Tbl_Toplanti(Tpl_Baskani,Tpl_Tarihi,Tpl_Gundem,Tpl_Aciklama,Tpl_Departman,Tpl_Yeri,Tpl_Iptal)
                            values(@Tpl_Baskani,@Tpl_Tarihi,@Tpl_Gundem,@Tpl_Aciklama,@Tpl_Departman,@Tpl_Yeri,@Tpl_Iptal)";

                cmd.Parameters.AddWithValue("@Tpl_Tarihi", tarih.SelectedDate.Value);
                cmd.Parameters.AddWithValue("@Tpl_Yeri", toplantiyeri.Text);
                cmd.Parameters.AddWithValue("@Tpl_Baskani", toplanti_baskani);
                //         cmd.Parameters.AddWithValue("@Tpl_Katilanlar", katilan.Text);
                cmd.Parameters.AddWithValue("@Tpl_Gundem", gundem.Text);
                cmd.Parameters.AddWithValue("@Tpl_Aciklama", aciklama.Text);
                cmd.Parameters.AddWithValue("@Tpl_Iptal", "0");
                cmd.Parameters.AddWithValue("@Tpl_Departman", toplanti_departmani);

                //           cmd.Parameters.AddWithValue("@Tpl_Yapilanlar", yapilanlar.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Kayıt Yapıldı..");
                con.Close();
                ToplantiDokumanPersonelEkle pd = new ToplantiDokumanPersonelEkle();
                pd.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Kayit Başarısız!");
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }

        private void sec_Click(object sender, RoutedEventArgs e)
        {
            sel.ected.setOpenwindowTPL(this);
            PersonelSelector sele = new PersonelSelector();
            sele.Show();

        }

        private void depSec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            toplanti_departmani = depSec.SelectedValue.ToString();

        }

    }
}
