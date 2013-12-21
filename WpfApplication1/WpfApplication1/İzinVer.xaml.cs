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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for İzinVer.xaml
    /// </summary>
    public partial class İzinVer : MetroWindow
    {
        private SqlConnection con= new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        public İzinVer()
        {
            InitializeComponent();
            con.ConnectionString = yet.ki.con;
            fillGrid();
        }
        private void fillGrid()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                cmd= new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SPgetPersonel";
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                p_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Doldurma Islemi Sirasinda Bir Hata Olustu");
                if (con.State == ConnectionState.Open) { con.Close(); }

            }



        }

        private void sec_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = p_grid.SelectedItem;
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                int selectedID = Convert.ToInt32(ID);
                izinIste iz = new izinIste(selectedID);
                iz.Show();
            }
            catch
            {
                MessageBox.Show("Lütfen bir personel seçiniz");
            }
        }



    }
}
