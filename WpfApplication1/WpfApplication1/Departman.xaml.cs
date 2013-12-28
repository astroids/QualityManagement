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

            con.ConnectionString = yet.ki.con;;
            listele(null);
        }
        private void listele(string ser)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                if (ser == null || ser.Length == 0)
                {
                    cmd.CommandText = "SPgenelDeprtman ";
                }

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch
            {
                MessageBox.Show("Listeleme İşlemi Sırasında Bir Hata Oluştu");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow bac = new MainWindow();
            bac.Show();
            this.Close();
        }

       

        private void depsil_Click(object sender, RoutedEventArgs e)
        {

            object item = grid.SelectedItem;
            if (item != null)
            {

                try
                {
                    if (MessageBox.Show("Silmek İstediğinize Emin misiniz", "Onay", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        
                        string ID = (grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                        selectedID = Convert.ToInt32(ID);

                        if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "delete from Tbl_Departman where DPT_id = @pid";

                        cmd.Parameters.AddWithValue("@pid", selectedID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Silme Yapıldı");

                         if (con.State == ConnectionState.Open){con.Close();}

                    }
                }
                catch
                {
                    MessageBox.Show("Silme İşlemi Sırasında Bir Hata Oluştu");
                }



            }
            else
            {
                MessageBox.Show("Silinecek Olan Toplantıyı Seçtiğinize Emin Olunuz!");
            }
        }



        private void depdüzenle_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                object item = grid.SelectedItem;
                if (item != null)
                {
                    string ID = (grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    selectedID = Convert.ToInt32(ID);
                    DepartmanDüzenle dzn = new DepartmanDüzenle(selectedID, 1);
                    dzn.Show();

                }
                else
                {
                    MessageBox.Show("Değiştirmek İçin Bir Departman Seçmelisiniz!");
                }
            }
            catch
            {
                MessageBox.Show("Hata Oluştu");
            }

        }

        private void depekle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                    DepartmanDüzenle dzn = new DepartmanDüzenle(0, 2);
                    dzn.Show();

            }
            catch
            {
                MessageBox.Show("Hata Oluştu");
            }
        }
    }

}

