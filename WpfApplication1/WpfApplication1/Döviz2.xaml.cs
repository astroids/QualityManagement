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
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for  ARACLAR.xaml
    /// </summary>
    public partial class Döviz2 : MetroWindow
    {
        public Döviz2()
        {
            InitializeComponent();
            KaynakAl();
        }
        string kaynak;
        private void KaynakAl()
        {
            string adres = "http://www.tcmb.gov.tr/kurlar/today.html";
            WebResponse benimResponse = null;

            try
            {
                WebRequest wr = WebRequest.Create(adres);
                benimResponse = wr.GetResponse();
            }
            catch (WebException)
            {
                MessageBox.Show("İnternet bağlantınızı ve Güvenlik duvarı ayarlarını kontrol ediniz");
            }
            Stream str = benimResponse.GetResponseStream();

            StreamReader reader = new StreamReader(str);

            kaynak = reader.ReadToEnd();
            //mGetir();
        }

    }
      
}
