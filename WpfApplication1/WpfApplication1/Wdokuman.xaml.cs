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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Wdokuman.xaml
    /// </summary>
    public partial class Wdokuman : MetroWindow
    {
        public Wdokuman()
        {
            InitializeComponent();
           
        }

        private void dokumanIslem_Click(object sender, RoutedEventArgs e)
        {
            DokumanListesi lst = new DokumanListesi();
            lst.Show();
            try
            {
                selected_dokuman = sid;
                InitializeComponent();
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = yet.ki.con;
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * From Tbl_Personel   ";
                cmd.Parameters.AddWithValue("@id", sid);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PersonelAdi.Text = writer["P_Adi"].ToString();
                    PersonelSoyadi.Text = writer["P_Soyadi"].ToString();
                    Tc.Text = writer["P_TcKimlik"].ToString();
                    Tel1.Text = writer["P_Tel1"].ToString();
                    tel2.Text = writer["P_Tel2"].ToString();
                    Email.Text = writer["P_Email"].ToString();
                }
                con.Close();
                sadi.Text = sir.name;
                sadi.Text = sir.lname;
                stel.Text = sir.tel;
                Email.Text = sir.email;
                sweb.Text = sir.web;
                logoS.Source = sir.ket;
            }
            catch
            {
                MessageBox.Show("Dokuman Secme Sirasinda Bir Hata Olustu");
            }

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DokumanRevizyon rev = new DokumanRevizyon();
            rev.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow bac = new MainWindow();
            bac.Show();
            this.Close();
        }
    }
}
