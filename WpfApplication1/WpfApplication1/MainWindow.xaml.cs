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
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;


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



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Toplanti topl = new Toplanti();
            topl.Show();
            this.Close();
        }

        private void dokuman_Click_1(object sender, RoutedEventArgs e)
        {
            Dokum.IsSelected = true;
        }


        private void ayarlar_Click(object sender, RoutedEventArgs e)
        {
            sayar.IsSelected = true;
        }

        private void araclar_Click(object sender, RoutedEventArgs e)
        {
            arac.IsSelected = true;
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {

                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri("/personel.png", UriKind.Relative);
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
                logo.UriSource = new Uri("/meet.png", UriKind.Relative);
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
                logo.UriSource = new Uri("/Document-icon.png", UriKind.Relative);
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
                logo.UriSource = new Uri("/Settings-icon.png", UriKind.Relative);
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
                logo.UriSource = new Uri("/Maili-con.png", UriKind.Relative);
                logo.EndInit();
                im.Source = logo;
            }
            catch
            {

            }
        }
        /// <summary>
        /// DOKUMAN 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dokumanIslem_Click(object sender, RoutedEventArgs e)
        {
            DokumanListesi lst = new DokumanListesi();
            lst.Show();

        }

        private void revizyon_Click(object sender, RoutedEventArgs e)
        {
            DokumanRevizyon rev = new DokumanRevizyon();
            rev.Show();

        }

        private void geridon_Click_1(object sender, RoutedEventArgs e)
        {
            mainw.IsSelected = true;
            im.Source = sir.ket;
        }

        private void onay_Click(object sender, RoutedEventArgs e)
        {
            DokumanOnayxaml on = new DokumanOnayxaml();
            on.Show();
        }


        ///Sirket Ayarlar
        ///
        private void sirket_Click(object sender, RoutedEventArgs e)
        {
            SirketAyarlari sir = new SirketAyarlari();
            sir.Show();
            this.Close();
        }

        private void dep_Click(object sender, RoutedEventArgs e)
        {

            Departman dd = new Departman();
            dd.Show();
            this.Hide();
        }

        private void sifre_Click(object sender, RoutedEventArgs e)
        {
            Sifre sfr = new Sifre();
            sfr.Show();
        }

        private void un3_Click(object sender, RoutedEventArgs e)
        {
            MailAyarlama ma = new MailAyarlama();
            ma.Show();

        }

        private void dsizin_Click(object sender, RoutedEventArgs e)
        {
            DosyaİzinTipiEkle ek = new DosyaİzinTipiEkle();
            ek.Show();
        }

        private void gerime_Click(object sender, RoutedEventArgs e)
        {
            mainw.IsSelected = true;
            im.Source = sir.ket;
        }

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr child, IntPtr newParent);
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, int Wparam, int lParam);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowvisible(IntPtr hWnd);
        private const int WM_SYSCOMMAND = 274;
        private const int SC_MAXIMIZE = 61488;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Döviz2 dv = new Döviz2();
            dv.Show();
        }

        private void calcu_Click_1(object sender, RoutedEventArgs e)
        {
            string exeyolu = "calc.exe";

            Process calistir = Process.Start(exeyolu);
            SendMessage(calistir.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0);
        }

        private void npad_Click_2(object sender, RoutedEventArgs e)
        {
            string exeyolu2 = "notepad.exe";
            Process calistir = Process.Start(exeyolu2);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;

            DateTime? date = picker.SelectedDate;
            if (date == null)
            {
                this.Title = "No date";
            }
            else
            {
                this.Title = date.Value.ToShortDateString();
            }
        }


        private void email_Click_4(object sender, RoutedEventArgs e)
        {
            Mail ml = new Mail();
            ml.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            mainw.IsSelected = true;
            im.Source = sir.ket;
        }

        private void arsiv_Click(object sender, RoutedEventArgs e)
        {
            DokumanArsiv ar = new DokumanArsiv();
            ar.Show();
        }



    }



    public static class slogo
    {
        public static void refresh()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = yet.ki.con;
                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
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
                    sir.einter = reader["S_MailLoop"].ToString();
                    sir.estop = reader["S_MailExit"].ToString();

                }

                if (con.State == ConnectionState.Open) { con.Close(); }
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
            catch
            {
                MessageBox.Show("Yenileme İşlemi Sırasında Bir Hata Oluştu");
            }




        }









    }






}
