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
    /// Interaction logic for PersonelSelector.xaml
    /// </summary>
    public partial class PersonelSelector : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        public PersonelSelector()
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
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select p.P_id as 'Personel ID',p.P_Adi as 'Personel Adi',p.P_Soyadi as 'Soyadı',d.DPT_adi as 'Departmanı',p.P_Pozisyon as 'Pozisyonu',p.P_Email as 'E-Mail',p.P_Tel1 as 'Telefon',p.P_Aday as 'Aday Durumu' from Tbl_Personel p join Tbl_Departman d on p.P_Dept = d.DPT_id where P_Silindi = 0;";
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                p_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Doldurma Islemi Sirasinda Bir Hata Olustu");
            }

        }

        private void sec_Click(object sender, RoutedEventArgs e)
        {
            object item = p_grid.SelectedItem;
            if (item != null)
            {
                try
                {
                    string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    int selected_personel = Convert.ToInt32(ID);
                    sel.ected.addToToplani(selected_personel);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Secme Islemi Sirasinda Bir Hata Olustu");
                }

            }

            else
            {
                MessageBox.Show("Lütfen bir kişi seçinz");
            }
          
        }






    }
}
