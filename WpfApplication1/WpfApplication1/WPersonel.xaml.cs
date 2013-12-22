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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for WPersonelcs.xaml
    /// </summary>
    public partial class WPersonel : MetroWindow
    {

        public WPersonel()
        {
            InitializeComponent();
            if (yet.ki.al == 0)
            {
                PersIs.IsEnabled = false;
            }
            im.Source = sir.ket;

        }


        private void PersIs_Button_Click(object sender, RoutedEventArgs e)
        {

            PersonelAraMenu ek = new PersonelAraMenu(this);
            ek.Show();
            //this.Hide();

            //SqlCommand cmd = new SqlCommand();
            //con.Open();
            //cmd.Connection = con;
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "Select * From Tbl_Personel p Where p.P_id = @id";
            //cmd.Parameters.AddWithValue("@id", selectedID);
            //SqlDataAdapter adap = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adap.Fill(dt);
            //cmd.ExecuteNonQuery();
            //con.Close();

        }

        private void persegButton_Click(object sender, RoutedEventArgs e)
        {
            PersonelEkleSil eg = new PersonelEkleSil(3);
            eg.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PersonelEkleSil pr = new PersonelEkleSil(10);
           
          pr.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            PersonelEkleSil pe = new PersonelEkleSil(12);
            pe.Show();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow bac = new MainWindow();
            bac.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PersonelEkleSil pr = new PersonelEkleSil(13);

            pr.Show();
        }

        private void edeger_Click(object sender, RoutedEventArgs e)
        {
            EgitimDegerlendirme ed = new EgitimDegerlendirme();
            ed.Show();
        }

    }
}
