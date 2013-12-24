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
using System.Drawing;
using System.IO;
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
        private string selected_personel { set; get; }
        System.Net.Mail.Attachment attachment;
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
            port = 587;
            sunucu = "smtp.live.com";
            fillCombo();
            fillGrid();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                kmail = sir.email;
                ksifre = sir.epass;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(sunucu);
                mail.From = new MailAddress(kmail);
                mail.To.Add(selected_personel);
                if (attach == true)
                {
                    try
                    {
                        attachment = new System.Net.Mail.Attachment(yol);
                        mail.Attachments.Add(attachment);
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
                SmtpServer.Credentials = new System.Net.NetworkCredential(kmail, ksifre);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Mail başarıyla gönderildi.");
                if (attach == true)
                {
                    attachment.Dispose();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mesajınız gönderilmedi.\nHata raporu: " + ex.ToString());
                attachment.Dispose();

            }
          

        }

        void listele(string tip)
        {
            try
            {

                SqlCommand cmd = new SqlCommand();
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.CommandType = CommandType.Text;

                {


                    cmd.Connection = con; cmd.CommandText = "select *  from Tbl_Personel where P_id=@pid";
                    cmd.Parameters.AddWithValue("@pid", tip);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        yollancakMailAdresi = reader["P_Email"].ToString();
                        selected_personel = yollancakMailAdresi;
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
       
       
        







        private void fillGrid()
        {

            try
            {
                SqlCommand cmd = new SqlCommand();
                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SPgetAllDok";
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                p_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch
            {
                MessageBox.Show("Listeleme Islemi Sirasinda Bir Hata Olustu");
            }

        }

        private void sec_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = p_grid.SelectedItem;
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                string text = txtBody.Text + "";
                DokumanYazdir doc = new DokumanYazdir(Convert.ToInt32(ID));
                doc.Show();
                yol = Directory.GetCurrentDirectory() + "\\doc.xps";
                attach = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Personel_Raporu_Departma_Secme sec = new Personel_Raporu_Departma_Secme();
                sec.Show();
                yol = Directory.GetCurrentDirectory() + "\\doc.xps";
                attach = true;
            }
            catch
            {
                MessageBox.Show("Personel Raporu Yüklenirken Bir Hata Oluştu");
            }
        }

    }
}
