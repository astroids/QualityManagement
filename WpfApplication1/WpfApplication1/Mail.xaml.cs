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
  
    public partial class Mail : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        private string yollancakMailAdresi;
        private string selectedPersonel;

        void fillCombo()
        {
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Tbl_Personel";
            cmd.Connection = con;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
           
            adap.Fill(dt);
            personelSec.ItemsSource = dt.DefaultView;
            personelSec.DisplayMemberPath = "P_Adi";
            personelSec.SelectedValuePath = "P_id";
            con.Close();

        }


        public Mail()
        {
            InitializeComponent();
            con.ConnectionString = "Server=MURAT-HP; Database=Personel; Integrated Security=true;";
            //listele(null);
            fillCombo();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Kime.Text = selectedPersonel;
            MailMessage MyMailMessage = new MailMessage(Gonderen.Text, yollancakMailAdresi, Baslik.Text, Metin.Text);

            MyMailMessage.IsBodyHtml = false;

            NetworkCredential mailAuthentication = new NetworkCredential(Gonderen.Text, sifre.Password);

            SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);

            mailClient.EnableSsl = false;

            mailClient.UseDefaultCredentials = false;

            mailClient.Credentials = mailAuthentication;


            try
            {
                MessageBox.Show("Mailiniz gönderiliyor.......");
                mailClient.Send(MyMailMessage);
                MessageBox.Show("Mailiniz gönderildi");

            }
            catch (Exception exp)
            {

                MessageBox.Show("Mailiniz gönderilemedi" + exp.Message);
            }


        }

        void listele(string tip)
        {
            try
            {

                SqlCommand cmd = new SqlCommand();
                con.Open();
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
                        pkime.Text = yollancakMailAdresi;
                       // pkime.Text = " " + reader["P_Soyadi"].ToString();
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }

        }


        private void personelSec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string t = personelSec.SelectedValue.ToString();
            listele(t);
        }
    }
}
