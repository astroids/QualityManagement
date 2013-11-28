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
using System.Net.Mail;
using System.Net;
namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for AAABOSKOPYALA.xaml
    /// </summary>
    public partial class Mail : MetroWindow
    {
        public Mail()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MailMessage mesaj = new MailMessage();
            mesaj.To.Add(TextboxKime.Text);
            mesaj.From = new MailAddress(TextboxMail.Text);
            mesaj.Body = TextboxMetin.Text;
            mesaj.Subject = TextboxBaslik.Text;
            SmtpClient cli = new SmtpClient();
            cli.EnableSsl = true;
            cli.Credentials = new NetworkCredential(TextboxMail.Text, TextboxSifre.Text);
            cli.Host = "murat_1992_51@hotmail.com";
           cli.Port = 576;
            cli.Send(mesaj);
        }
    }
}
