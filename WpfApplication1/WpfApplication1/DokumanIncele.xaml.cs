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

        private string parent
        {
            set;
            get;
        }
        private string child
        {
            set;
            get;
        }
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
            if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
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
                child = reader["child"].ToString();
                parent = reader["parent"].ToString();
                acik.Text = reader["açık"].ToString();
                dtip.Text = reader["dtip"].ToString();
                dep.Text = reader["ddep"].ToString();
                baslik.Text = reader["baslik"].ToString();
                icerik.Text = reader["icer"].ToString();
                tarih.Text = reader["tar"].ToString();
                hadi.Text = reader["hazper"].ToString();
                oadi.Text = reader["oper"].ToString();
                hdep.Text = reader["odep"].ToString();
                hopoz.Text = reader["hpoz"].ToString();
                odep.Text = reader["odep"].ToString();
                opoz.Text = reader["opoz"].ToString();

            }
             if (con.State == ConnectionState.Open){con.Close();}
            if (parent =="")
            {
                onceki.IsEnabled = false;
            }else{
                onceki.IsEnabled=true;
            }
            if (child == "")
            {
                sonraki.IsEnabled = false;
            }else{
                sonraki.IsEnabled=true;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //MessageBox.Show("Doldurma Sirasinda Bir Hata Oluştu");
            }

        }

        private void yazdir_Click(object sender, RoutedEventArgs e)
        {
            DokumanYazdir doc = new DokumanYazdir(docid);
            doc.Show();
        }

        private void onceki_Click(object sender, RoutedEventArgs e)
        {
            docid =Convert.ToInt32(parent);
            fill();
        }

        private void sonraki_Click(object sender, RoutedEventArgs e)
        {
            docid = Convert.ToInt32(child);
            fill();
        }




    }
}
