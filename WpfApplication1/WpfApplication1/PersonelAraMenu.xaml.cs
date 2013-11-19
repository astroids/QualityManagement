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
    /// Interaction logic for AAABOSKOPYALA.xaml
    /// </summary>
    public partial class PersonelAraMenu : MetroWindow
    {
       
        private static WPersonel parent;
        public PersonelAraMenu(WPersonel pe)
        {
            InitializeComponent();
            parent = pe;
            this.Closing += ara_closing;
        }

        private void kayit_Button_Click(object sender, RoutedEventArgs e)
        {
           
            PersonelEkleSil ek = new PersonelEkleSil(1);
            ek.Show();

        }
        private static void ara_closing(object sender, CancelEventArgs e){
            parent.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PersonelEkleSil ek = new PersonelEkleSil(2);
            ek.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PersonelEkleSil ek = new PersonelEkleSil(9);
            ek.Show();
        }
    }
}
