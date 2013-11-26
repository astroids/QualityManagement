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
    /// Interaction logic for AAABOSKOPYALA.xaml
    /// </summary>
    public partial class AAABOSKOPYALA : MetroWindow
    {
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            listele(SEARCH.Text);

        }

        private void ekle_Click_1(object sender, RoutedEventArgs e)
        {
            ekleDuzenle dzn = new ekleDuzenle(1, 0);
            dzn.Show();
        }


        //eski ekle
        private void duzenle_Click_1(object sender, RoutedEventArgs e)
        {

            object item = p_grid.SelectedItem;
            if (item != null)
            {
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                selectedID = Convert.ToInt32(ID);
                ekleDuzenle dzn = new ekleDuzenle(2, selectedID);
                dzn.Show();
            }
            else
            {
                MessageBox.Show("Deiştirmek için bir kişi seçinz");
            }
        }
        //sil eski
        private void iziniste_Click_1(object sender, RoutedEventArgs e)
        {
            object item = p_grid.SelectedItem;
            if (item != null)
            {
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                selectedID = Convert.ToInt32(ID);
                izinIste iz = new izinIste(selectedID);
                iz.Show();
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
            else
            {
                MessageBox.Show("İzin almak için için bir kişi seçinz");
            }
        }
        public AAABOSKOPYALA()
        {
            InitializeComponent();
        }
    }
}
