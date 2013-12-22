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
    /// Interaction logic for Sifre.xaml
    /// </summary>
    public partial class Sifre : MetroWindow
    {

        private SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public Sifre()
        {
            InitializeComponent();
            con.ConnectionString = yet.ki.con;


        }

        private void kaydet_Click(object sender, RoutedEventArgs e)
        {

            if (eski.Password == yet.ki.ilksifre)
            {
                lbl.Content = "Şifre doğru";
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    con.ConnectionString = yet.ki.con;
                    if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update Tbl_Personel set P_Sifre=@sif where P_id=@id";
                    cmd.Parameters.AddWithValue("@sif", yeni.Password.ToString());
                    cmd.Parameters.AddWithValue("@id",yet.ki.kulID );
                    cmd.ExecuteNonQuery();
                     if (con.State == ConnectionState.Open){con.Close();}
                    MessageBox.Show("Şifre Başarıyla Değiştirildi");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Hatalı Girdi");
                    if (con.State == ConnectionState.Open) { con.Close(); }

                }
            }
            else
            {
                MessageBox.Show(" eski şifre hatalı!!!");
            }




        }

    }
}

