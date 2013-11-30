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
    /// Interaction logic for Araclar.xaml
    /// </summary>
    public partial class Araclar: MetroWindow
    {
        int i = 1;
        public Araclar()
        {
            InitializeComponent();
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string exeyolu = "calc.exe";
            
            Process calistir = Process.Start(exeyolu);
         /*   while (calistir.MainWindowHandle == IntPtr.Zero || !IsWindowvisible(calistir.MainWindowHandle)) {

                System.Threading.Thread.Sleep(10);
                calistir.Refresh();
            
            }
           
            calistir.WaitForInputIdle();
          SetParent(calistir.MainWindowHandle, this.panell.AddHandler();*/
           SendMessage(calistir.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string exeyolu2 = "notepad.exe";
            Process calistir = Process.Start(exeyolu2);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get DatePicker reference.
            var picker = sender as DatePicker;

            // ... Get nullable DateTime from SelectedDate.
            DateTime? date = picker.SelectedDate;
            if (date == null)
            {
                // ... A null object.
                this.Title = "No date";
            }
            else
            {
                // ... No need to display the time.
                this.Title = date.Value.ToShortDateString();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            i++;
            if (i % 2 == 0)
            {
                takvim.Visibility = Visibility.Visible;
            }
            if (i == 10)
            {
                i = 0;
            }
            if (i % 2 == 1)
            {
                takvim.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Mail ml = new Mail();
            ml.Show();
        }

    }
}
