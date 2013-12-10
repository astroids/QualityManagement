using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
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
namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for DokumanRevizyon.xaml
    /// </summary>
    public partial class DokumanRevizyon : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        private int selectedID = 0;
        private string selectedDepartman;

        public DokumanRevizyon()
        {
            InitializeComponent();
            con.ConnectionString = yet.ki.con;
            listele(null);
        }
        void listele(string tip)
        {


            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            if (tip == null)
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SPgetAllDok";
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

        private void revize_Click(object sender, RoutedEventArgs e)
        {
            object item = p_grid.SelectedItem;
            if (item != null)
            {
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                DokumanYeniRevize rev = new DokumanYeniRevize(ID);
                rev.Show();
                
            }
            else
            {
                DokumanYeniRevize rev = new DokumanYeniRevize(null);
                rev.Show();
                
            }
            
        }




    }
}
