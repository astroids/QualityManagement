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
        public PersonelEkleSil()
        {
            InitializeComponent();
            this.Closing += pers_Closing;
            con.ConnectionString = "Server=NAGASH; Database=Personel; Integrated Security=true;";
            listele(null);
        }
                private SqlConnection con = new SqlConnection();
        private int selectedID = 0;

        private void listele(string ser)
        {

            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            if (ser == null || ser.Length == 0)
            {
                cmd.CommandText = "Select * From Tbl_Personel";
            }
            else
            {
                cmd.CommandText = "Select * From Tbl_Personel p Where p.P_Adi like @Title";
                cmd.Parameters.AddWithValue("@Title",'%'+ser+'%');
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

        private void izingecmisi_Click(object sender, RoutedEventArgs e)
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
        private static void pers_Closing(object sender, CancelEventArgs e)
        {
            WPersonel p = new WPersonel();
            p.Show();
        }


    }
}
