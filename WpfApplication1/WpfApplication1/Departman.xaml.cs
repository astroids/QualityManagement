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

            con.ConnectionString = "Server=NAGASH; Database=Personel; Integrated Security=true;";
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

       

        private void depsil_Click(object sender, RoutedEventArgs e)
        {

            object item = grid.SelectedItem;
            if (item != null)
            {

                try
                {
                    if (MessageBox.Show("Silmek istediğinize eminmisiniz", "Onay", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        //if(MessageBox.Show("Devam etmek istiyormusunuz ?", "Uyarı", MessageBoxButton.YesNo);
                        string ID = (grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                        selectedID = Convert.ToInt32(ID);

                        con.Open();

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "delete from Tbl_Departman where DPT_id = @pid";

                        cmd.Parameters.AddWithValue("@pid", selectedID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Silme Yapıldı..");

                        con.Close();

                        //rows number of record got deleted

                    }
                }
                catch
                {
                    MessageBox.Show("Silme Islemi Sirasinda Bir Hata Oluştu");
                }



            }
            else
            {
                MessageBox.Show("Silinecek olan toplantiyi secdiginize emin olunuz!");
            }
        }

        private void depdüzenle_Click(object sender, RoutedEventArgs e)
        {
            object item = grid.SelectedItem;
            if (item != null)
            {



                //if(MessageBox.Show("Devam etmek istiyormusunuz ?", "Uyarı", MessageBoxButton.YesNo);
                string ID = (grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                selectedID = Convert.ToInt32(ID);
              

            }
            else
            {
                MessageBox.Show("Degistirmek icin bir departman secmelisiniz!");
            }
        }
    }

}

