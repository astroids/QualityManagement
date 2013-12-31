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
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for DokumanArsiv.xaml
    /// </summary>
    public partial class DokumanArsiv : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        public DokumanArsiv()
        {
            InitializeComponent();
            con.ConnectionString = yet.ki.con;
            fillgrid();
        }
        void fillgrid()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SPDokumanArsiv";
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                p_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch
            {
                MessageBox.Show("Doldurma İşlemi Sırasında Bir Hata Oluştu");
                if (con.State == ConnectionState.Open) { con.Close(); }

            }

        }



    }
}
