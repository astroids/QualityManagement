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
    /// Interaction logic for DokumanGecerlilikDagitim.xaml
    /// </summary>
    public partial class DokumanGecerlilikDagitim : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private int docID
        {
            set;
            get;
        }
        private int selected_personel
        {
            set;
            get;
        }
        public DokumanGecerlilikDagitim(int _docID)
        {
            InitializeComponent();
            con.ConnectionString = yet.ki.con;
            docID = _docID;
            fillGrid();
            fillBoxes();
            fillPersonel();
        }

        private void fillGrid()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select p.P_id as 'Personel ID',p.P_Adi as 'Personel Adi',p.P_Soyadi as 'Soyadı',d.DPT_adi as 'Departmanı',p.P_Pozisyon as 'Pozisyonu' from Tbl_Personel p join Tbl_Departman d on p.P_Dept = d.DPT_id where P_Silindi = 0;";
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
        private void fillBoxes()
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SPgetGecerlilik @gid=@did";
                cmd.Parameters.AddWithValue("@did", docID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    docAdi.Content = reader["dadi"].ToString();
                    dGecSure.Text = reader["gecer"].ToString();
                    dGecStip.Text = reader["gecerTip"].ToString();
                    dArSure.Text = reader["arsiv"].ToString();
                    dArStip.Text = reader["dtar"].ToString();
                    dSor.Content = reader["sorumlu"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void fillPersonel()
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SPgetDokumanDagitmPers @did=@id";
                cmd.Parameters.AddWithValue("@id", docID.ToString());
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                p2_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Seçili Personel Zaten Listede");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object item = p_grid.SelectedItem;
            string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            if (item != null)
            {
                try
                {
                    
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@did", docID.ToString());
                    cmd.Parameters.AddWithValue("@pid", ID.ToString());
                    cmd.Parameters.AddWithValue("@mail", "TRUE");
                    cmd.Parameters.AddWithValue("@dagit", "2013-12-11");
                    cmd.CommandText = "insert into Tbl_Dokuman_Dagitim(DKMD_id,DKMD_personel,DKMD_mail,DKMD_Dagitim_Tarihi) values(@did,@pid,@mail,@dagit)";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    selected_personel = Convert.ToInt32(ID);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    con.Close();
                }
                fillPersonel();
            }
        }


    }
}
