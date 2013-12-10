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
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DokumanRevizyon rev = new DokumanRevizyon();
            rev.Show();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow bac = new MainWindow();
            this.Close();
            bac.Show();
        }
    }
}
