using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
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
    public static class sir
    {
        static public byte[] logarray
        {
            set;
            get;
        }
        static public BitmapImage ket
        {
            set;
            get;
        }
        static public string name
        {
            get;
            set;
        }
        static public string lname
        {
            set;
            get;
        }
        static public string adress
        {
            set;
            get;
        }
        static public string web
        {
            set;
            get;
        }
        static public string email
        {
            set;
            get;
        }
        static public string vno
        {
            set;
            get;
        }
        static public string tel
        {
            set;
            get;
        }

        
    }

    /// <summary>
    /// Interaction logic for SirketAyarlari.xaml
    /// </summary>
    public partial class SirketAyarlari : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        public SirketAyarlari()
        {
            InitializeComponent();
            fillall();


        }

        private void fillall()
        {
            try
            {
                adi.Text = sir.name;
                uadi.Text = sir.lname;
                vergi.Text = sir.vno;
                stel.Text = sir.tel;
                smail.Text = sir.email;
                sweb.Text = sir.web;
                logoIM.Source = sir.ket;
                sadresi.Text = sir.adress;
            }
            catch
            {
                MessageBox.Show("Doldurma Islemi Sirasinda Bir Hata Olustu");
            }
        }



        private void logo_Click(object sender, RoutedEventArgs e)
        {
                

                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.Title = "Select a picture";
                dlg.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                    "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                    "Portable Network Graphic (*.png)|*.png";
                if (dlg.ShowDialog() == true)
                {
                    try
                    {


                        FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);



                        sir.logarray = new byte[fs.Length];

                        fs.Read(sir.logarray, 0, System.Convert.ToInt32(fs.Length));

                        fs.Close();
                        con.ConnectionString = yet.ki.con;



                        logoIM.Source = new BitmapImage(new Uri(dlg.FileName));
                        sir.ket = new BitmapImage(new Uri(dlg.FileName));
                        if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "update Tbl_Sirket set S_Logo =@lo ";
                        cmd.Parameters.AddWithValue("@lo", sir.logarray);

                        cmd.ExecuteNonQuery();
                         if (con.State == ConnectionState.Open){con.Close();}
                    }
                    catch
                    {
                        MessageBox.Show("Logo Secimi Sirasinda Bir Hata Olustu");
                    }
                



                }


        }

        private byte[] ImageToByte(System.Drawing.Image img)
        {
            
            try
            {
                ImageConverter converter = new ImageConverter();
                return (byte[])converter.ConvertTo(img, typeof(byte[]));
            }
            catch (Exception) { throw; }
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow back = new MainWindow();
            back.Show();
            this.Close();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try{
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = yet.ki.con;
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Tbl_Sirket set S_Kisa_Adi = @ad;";
                cmd.Parameters.AddWithValue("@ad",adi.Text);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
            
                cmd.ExecuteNonQuery();
                 if (con.State == ConnectionState.Open){con.Close();}
                MessageBox.Show("Şirket Adı Başarıyla Değiştirildi");
            }catch{
                MessageBox.Show("Hatalı Girdi");
            }
        }

        private void uzunadi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = yet.ki.con;
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Tbl_Sirket set S_Ticari_Adi = @ad;";
                cmd.Parameters.AddWithValue("@ad", uadi.Text);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                cmd.ExecuteNonQuery();
                 if (con.State == ConnectionState.Open){con.Close();}
                MessageBox.Show("Şirket Ticari Adı Başarıyla Değiştirildi");
            }
            catch
            {
                MessageBox.Show("Hatalı Girdi");
            }
        }

        private void vergin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = yet.ki.con;
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Tbl_Sirket set S_VNo  = @ad;";
                cmd.Parameters.AddWithValue("@ad", vergi.Text);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                cmd.ExecuteNonQuery();
                 if (con.State == ConnectionState.Open){con.Close();}
                MessageBox.Show("Şirket Vergi Numarasi Başarıyla Değiştirildi");
            }
            catch
            {
                MessageBox.Show("Hatalı Girdi");
            }
        }

        private void vdeg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = yet.ki.con;
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Tbl_Sirket set S_Adres = @ad;";
                cmd.Parameters.AddWithValue("@ad", sadresi.Text);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                cmd.ExecuteNonQuery();
                 if (con.State == ConnectionState.Open){con.Close();}
                MessageBox.Show("Şirket Adresi Başarıyla Değiştirildi");
            }
            catch
            {
                MessageBox.Show("Hatalı Girdi");
            }
        }

        private void teldegistir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = yet.ki.con;
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Tbl_Sirket set S_Tel = @ad;";
                cmd.Parameters.AddWithValue("@ad", stel.Text);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                cmd.ExecuteNonQuery();
                 if (con.State == ConnectionState.Open){con.Close();}
                MessageBox.Show("Şirket Telefonu Başarıyla Değiştirildi");
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
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Tbl_Sirket set S_Mail= @ad;";
                cmd.Parameters.AddWithValue("@ad", smail.Text);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                cmd.ExecuteNonQuery();
                 if (con.State == ConnectionState.Open){con.Close();}
                MessageBox.Show("Şirket Emaili Başarıyla Değiştirildi");
            }
            catch
            {
                MessageBox.Show("Hatalı Girdi");
            }
        }

        
        private void webdegisitir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = yet.ki.con;
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Tbl_Sirket set S_Web= @ad;";
                cmd.Parameters.AddWithValue("@ad", sweb.Text);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                cmd.ExecuteNonQuery();
                 if (con.State == ConnectionState.Open){con.Close();}
                MessageBox.Show("Şirket Websitesi Başarıyla Değiştirildi");
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
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Tbl_Sirket set S_Mail= @ad;";
                cmd.Parameters.AddWithValue("@ad", smail.Text);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                cmd.ExecuteNonQuery();
                 if (con.State == ConnectionState.Open){con.Close();}
                MessageBox.Show("Şirket Emaili Başarıyla Değiştirildi");
            }
            catch
            {
                MessageBox.Show("Hatalı Girdi");
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = yet.ki.con;
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Tbl_Sirket set S_Mail= @ad;";
                cmd.Parameters.AddWithValue("@ad", smail.Text);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                cmd.ExecuteNonQuery();
                 if (con.State == ConnectionState.Open){con.Close();}
                MessageBox.Show("Şirket Emaili Başarıyla Değiştirildi");
            }
            catch
            {
                MessageBox.Show("Hatalı Girdi");
            }
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = yet.ki.con;
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Tbl_Sirket set S_Mail= @ad;";
                cmd.Parameters.AddWithValue("@ad", smail.Text);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                cmd.ExecuteNonQuery();
                 if (con.State == ConnectionState.Open){con.Close();}
                MessageBox.Show("Şirket Emaili Başarıyla Değiştirildi");
            }
            catch
            {
                MessageBox.Show("Hatalı Girdi");
            }
           
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = yet.ki.con;
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Tbl_Sirket set S_Mail= @ad;";
                cmd.Parameters.AddWithValue("@ad", smail.Text);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                cmd.ExecuteNonQuery();
                 if (con.State == ConnectionState.Open){con.Close();}
                MessageBox.Show("Şirket Emaili Başarıyla Değiştirildi");
            }
            catch
            {
                MessageBox.Show("Hatalı Girdi");
            }
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = yet.ki.con;
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Tbl_Sirket set S_Mail= @ad;";
                cmd.Parameters.AddWithValue("@ad", smail.Text);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                cmd.ExecuteNonQuery();
                 if (con.State == ConnectionState.Open){con.Close();}
                MessageBox.Show("Şirket Emaili Başarıyla Değiştirildi");
            }
            catch
            {
                MessageBox.Show("Hatalı Girdi");
            }
        }

        




    }
}
namespace yet
{
    static public class ki
    {
        static public int al
        {
            get;
            set;
        }
        static public int id
        {
            get;
            set;
        }
        static public string kulID
        {
            get;
            set;
        }
        static public string kulADI
        {
            set;
            get;
        }

        static public int yetki
        {
            set;
            get;
        }
        static public string kulAdi
        {
            set;
            get;
        }
        static public string ilksifre
        {
            set;
            get;
        }

        static public string con = "Server=ERSINBM-8; Database=Personel; Integrated Security=true;";
  



    }

}

namespace sel
{
    public static class ected
    {
        private static int idint;
        private static int everenDegistir;
        private static WpfApplication1.egitimEkleme openwindow;
        private static WpfApplication1.Wegitimincele openwindow2;
        private static WpfApplication1.WegitimDegistir eDegistir;//egitim degistir
        private static WpfApplication1.MainWindow mwin;
        private static WpfApplication1.ToplantiEkle tpl
        {
            set;
            get;
        }




        public static void setSelect(int i)
        {
            idint = i;
            openwindow.setEgitimVeren(idint);
            idint = 0;
        }
        public static void setDegistirEitim(int i)
        {
            everenDegistir = i;
            eDegistir.setEgitimVeren(everenDegistir);
            everenDegistir = 0;
        }
        public static void setOpenMain(WpfApplication1.MainWindow m)
        {
            mwin = m;
        }

        public static void mainClose()
        {
            mwin.Close();
        }

        //kullanılmıyor olabilir
        public static int getSelect()
        {
            return idint;
        }

        public static void addToToplani(int i)
        {
            tpl.baskaniSec(i);

        }



        public static void setOpenwindowTPL(WpfApplication1.ToplantiEkle t)
        {
            tpl = t;
        }


        public static void setOpenwindow2(WpfApplication1.Wegitimincele cur)
        {
            openwindow2 = cur;
        }

        public static void setOpenwindowED(WpfApplication1.WegitimDegistir cur)
        {
            eDegistir = cur;
        }


        public static void setOpenwindow(WpfApplication1.egitimEkleme cur)
        {
            openwindow = cur;
        }
        private static int idPers;
        public static void personel_ekle(int i)
        {
            idPers = i;
            openwindow2.setSelectedPers(idPers);


        }
        public static void personel_degistirEkle(int i)
        {
            idPers = i;
            eDegistir.setSelectedPers(idPers);                        //fonksiyon ekle
        }

        public static void personel_Degistirekle(int i)
        {
            idPers = i;
            eDegistir.setSelectedPers(idPers);


        }


    }
}