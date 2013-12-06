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
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for EgitimRaporToplu.xaml
    /// </summary>
    public partial class EgitimRaporToplu : MetroWindow
    {
        public EgitimRaporToplu()
        {
            InitializeComponent();
            fill();
        }
        private void fill()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = yet.ki.con; 
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select E_id as 'id', e.E_Adi as 'Egitim Adı',e.E_BasTarih as 'Başlangış tarihi', e.E_BitTarih as 'Bitiş Tarihi',p.P_Adi as 'Egitim Veren',p.P_Soyadi as 'soyadı' from Tbl_Egitim e, Tbl_Personel p where e.E_Egi_Veren=p.P_id";

            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            p_grid.ItemsSource = null;
            p_grid.ItemsSource = dt.DefaultView;
            cmd.ExecuteNonQuery();
            con.Close();
            logoS.Source = sir.ket;
            sadi.Text = sir.lname;
            stel.Text = sir.tel;
            sweb.Text = sir.web;
            semail.Text = sir.email;
            sadres.Text = sir.adress;

        }


    }
}
