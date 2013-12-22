using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Threading;
using MahApps.Metro.Controls;
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
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
namespace WpfApplication1
{

    public partial class Mail : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        private string yollancakMailAdresi;
        string sunucu, kmail, ksifre;
        int port;
      private  bool attach = false;
        private string yol;

        void fillCombo()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Personel";
                cmd.Connection = con;
                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                DataTable dt = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);

                adap.Fill(dt);
                personelSec.ItemsSource = dt.DefaultView;
                personelSec.DisplayMemberPath = "P_Adi";
                personelSec.SelectedValuePath = "P_id";
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            
            catch
            {
                MessageBox.Show("Doldurma Islemi Sirasinda Bir Hata Oluştu");
            }


        }


        public Mail()
        {
            InitializeComponent();
            con.ConnectionString = yet.ki.con;
            //listele(null);
            fillCombo();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                kmail = txtUserName.Text;
                ksifre = txtPassword.Password;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(sunucu);
                mail.From = new MailAddress(kmail);
                mail.To.Add(txtTo.Text);
                if (attach == true)
                {
                    try
                    {
                        System.Net.Mail.Attachment attachment;
                        attachment = new System.Net.Mail.Attachment(yol);//Attachment yerini belirleme.
                        mail.Attachments.Add(attachment);//maile attachment ekleme
                        MessageBox.Show("Dosya basarıyla eklendi...");
                    }
                   
                    catch
            {
                MessageBox.Show("Dosya Ekleme Sirasinda Bir Hata Oluştu");
            }
                    
                }
                mail.Subject = txtSubject.Text;
                mail.Body = txtBody.Text;

                SmtpServer.Port = port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(kmail, ksifre);//kullanıcı adı ve şifre bilgilerinin girilimi.
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Mail başarıyla gönderildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mesajınız gönderilmedi.\nHata raporu: " + ex.ToString());
            }
          

        }

        void listele(string tip)
        {
            try
            {

                SqlCommand cmd = new SqlCommand();
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.CommandType = CommandType.Text;
                //if (tip == null)
                //{

                //    cmd.CommandText = "select d.DKM_id as 'Doküman ID', d.DKM_Adi as 'Doküman Adı',d.DKM_Baslik as 'Doküman Başlığı',t.DKMT_Adi as 'Doküman Tipi'  from Tbl_Dokuman d join  Tbl_Dokuman_Tipi t on d.DKM_Tip=t.DKMT_id";
                //}
                //else
                {


                    cmd.Connection = con; cmd.CommandText = "select *  from Tbl_Personel where P_id=@pid";
                    cmd.Parameters.AddWithValue("@pid", tip);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        yollancakMailAdresi = reader["P_Email"].ToString();
                        if (checkPer.IsChecked == true)
                        {
                            txtTo.Text = yollancakMailAdresi;
                        }
                        // pkime.Text = " " + reader["P_Soyadi"].ToString();
                    }
                }

                 if (con.State == ConnectionState.Open){con.Close();}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                 if (con.State == ConnectionState.Open){con.Close();}
            }

        }


        private void personelSec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string t = personelSec.SelectedValue.ToString();
            listele(t);
        }
       
       
        

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (checkPer.IsChecked == true)
            {
                checkPer.Visibility = Visibility.Hidden;
                personeller.Visibility = Visibility.Visible;
                personelSec.Visibility = Visibility.Visible;
               
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.IsSelected == true)
            {
                port = 587;
                sunucu = "smtp.gmail.com";
            }
            if (comboBox2.IsSelected== true)
            {
                port = 587;
                sunucu = "smtp.live.com";
            }
        }

        private void txtBody_TextChanged(object sender, TextChangedEventArgs e)
        {

          /*  if (e.Key == Key.Enter')
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }*/
        }

        private void dosya_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog attachments = new Microsoft.Win32.OpenFileDialog();
            if (attachments.ShowDialog() == true)

            {
                attach = true;
                yol = attachments.FileName;
            }
        }
    }
}
