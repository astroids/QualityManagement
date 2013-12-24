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
    /// Interaction logic for AYARLAR.xaml
    /// </summary>
    public partial class AYARLAR : MetroWindow
    {
        public AYARLAR()
        {
            InitializeComponent();
            if (yet.ki.yetki == 2) {
                sirket.IsEnabled = false;
            }
        }

        private void sirket_Click(object sender, RoutedEventArgs e)
        {
            SirketAyarlari sir = new SirketAyarlari();
            sir.Show();
            sel.ected.mainClose();
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

        }
    }
}
