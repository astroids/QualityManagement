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
            mGetir();
        }

        private void mGetir()
        {
            try
            {
                string starting_marker = "USD/TRY";
                string ending_marker = "USD/PKR";
                int starting_index = 0;
                int ending_index = 0;
                for (int i = 0; i < kaynak.Length - starting_marker.Length; i++)
                {
                    if (kaynak.Substring(i, starting_marker.Length) == starting_marker)
                    {
                        starting_index = i;
                        break;
                    }
                }
                for (int i = starting_index; i < kaynak.Length - ending_marker.Length; i++)
                {
                    if (kaynak.Substring(i, ending_marker.Length) == ending_marker)
                    {
                        ending_index = i - 1;
                        break;
                    }
                }
                string meaningful_string = kaynak.Substring(starting_index, ending_index - starting_index);
                char[] seperators = { ' ', '\n' };
                string[] splitted_string = meaningful_string.Split(seperators);
                List<string> meaningful_strings = new List<string>();
                for (int i = 0; i < splitted_string.Length; i++)
                {
                    if (splitted_string[i] != "")
                    {
                        meaningful_strings.Add(splitted_string[i]);
                    }
                }
                lblUsd.Content = meaningful_strings[2] + " " + meaningful_strings[3];
                lbldolar.Content = meaningful_strings[4];
                lbldolars.Content = meaningful_strings[5];
                lblEuro.Content = meaningful_strings[26];
                lbleuro.Content = meaningful_strings[27];
                lbleuros.Content = meaningful_strings[28];
                lblsterlin.Content = "STERLİN";
                lblstrlin.Content = meaningful_strings[35];
                lblstrlins.Content = meaningful_strings[36];
                lblfrang.Content = meaningful_strings[43];
                lblfrangs.Content = meaningful_strings[44];
                lblriyal.Content = meaningful_strings[84];
                lblriyals.Content = meaningful_strings[85];
                lblkur1.Content = meaningful_strings[155];
                lblkur3.Content = meaningful_strings[190];
                lblkur2.Content = meaningful_strings[197];
                lblkur4.Content = meaningful_strings[204];
            }
            catch
            {
                MessageBox.Show("Doviz islemleri getirilirken bir hata olustu");
            }
            
        }


    }
}
