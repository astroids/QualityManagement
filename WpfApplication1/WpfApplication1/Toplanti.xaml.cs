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

            con.ConnectionString = "Server=MURAT-HP; Database=Personel; Integrated Security=true;";
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            ///-------------------------------------------------------------------------arama kutusu cagirma tipi


            if (s == null || s.Length == 0)
            {
                cmd.CommandText = "Select * From Tbl_Toplanti";
            }
            else
            {
                cmd.CommandText = "Select * From Tbl_Toplanti s Where s.Top_Baskani like @Title";
                cmd.Parameters.AddWithValue("@Title", '%' + s + '%');
            }
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            data_grid.ItemsSource = dt.DefaultView;
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

    }
}