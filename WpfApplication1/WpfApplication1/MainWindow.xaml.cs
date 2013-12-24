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
using System.IO;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 





    public partial class MainWindow : MetroWindow
    {

        public static string kim;
        public static string kimsifre;
        public MainWindow()
        {
            
            InitializeComponent();
            if (yet.ki.yetki == 3 || yet.ki.yetki == 4)
            {
                dokuman.IsEnabled = false;
                toplanti.IsEnabled = false;
                ayarlar.IsEnabled = false;
            }
            slogo.refresh();
            im.Source = sir.ket;
        }


        private void Personel_Button_Click(object sender, RoutedEventArgs e)
        {
            WPersonel pers = new WPersonel();
            pers.Show();
            this.Close();
        }

        private void dokuman_Click(object sender, RoutedEventArgs e)
        {
            Wdokuman doc = new Wdokuman();
            doc.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Toplanti topl = new Toplanti();
            topl.Show();
            this.Close();
        }

        private void dokuman_Click_1(object sender, RoutedEventArgs e)
        {
            Wdokuman docara = new Wdokuman();
            docara.Show();
            this.Close();
        }


        private void ayarlar_Click(object sender, RoutedEventArgs e)
        {
            AYARLAR ay = new AYARLAR();
            sel.ected.setOpenMain(this);
            ay.Show();
        }

        private void araclar_Click(object sender, RoutedEventArgs e)
        {
            Araclar ar = new Araclar();
            ar.Show();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {

                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(Directory.GetCurrentDirectory() + "\\personel.png");
                logo.EndInit();
                im.Source = logo;
            }
            catch
            {

            }
        }

        private void toplanti_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {

                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(Directory.GetCurrentDirectory() + "\\meet.png");
                logo.EndInit();
                im.Source = logo;
            }
            catch
            {

            }
        }

        private void dokuman_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {

                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(Directory.GetCurrentDirectory() + "\\Document-icon.png");
                logo.EndInit();
                im.Source = logo;
            }
            catch
            {

            }
        }

        private void ayarlar_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {

                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(Directory.GetCurrentDirectory() + "\\Settings-icon.png");
                logo.EndInit();
                im.Source = logo;
            }
            catch
            {

            }
        }



        private void araclar_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {

                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(Directory.GetCurrentDirectory() + "\\Maili-con.png");
                logo.EndInit();
                im.Source = logo;
            }
            catch
            {

            }
        }


    }



    public static class slogo
    {
        public static void refresh()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = yet.ki.con;
            if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Tbl_Sirket";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                sir.name = reader["S_Kisa_Adi"].ToString();
                sir.lname = reader["S_Ticari_Adi"].ToString();
                sir.vno = reader["S_VNO"].ToString();
                sir.adress = reader["S_Adres"].ToString();
                sir.tel = reader["S_Tel"].ToString();
                sir.email = reader["S_Mail"].ToString();
                sir.web = reader["S_Web"].ToString();
                sir.logarray = (byte[])reader["S_Logo"];
                sir.epass = reader["S_MailPass"].ToString();
                sir.einter= reader["S_MailLoop"].ToString();
                sir.estop = reader["S_MailExit"].ToString();

            }

             if (con.State == ConnectionState.Open){con.Close();}
            MemoryStream strm = new MemoryStream();
            strm.Write(sir.logarray, 0, sir.logarray.Length);
            strm.Position = 0;
            System.Drawing.Image img = System.Drawing.Image.FromStream(strm);
            sir.ket = new BitmapImage();
            sir.ket.BeginInit();
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Seek(0, SeekOrigin.Begin);
            sir.ket.StreamSource = ms;
            sir.ket.EndInit();




        }









    }






}
