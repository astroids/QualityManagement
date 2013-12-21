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
    /// Interaction logic for DokumanOnayxaml.xaml
    /// </summary>
    public partial class DokumanOnayxaml : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private string selected_doc
        {
            set;
            get;
        }
        public DokumanOnayxaml()
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
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SPDokumanOnaylanmamis";
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                d_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch
            {
                MessageBox.Show("Doldurma Islemi Sirasinda Bir Hata Olustu");
                if (con.State == ConnectionState.Open) { con.Close(); }

            }


        }

        private void onayla_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = d_grid.SelectedItem;
                selected_doc = (d_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;


                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Tbl_Dokuman set DKM_Onaylayan_Personel = @sp,DKM_Onay = 1 where DKM_id =@di";
                cmd.Parameters.AddWithValue("@di", selected_doc);
                cmd.Parameters.AddWithValue("@sp", yet.ki.kulID);
                cmd.ExecuteNonQuery();
                 if (con.State == ConnectionState.Open){con.Close();}
                 fillGrid();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Yetkili Olduğunuzdan ve Bir Doküman seçtiğinizden Emin olunuz");
                if (con.State == ConnectionState.Open) { con.Close(); }

            }
        }

        private void reddet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = d_grid.SelectedItem;
                selected_doc = (d_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;


                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Tbl_Dokuman set DKM_Onaylayan_Personel = @sp,DKM_Onay = 0 where DKM_id =@di";
                cmd.Parameters.AddWithValue("@di", selected_doc);
                cmd.Parameters.AddWithValue("@sp", yet.ki.kulID);
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
                fillGrid();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Yetkili Olduğunuzdan ve Bir Doküman seçtiğinizden Emin olunuz");
                if (con.State == ConnectionState.Open) { con.Close(); }

            }
        }

        private void incele_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = d_grid.SelectedItem;
                if (item != null)
                {
                    selected_doc = (d_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    DokumanIncele incele = new DokumanIncele(Convert.ToInt32(selected_doc));
                    incele.Show();
                }

            }
            catch {
                MessageBox.Show("Hatalı Seçim");
            
            }

        }


    }
}
