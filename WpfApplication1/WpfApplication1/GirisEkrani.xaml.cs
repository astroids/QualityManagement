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
    /// Interaction logic for GirisEkrani.xaml
    /// </summary>
    public partial class GirisEkrani : MetroWindow
    {

        public static int i = 1;
        public GirisEkrani()
        {

            InitializeComponent();
            if (i % 2 == 0)
            {
                this.Close();

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=MURAT-HP; Database=Personel; Integrated Security=true;";
          
        try
            //{
                con.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Personel";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int a = 0; reader["P_id"] == null; a++)
                    {
                        MainWindow.kullaniciAdi[a] = reader["P_id"].ToString();
                        MainWindow.sifre[a] = reader["P_TcKimlik"].ToString();
                    }
                }
               
               // for (int b = 0; MainWindow.kullaniciAdi[b] == null; b++)
                for (int b = 0; MainWindow.sifre == null;b++ )
                {
                   
                    if ((kullanıcı.Text == MainWindow.kullaniciAdi[b] && sifre.Password == MainWindow.sifre[b] ) )
                    {
                        MainWindow mw = new MainWindow();
                        mw.Show();
                        this.Close();
                    }
                    if (kullanıcı.Text == "admin" && sifre.Password == "1234")
                    {
                        MainWindow mw = new MainWindow();
                        mw.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Kullanici Adi veya Sifre yanlis!!!");

                    }

                } 
             /*   con.Close();
                   catch (Exception ex)
             {
              /  MessageBox.Show(ex.Message);
             }*/
             
                

            
      
        }

    }
}