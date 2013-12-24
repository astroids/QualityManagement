using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Markup;
using System.Timers;
namespace Mail
{
    public class sirket
    {
        private static SqlConnection con = new SqlConnection();
        private static string yollancakMailAdres
        {
            set;
            get;
        }
        private static string sunucu, kmail, ksifre;
        private static int port;
        private static string did;
        private static string pid;
        private static string pmail;
        private static string dadi;
        private static string icerik;
        private static string tar;
        private static string yer;
        private static System.Timers.Timer testTimer = new System.Timers.Timer(600);
        private static int ltime;
        private static bool lexit;
        sirket inst = new sirket();

        private static void sirketBilgileri()
        {
            port = 587;
            sunucu = "smtp.live.com";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=NAGASH; Database=Personel; Integrated Security=true;";
            if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Tbl_Sirket";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                sir.name = reader["S_Kisa_Adi"].ToString();
                sir.lname = reader["S_Ticari_Adi"].ToString();
                sir.vno = reader["S_VNO"].ToString();
                sir.adress = reader["S_Adres"].ToString();
                sir.tel = reader["S_Tel"].ToString();
                sir.email = reader["S_Mail"].ToString();
                sir.web = reader["S_Web"].ToString();
                sir.logarray = (byte[])reader["S_Logo"];
                sir.epass = reader["S_MailPass"].ToString();


            }

            if (con.State == ConnectionState.Open) { con.Close(); }
            MemoryStream strm = new MemoryStream();
            strm.Write(sir.logarray, 0, sir.logarray.Length);
            strm.Position = 0;
            System.Drawing.Image img = System.Drawing.Image.FromStream(strm);
            sir.ket = new BitmapImage();
            sir.ket.BeginInit();
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Seek(0, SeekOrigin.Begin);
            sir.ket.StreamSource = ms;
            sir.ket.EndInit();
        }

        private static void dokuman()
        {
            con = new SqlConnection();
            con.ConnectionString = "Server=NAGASH; Database=Personel; Integrated Security=true;";
            SqlCommand cmd = new SqlCommand();
            if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SPmail";
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            if (con.State == ConnectionState.Open) { con.Close(); }
            foreach (DataRow DRow in dt.Rows)
            {
                did = DRow["did"].ToString();
                pid = DRow["pid"].ToString();
                pmail = DRow["email"].ToString();
                dadi = DRow["dadi"].ToString();
                icerik =DRow["icerik"].ToString();
                sendDMail();

            }



        }
        private static void toplanti()
        {
            con = new SqlConnection();
            con.ConnectionString = "Server=NAGASH; Database=Personel; Integrated Security=true;";
            SqlCommand cmd = new SqlCommand();
            if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SPTplMail";
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            if (con.State == ConnectionState.Open) { con.Close(); }
            foreach (DataRow DRow in dt.Rows)
            {
                did = DRow["tid"].ToString();
                pid = DRow["pid"].ToString();
                pmail = DRow["email"].ToString();
                dadi = DRow["tadi"].ToString();
                icerik = DRow["icerik"].ToString();
                tar = DRow["tar"].ToString();
                yer = DRow["yer"].ToString();
                sendTMail();

            }



        }

        private static void dokSifirla()
        {
            con = new SqlConnection();
            con.ConnectionString = "Server=NAGASH; Database=Personel; Integrated Security=true;";
            SqlCommand cmd = new SqlCommand();
            if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Tbl_Dokuman_Dagitim set DKMD_mail =0 where DKMD_id = @did and DKMD_personel =@pid";
            cmd.Parameters.AddWithValue("@did", did);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.ExecuteNonQuery();
            if (con.State == ConnectionState.Open) { con.Close(); }


        }



        private static void sendDMail()
        {
            try
            {
                kmail = sir.email;
                ksifre = sir.epass;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(sunucu);
                mail.From = new MailAddress(kmail);
                mail.To.Add(pmail);
                mail.Subject = dadi;
                mail.Body = icerik;

                SmtpServer.Port = port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(kmail, ksifre);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                Console.WriteLine("Dokuman Maili Yollandi ->"+ pmail);
                dokSifirla();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mail Yollanamadı" + ex.ToString());
            }
        }

        private static void sendTMail()
        {
            try
            {
                kmail = sir.email;
                ksifre = sir.epass;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(sunucu);
                mail.From = new MailAddress(kmail);
                mail.To.Add(pmail);
                mail.Subject = dadi;
                mail.Body ="Toplantı Bilgilendirme\n"+tar+ "  tarihinde\n"+yer+" Toplatı Salonunda\n" +dadi+"\n\n" + icerik;

                SmtpServer.Port = port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(kmail, ksifre);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                Console.WriteLine("Toplanti Maili Yollandi ->" + pmail);
                dokSifirla();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mail Yollanamadı" + ex.ToString());
            }
        }
        private static void getloop()
        {
            con = new SqlConnection();
            con.ConnectionString = "Server=NAGASH; Database=Personel; Integrated Security=true;";
            SqlCommand cmd = new SqlCommand();
            if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SPMloop";
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            if (con.State == ConnectionState.Open) { con.Close(); }
            foreach (DataRow DRow in dt.Rows)
            {
                ltime = Convert.ToInt32( DRow["loop"].ToString());
                testTimer.Interval = ltime;
                lexit = Convert.ToBoolean(DRow["exit"].ToString());

            }
        }

        private static void stdloop()
        {
            System.Threading.Thread.Sleep(ltime);
            getloop();
            dokuman();
            toplanti();
            if (!lexit)
            {
                Environment.Exit(0);
            }
        }





        static void Main(string[] args)
        {
            sirketBilgileri();
            Console.WriteLine("Sunucu Baglantisi Var");
            stdloop();
            Console.WriteLine("Exit");
            Console.ReadLine();

        }
    }
}
public static class sir
{
    static public byte[] logarray
    {
        set;
        get;
    }
    static public BitmapImage ket
    {
        set;
        get;
    }
    static public string name
    {
        get;
        set;
    }
    static public string lname
    {
        set;
        get;
    }
    static public string adress
    {
        set;
        get;
    }
    static public string web
    {
        set;
        get;
    }
    static public string email
    {
        set;
        get;
    }
    static public string vno
    {
        set;
        get;
    }
    static public string tel
    {
        set;
        get;
    }
    static public string epass
    {
        set;
        get;
    }

}