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
    /// Interaction logic for DokumanRapor.xaml
    /// </summary>
    public partial class DokumanRapor : MetroWindow
    {
        SqlConnection con = new SqlConnection();

        public DokumanRapor()
        {
            InitializeComponent();
            fillGrid();
        }

        void fillGrid()
        {
            try
            {
                con.ConnectionString = yet.ki.con;
                SqlCommand cmd = new SqlCommand();
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select d.DKM_id as 'Doküman ID', d.DKM_Adi as 'Doküman Adı',d.DKM_Baslik as 'Doküman Başlığı',t.DKMT_Adi as 'Doküman Tipi',DKM_Onay as 'Onay Durumu'  from Tbl_Dokuman d join  Tbl_Dokuman_Tipi t on d.DKM_Tip=t.DKMT_id where DKM_Onay <> 0";
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                p_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                 if (con.State == ConnectionState.Open){con.Close();}
                 logoS.Source = sir.ket;
                 sadi.Text = sir.lname;
                 stel.Text = sir.tel;
                 sweb.Text = sir.web;
                 semail.Text = sir.email;
                 sadres.Text = sir.adress;
            }
            catch
            {
                MessageBox.Show("Grid doldurma islemi sirasinda bir hata olustu");
                if (con.State == ConnectionState.Open) { con.Close(); }

            }






        }
    }
}
