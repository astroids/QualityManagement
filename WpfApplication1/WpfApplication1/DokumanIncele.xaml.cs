using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
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


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for DokumanIncele.xaml
    /// </summary>
    public partial class DokumanIncele : MetroWindow
    {
        private int docid{
            get;
            set;
        }
        public DokumanIncele(int id)
        {
            InitializeComponent();
            docid = id;
            fill();
        }
        private void fill()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = yet.ki.con;
            try
            {
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SPgetDocIDincele @did";
            cmd.Parameters.AddWithValue("@did",docid);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id.Text = reader["id"].ToString();
                adi.Text = reader["dadı"].ToString();
                rev.Text = reader["rev"].ToString();
                acik.Text = reader["açık"].ToString();
                dtip.Text = reader["dtip"].ToString();
                dep.Text = reader["ddep"].ToString();
                baslik.Text = reader["baslik"].ToString();
                icerik.Text = reader["icer"].ToString();
                tarih.Text = reader["tar"].ToString();
                hadi.Text = reader["hazper"].ToString();
                hsadi.Text = reader["hazsoy"].ToString();
                oadi.Text = reader["oper"].ToString();
                osadi.Text = reader["osoy"].ToString();
                hdep.Text = reader["odep"].ToString();
                hopoz.Text = reader["hpoz"].ToString();
                odep.Text = reader["odep"].ToString();
                opoz.Text = reader["opoz"].ToString();

            }
            con.Close();
            }
            catch
            {
                MessageBox.Show("Doldurma Sirasinda Bir Hata Oluştu");
            }

        }

        private void yazdir_Click(object sender, RoutedEventArgs e)
        {
            DokumanYazdir doc = new DokumanYazdir(docid);
            doc.Show();
        }




    }
}
