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

namespace WpfApplication1
{

    public partial class Mail : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        private string yollancakMailAdresi;
        public string From = string.Empty;
        public string To = string.Empty;
        public string User = string.Empty;
        public string Password = string.Empty;
        public string Subject = string.Empty;
        public string Body = string.Empty;
        public string AttachmentPath = string.Empty;
        public string Host = "127.0.0.1";
        public int Port = 25;
        public string CC = string.Empty;
        public bool IsHtml = false;
        public int SendUsing = 0;//0 = Network, 1 = PickupDirectory, 2 = SpecifiedPickupDirectory
        public bool UseSSL = true;
        public int AuthenticationMode = 1;//0 = No authentication, 1 = Plain Text, 2 = NTLM authentication

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
        
            Mail wpfEmailer = new Mail();
            wpfEmailer.User = txtUserName.Text;
            wpfEmailer.Password = txtPassword.Password;
            wpfEmailer.From = txtUserName.Text;
            wpfEmailer.To = txtTo.Text;
            //  wpfEmailer.Host = txtSMTPServerName.Text;
            //wpfEmailer.Port = 25;
            wpfEmailer.Subject = txtSubject.Text;
            wpfEmailer.Body = txtBody.Text;
            try
            {
                MessageBox.Show("Mailiniz gönderiliyor...");
                wpfEmailer.SendEmail();
                MessageBox.Show("Mailiniz basariyla gönderildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
                if (con.State == ConnectionState.Open) { con.Close(); }

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
        public void SendEmail()
        {
            new Thread(new ThreadStart(SendMessage)).Start();
        }
        /// <summary>
        /// Send Email Message method.
        /// </summary>
        private void SendMessage()
        {
            try
            {
                MailMessage oMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient(Host);

                oMessage.From = new MailAddress(From);
                oMessage.To.Add(To);
                oMessage.Subject = Subject;
                oMessage.IsBodyHtml = IsHtml;
                oMessage.Body = Body;

                if (CC != string.Empty)
                    oMessage.CC.Add(CC);

                switch (SendUsing)
                {
                    case 0:
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        break;
                    case 1:
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                        break;
                    case 2:
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                        break;
                    default:
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        break;

                }
                if (AuthenticationMode > 0)
                {
                    smtpClient.Credentials = new NetworkCredential(User, Password);
                }

                smtpClient.Port = Port;
                smtpClient.EnableSsl = UseSSL;

                // Create and add the attachment
                if (AttachmentPath != string.Empty)
                {
                    oMessage.Attachments.Add(new Attachment(AttachmentPath));
                }

                try
                {
                    // Deliver the message  

                    smtpClient.Send(oMessage);

                }

                catch (Exception ex)
                {
                    ex.ToString();

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
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
    }
}
