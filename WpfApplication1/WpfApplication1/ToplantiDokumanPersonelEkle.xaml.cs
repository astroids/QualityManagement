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
    /// Interaction logic for ToplantiDokumanPersonelEkle.xaml
    /// </summary>
    public partial class ToplantiDokumanPersonelEkle : MetroWindow
    {

        private SqlConnection con = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private int currentTpl
        {
            set;
            get;
        }
        private int selectedDoc
        {
            set;
            get;
        }
        private int seletedPers
        {
            set;
            get;

        }

        public ToplantiDokumanPersonelEkle(int _tpl)
        {
            InitializeComponent();
            currentTpl = _tpl;
            con.ConnectionString = yet.ki.con;
            fillGrids();
            fillTplDocs();
            wnm.Width = 512;
        }

        private void fillGrids()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select d.DKM_id as 'Doküman ID', d.DKM_Adi as 'Doküman Adı',d.DKM_Baslik as 'Doküman Başlığı',t.DKMT_Adi as 'Doküman Tipi'  from Tbl_Dokuman d join  Tbl_Dokuman_Tipi t on d.DKM_Tip=t.DKMT_id";
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                docALL.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Doküman Listesini Doldururken bir sorun oluştu!");
            }
            finally
            {
                if (con.State == ConnectionState.Open) { con.Close(); }

            }

            try
            {
                SqlCommand cmd = new SqlCommand();
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select p.P_id as 'Personel ID',p.P_Adi as 'Personel Adi',p.P_Soyadi as 'Soyadı',d.DPT_adi as 'Departmanı',p.P_Pozisyon as 'Pozisyonu',p.P_Email as 'E-Mail',p.P_Tel1 as 'Telefon',p.P_Aday as 'Aday Durumu' from Tbl_Personel p join Tbl_Departman d on p.P_Dept = d.DPT_id where P_Silindi = 0;";
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                persALL.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Persone Listesini Doldurma Islemi Sirasinda Bir Hata Olustu");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    if (con.State == ConnectionState.Open) { con.Close(); }
                }

            }
        }

        private void fillTplDocs()
        {
            
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
            cmd.CommandText = "SPToplantiyaKatilanlar @tplid";
            cmd.Parameters.AddWithValue("@tplid", currentTpl.ToString());
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            tplDocu.ItemsSource = dt.DefaultView;
            cmd.ExecuteNonQuery();
             if (con.State == ConnectionState.Open){ if (con.State == ConnectionState.Open){ if (con.State == ConnectionState.Open){con.Close();}}}

        }

        private void fillTplPers()
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
            cmd.CommandText = "SPToplantiyaKatilanPersonelListele @tplid";
            cmd.Parameters.AddWithValue("@tplid", currentTpl.ToString());
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            tplPer.ItemsSource = dt.DefaultView;
            cmd.ExecuteNonQuery();
             if (con.State == ConnectionState.Open){ if (con.State == ConnectionState.Open){ if (con.State == ConnectionState.Open){con.Close();}}}
        }

        private void kaydet_Click(object sender, RoutedEventArgs e)
        {
            if (mail.IsChecked == true)
            {
                try
                {
                    cmd = new SqlCommand();
                    if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                    
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                    cmd.CommandText = "update Tbl_Tpl_Katilanlar set Tplk_mail_onay = 1 where Tbl_Tpl_Katilanlar.Tplk_tid=@id;";
                    cmd.Parameters.AddWithValue("@id", currentTpl.ToString());
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open) { con.Close(); }
                    MessageBox.Show("Başarıyla kaydedildi");
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Mail Ekleme Sırasında bir sorun oluştu");
                    if (con.State == ConnectionState.Open) { con.Close(); }

                }
            }
            else
            {
                MessageBox.Show("Başarıyla kaydedildi");
                this.Close();
            }
        }

        private void cikar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void docEkle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = docALL.SelectedItem;
                if (item != null)
                {
                    string ID = (docALL.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    selectedDoc = Convert.ToInt32(ID);
                    cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                    cmd.CommandText = "insert into Tbl_Toplanti_Dokuman values(@tpl,@dcm)";
                    cmd.Parameters.AddWithValue("@tpl", currentTpl.ToString());
                    cmd.Parameters.AddWithValue("@dcm", selectedDoc.ToString());
                    cmd.ExecuteNonQuery();
                     if (con.State == ConnectionState.Open){ if (con.State == ConnectionState.Open){ if (con.State == ConnectionState.Open){con.Close();}}}
                    fillTplDocs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seçtiğiniz Doküman Zaten Toplantı Listesinde");
                if (con.State == ConnectionState.Open) { con.Close(); }

            }

        }

        private void uzat_Click(object sender, RoutedEventArgs e)
        {
            if (wnm.Width == 512)
            {
                wnm.Width = 1024;
            }
            else
            {
                wnm.Width = 512;
            }
        }

        private void cikar_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = tplDocu.SelectedItem;
                if (item != null)
                {
                    string ID = (tplDocu.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    selectedDoc = Convert.ToInt32(ID);
                    cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                    cmd.CommandText = "delete Tbl_Toplanti_Dokuman where Tpld_tid =@tpl and Tpld_did =@dcm;";
                    cmd.Parameters.AddWithValue("@tpl", currentTpl.ToString());
                    cmd.Parameters.AddWithValue("@dcm", selectedDoc.ToString());
                    cmd.ExecuteNonQuery();
                    fillTplDocs();
                }



            }
            catch
            {
                MessageBox.Show("Çıkarma Sırasında Bir Hata Oluştu");
            }
            finally
            {
                if (con.State == ConnectionState.Open) { con.Close(); }

            }
        }

        private void penke_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = persALL.SelectedItem;
                if (item != null)
                {
                    string ID = (persALL.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    seletedPers = Convert.ToInt32(ID);
                    cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                    cmd.CommandText = "insert into Tbl_Tpl_Katilanlar values(@tpl,@dcm,NULL,NULL)";
                    cmd.Parameters.AddWithValue("@tpl", currentTpl.ToString());
                    cmd.Parameters.AddWithValue("@dcm", seletedPers.ToString());
                    cmd.ExecuteNonQuery();
                     if (con.State == ConnectionState.Open){ if (con.State == ConnectionState.Open){con.Close();}}
                    fillTplPers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Seçtiğiniz Doküman Zaten Toplantı Listesinde");
                 if (con.State == ConnectionState.Open){ con.Close();}

            }
        }

        private void pcikar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = tplPer.SelectedItem;
                if (item != null)
                {
                    string ID = (tplPer.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    seletedPers = Convert.ToInt32(ID);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                    cmd.CommandText = "delete Tbl_Tpl_Katilanlar where Tpld_tid =@tpl and Tpld_did =@dcm;";
                    cmd.Parameters.AddWithValue("@tpl", currentTpl.ToString());
                    cmd.Parameters.AddWithValue("@dcm", seletedPers.ToString());
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open) { con.Close(); }

                    fillTplPers();
                }


            }
            catch
            {
                MessageBox.Show("Çıkarma Sırasında Bir Hata Oluştu");
                if (con.State == ConnectionState.Open) { con.Close(); }

            }

        }


    }
}
