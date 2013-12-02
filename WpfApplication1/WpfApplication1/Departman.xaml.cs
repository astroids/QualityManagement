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
    /// Interaction logic for DepartmanDüzenle.xaml
    /// </summary>
    public partial class Departman : MetroWindow
    {
        private int selectedID = 0;
        private SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public Departman()
        {
            InitializeComponent();

            con.ConnectionString = "Server=ACER; Database=Personel; Integrated Security=true;";
            listele(null);
        }
        private void listele(string ser)
        {

            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            if (ser == null || ser.Length == 0)
            {
                cmd.CommandText = "Select * From Tbl_Departman ";
            }

            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            grid.ItemsSource = dt.DefaultView;
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow bac = new MainWindow();
            bac.Show();
            this.Close();
        }

        
        
    }

}

