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
    /// Interaction logic for EgitimDegerlendirme.xaml
    /// </summary>
    public partial class EgitimDegerlendirme : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        public EgitimDegerlendirme()
        {
            InitializeComponent();
            con.ConnectionString = yet.ki.con;
            fillgrid();
            wind.Width = 512;

        }

        void fillgrid()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SPgetEgitimDegerlendirme @id";
                cmd.Parameters.AddWithValue("@id", yet.ki.kulID);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                p_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch
            {
                MessageBox.Show("Doldurma Islemi Sirasinda Bir Hata Olustu");
                if (con.State == ConnectionState.Open) { con.Close(); }

            }

        }

        private void deg_Click(object sender, RoutedEventArgs e)
        {
            object item = p_grid.SelectedItem;
            if (item != null)
            {
                try
                {
                    string eID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    string pID = (p_grid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                    SqlCommand cmd = new SqlCommand();
                    if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update Tbl_Personel_Egitim set  PE_Egitim_Degerlendirme =@icer where PE_Egitim_id =@eid and PE_id=@pid";
                    cmd.Parameters.AddWithValue("@eid", eID);
                    cmd.Parameters.AddWithValue("@pid", pID);
                    cmd.Parameters.AddWithValue("@icer", icer.Text);
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open) { con.Close(); }
                    fillgrid();
                    wind.Width = 512;
                }
                catch
                {
                    MessageBox.Show("Secme Islemi Sirasinda Bir Hata Olustu");
                    if (con.State == ConnectionState.Open) { con.Close(); }

                }

            }

            else
            {
                MessageBox.Show("Lütfen bir kişi seçinz");
                if (con.State == ConnectionState.Open) { con.Close(); }

            }
        }




        private void sec_Click(object sender, RoutedEventArgs e)
        {
            if (wind.Width == 512)
            {
                wind.Width = 1024;
            }
            else
            {
                wind.Width = 512;
            }
        }




    }
}
