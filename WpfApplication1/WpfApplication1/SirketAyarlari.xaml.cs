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



        }

        private void fillall()
        {
            adi.Text = sir.name;
            uadi.Text = sir.lname;
            vergi.Text = sir.vno;
            stel.Text = sir.tel;
            smail.Text = sir.email;
            sweb.Text = sir.web;
            logoIM.Source = sir.ket;

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



                    FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);



                    sir.logarray = new byte[fs.Length];

                    fs.Read(sir.logarray, 0, System.Convert.ToInt32(fs.Length));

                    fs.Close();
                    con.ConnectionString = "Server=ERSINBM-8; Database=Personel; Integrated Security=true;";



                    logoIM.Source = new BitmapImage(new Uri(dlg.FileName));
                    sir.ket = new BitmapImage(new Uri(dlg.FileName));
                    con.Open();
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update Tbl_Sirket set S_Logo =@lo ";
                    cmd.Parameters.AddWithValue("@lo", sir.logarray);

                    cmd.ExecuteNonQuery();
                    con.Close();



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


    }
}
