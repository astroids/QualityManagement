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
    /// Interaction logic for DokumanListesi.xaml
    /// </summary>
    public partial class DokumanListesi : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        private int selectedID = 0;
        private string selectedDepartman;

        void fillCombo()
        {
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Tbl_Departman";
            cmd.Connection = con;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
           
            adap.Fill(dt);
            depSec.ItemsSource = dt.DefaultView;
            depSec.DisplayMemberPath = "DPT_adi";
            depSec.SelectedValuePath = "DPT_id";
            con.Close();

        }


        public DokumanListesi()
        {
            InitializeComponent();
            con.ConnectionString = "Server=MURAT-HP; Database=Personel; Integrated Security=true;";
            listele(null);
            fillCombo();



        }
        void listele(string tip)
        {


            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            if (tip == null)
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select d.DKM_id as 'Doküman ID', d.DKM_Adi as 'Doküman Adı',d.DKM_Baslik as 'Doküman Başlığı',t.DKMT_Adi as 'Doküman Tipi'  from Tbl_Dokuman d join  Tbl_Dokuman_Tipi t on d.DKM_Tip=t.DKMT_id";
            }
            else
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select d.DKM_id as 'Doküman ID', d.DKM_Adi as 'Doküman Adı',d.DKM_Baslik as 'Doküman Başlığı',t.DKMT_Adi as 'Doküman Tipi'  from Tbl_Dokuman d join  Tbl_Dokuman_Tipi t on d.DKM_Tip=t.DKMT_id where d.DKM_Ilgili_Departman=@id";
                cmd.Parameters.AddWithValue("@id", tip);
            }
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            p_grid.ItemsSource = dt.DefaultView;
            cmd.ExecuteNonQuery();
            con.Close();


        }

        private void depSec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string t = depSec.SelectedValue.ToString();
            listele(t);
        }

        private void docRapor_Click(object sender, RoutedEventArgs e)
        {
            DokumanRapor rap = new DokumanRapor();
            rap.Show();
        }

        private void docIncele_Click(object sender, RoutedEventArgs e)
        {
            object item = p_grid.SelectedItem;
            if (item != null)
            {
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                selectedID = Convert.ToInt32(ID);
                DokumanIncele doc = new DokumanIncele(selectedID);
                doc.Show();

            }
            else
            {
                MessageBox.Show("Deiştirmek için bir kişi seçinz");
            }
        }

    }
}
