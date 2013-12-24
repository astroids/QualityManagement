using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for DosyaİzinTipiEkle.xaml
    /// </summary>
    public partial class DosyaİzinTipiEkle : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        public DosyaİzinTipiEkle()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
              

            try
            {
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = yet.ki.con;
                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Tbl_Dokuman_Tipi (@tip);";
                cmd.Parameters.AddWithValue("@ad", dtipi.Text);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
                MessageBox.Show("Başarıyla Eklendi");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Hatalı Girdi");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = yet.ki.con;
                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Tbl_Izin_Tur (@tip);";
                cmd.Parameters.AddWithValue("@ad", itipi.Text);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
                MessageBox.Show("Başarıyla Eklendi");
                this.Close();

            }
            catch
            {
                MessageBox.Show("Hatalı Girdi");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = yet.ki.con;
                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Tbl_TplYerleri (@tip);";
                cmd.Parameters.AddWithValue("@ad", tplyer.Text);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
                MessageBox.Show("Başarıyla Eklendi");
                this.Close();

            }
            catch
            {
                MessageBox.Show("Hatalı Girdi");
            }
        }
    }
}
