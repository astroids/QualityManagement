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
    /// Interaction logic for Toplanti.xaml
    /// </summary>
    public partial class Toplanti : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        private int selectedID = 0;
        public Toplanti()
        {
            InitializeComponent();
            listele(null);
        }
        private void listele(string s)
        {
            try
            {
                con.ConnectionString = yet.ki.con;
                SqlCommand cmd = new SqlCommand();
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                
                if (s == null || s.Length == 0)
                {
                    cmd.CommandText = "SPToplantiListele ";
                }
                else
                {
                    cmd.CommandText = "select t.Tpl_id as 'Toplatı ID', p.P_Adi + ' ' + p.P_Soyadi as 'Toplantı Başkanı',d.DPT_adi as 'Ilgili Departman'  ,t.Tpl_Gundem as 'Toplantı Gündemi' , yer.TPLY_id as 'Toplantı Yeri', t.Tpl_Tarihi as 'Toplantı Tarihi' from Tbl_Toplanti t join Tbl_Personel p on t.Tpl_Baskani=p.P_id left join Tbl_Departman d on t.Tpl_Departman=d.DPT_id left join Tbl_TplYerleri yer on t.Tpl_Yeri = yer.TPLY_id where t.Tpl_Gundem like @Title order by t.Tpl_Tarihi desc";
                    cmd.Parameters.AddWithValue("@Title", '%' + s + '%');
                }
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                data_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                 if (con.State == ConnectionState.Open){con.Close();}
            }
            catch
            {
                MessageBox.Show("Listeleme Sirasinda Bir Hata Olustu");
                if (con.State == ConnectionState.Open) { con.Close(); }

            }

        }

        DataTable table = new DataTable();

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ToplantiEkle ekle = new ToplantiEkle();
            ekle.Show();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            listele(arama.Text);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            object item = data_grid.SelectedItem;
            if (item != null)
            {

                try
                {
                    if (MessageBox.Show("Silmek istediğinize eminmisiniz", "Onay", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        //if(MessageBox.Show("Devam etmek istiyormusunuz ?", "Uyarı", MessageBoxButton.YesNo);
                        string ID = (data_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                        selectedID = Convert.ToInt32(ID);

                        if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "update Tbl_Toplanti set Tpl_Iptal=1  where Tpl_id=@Top_id";

                        cmd.Parameters.AddWithValue("@Top_id", selectedID);

                        cmd.ExecuteNonQuery();
                         if (con.State == ConnectionState.Open){con.Close();}
                         listele(null);
                         MessageBox.Show("Toplantı İptal Edild");

                        //rows number of record got deleted

                    }
                }
                catch
                {
                    MessageBox.Show("İptal Islemi Sirasinda Bir Hata Oluştu");
                    if (con.State == ConnectionState.Open) { con.Close(); }

                }



            }
            else
            {
                MessageBox.Show("İptal edilecek toplantiyi secdiginize emin olunuz!");
                if (con.State == ConnectionState.Open) { con.Close(); }

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            object item = data_grid.SelectedItem;
            if (item != null)
            {



                //if(MessageBox.Show("Devam etmek istiyormusunuz ?", "Uyarı", MessageBoxButton.YesNo);
                string ID = (data_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                selectedID = Convert.ToInt32(ID);
                //ToplantiEkle x = new ToplantiEkle(selectedID, 2);
                //x.Show();

            }
            else
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                MessageBox.Show("Degistirmek icin bir toplanti secmelisiniz!");
            }




        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            listele(null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow bac = new MainWindow();
            bac.Show();
            this.Close();
        }

    }
}
