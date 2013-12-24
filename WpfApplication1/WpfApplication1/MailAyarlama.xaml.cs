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
using System.Collections;
using System.ComponentModel;
using System.Windows.Xps.Packaging;
using System.IO;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MailAyarlama.xaml
    /// </summary>
    public partial class MailAyarlama : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        public MailAyarlama()
        {
            InitializeComponent();
            con.ConnectionString = yet.ki.con;
            fillCombo();
        }

        private void fillCombo()
        {
            mailad.Text = sir.email;
            mailpass.Text = sir.epass;
            mailinter.Text = sir.einter;
            mailkapa.Text = sir.estop;

        }

        private void depKaydet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Tbl_Sirket set S_Mail=@mail , S_MailPass =@pass,S_MailLoop =@loop,S_MailExit = @stop where S_id=1001";
                cmd.Parameters.AddWithValue("@mail", mailad.Text);
                cmd.Parameters.AddWithValue("@pass", mailpass.Text);
                cmd.Parameters.AddWithValue("@loop", mailinter.Text);
                cmd.Parameters.AddWithValue("@stop", mailkapa.Text);

                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
                MessageBox.Show("Kayıt Başarılı");
                sir.email = mailad.Text;
                sir.epass = mailpass.Text;
                sir.einter = mailinter.Text;
                sir.estop = mailkapa.Text;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt Hatası"+ ex.ToString());
                if (con.State == ConnectionState.Open) { con.Close(); }

            }
        }


    }
}
