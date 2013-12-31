using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
using System.Drawing;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for ToplantiAlinanaKararlar.xaml
    /// </summary>
    public partial class ToplantiAlinanaKararlar : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        string tplid;
        public ToplantiAlinanaKararlar(string _id)
        {
            InitializeComponent();
            tplid = _id;
            fillName();
        }

        private void fillName()
        {
            try
            {
                con.ConnectionString = yet.ki.con;
                SqlCommand cmd = new SqlCommand();
                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select t.Tpl_Aciklama from Tbl_Toplanti t where t.Tpl_id=@tid";
                cmd.Parameters.AddWithValue("@tid", tplid); 
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TplAdi.Content = reader["Tpl_Aciklama"].ToString();
                }
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch
            {
                MessageBox.Show("İlgili Toplantı Bulunamadı");
                if (con.State == ConnectionState.Open) { con.Close(); }
            }

        }

        private void kaydet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.ConnectionString = yet.ki.con;
                SqlCommand cmd = new SqlCommand();
                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update  Tbl_Toplanti set Tpl_Yapilanlar =@yap where  Tpl_id = @tid";
                cmd.Parameters.AddWithValue("@yap", kararlar.Text);
                cmd.Parameters.AddWithValue("@tid",tplid);
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
                this.Close();
            }
            catch
            {
                MessageBox.Show("Toplantı Kaydı Başarısız");
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
        }









    }
}
