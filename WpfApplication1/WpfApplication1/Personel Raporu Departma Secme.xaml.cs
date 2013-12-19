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
    /// Interaction logic for Personel_Raporu_Departma_Secme.xaml
    /// </summary>
    public partial class Personel_Raporu_Departma_Secme : MetroWindow
    {

        private SqlConnection con = new SqlConnection();
        public Personel_Raporu_Departma_Secme()
        {
            InitializeComponent();
            fillCombo();
        }

        private void fillCombo()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Tbl_Departman";
            cmd.Connection = con;
            con.ConnectionString = yet.ki.con;
            if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            adap.Fill(dt);
            departman.ItemsSource = dt.DefaultView;
            departman.DisplayMemberPath = "DPT_adi";
            departman.SelectedValuePath = "DPT_id";
             if (con.State == ConnectionState.Open){con.Close();}

        }
        private void depSec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string t = departman.SelectedValue.ToString();
            int se = Convert.ToInt32(t);
            PersonelDepartmanRapor rap = new PersonelDepartmanRapor(se);
            rap.Show();

        }

        private void tumu_Click(object sender, RoutedEventArgs e)
        {
            Personel_Raporu_Toplu rap = new Personel_Raporu_Toplu(1);
            rap.Show();
        }

        private void calisan_Click(object sender, RoutedEventArgs e)
        {
            Personel_Raporu_Toplu rap = new Personel_Raporu_Toplu(2);
            rap.Show();
        }

        private void adaylar_Click(object sender, RoutedEventArgs e)
        {
            Personel_Raporu_Toplu rap = new Personel_Raporu_Toplu(3);
            rap.Show();
        }





    }


}
