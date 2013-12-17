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
    /// Interaction logic for DokumanYeniRevize.xaml
    /// </summary>
    /// 


    //SADECE REVIZE //yeeni yok
    public partial class DokumanYeniRevize : MetroWindow
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        private string docID
        {
            set;
            get;
        }
        private string sorumlu_personel
        {
            set;
            get;
        }
        public DokumanYeniRevize(string _docID)
        {
            InitializeComponent();
            wdn.Width = 700;
            docID = _docID;
            con.ConnectionString = yet.ki.con;
            fillCombo();
            fillBox();
            fillPersonel();
        }
        void fillCombo()
        {

            try
            {
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

                cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Dokuman_Tipi";
                cmd.Connection = con;
                con.Open();
                dt = new DataTable();
                adap = new SqlDataAdapter(cmd);

                adap.Fill(dt);
                tipSec.ItemsSource = dt.DefaultView;
                tipSec.DisplayMemberPath = "DKMT_Adi";
                tipSec.SelectedValuePath = "DKMT_id";
                con.Close();
            }
            catch
            {
                MessageBox.Show("Bir hata olustu");
            }
            
        }


        private void fillBox()
        {
            if (docID != null)
            {
                try
                {
                    int docid = Convert.ToInt32(docID);

                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SPgetDocIDincele @did";
                    cmd.Parameters.AddWithValue("@did", docid);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id.Text = reader["id"].ToString();
                        adi.Text = reader["dadı"].ToString();
                        rev.Text = reader["rev"].ToString();
                        acik.Text = reader["açık"].ToString();
                        baslik.Text = reader["baslik"].ToString();
                        icerik.Text = reader["icer"].ToString();
                        hadi.Text = reader["hazper"].ToString();
                        hdep.Text = reader["odep"].ToString();
                        hopoz.Text = reader["hpoz"].ToString();
                        tipSec.Text = reader["dtip"].ToString();
                        depSec.Text = reader["ddep"].ToString();
                    }
                    con.Close();
                }
                catch
                {
                    MessageBox.Show("Bir hata olustu");
                }
            }


        }

        private void kaydet_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SPgetDocIDincele @did";
                cmd.Parameters.AddWithValue("@id", docID);
                cmd.Parameters.AddWithValue("@dadı", docID);
                cmd.Parameters.AddWithValue("@rev", docID);
                cmd.Parameters.AddWithValue("@açık", docID);
                cmd.Parameters.AddWithValue("@baslik", docID);
                cmd.Parameters.AddWithValue("@hazper", docID);
                cmd.Parameters.AddWithValue("@odep", docID);
                cmd.Parameters.AddWithValue("@dtip", docID);
                cmd.Parameters.AddWithValue("@ddep", docID);
            }
            catch
            {
                MessageBox.Show("Dokuman revize islemi sirasinda bir hata olustu");
            }
            DokumanGecerlilikDagitim gec = new DokumanGecerlilikDagitim(Convert.ToInt32(docID));
            this.Close();
            gec.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (wdn.Width == 700)
            {
                wdn.Width = 1050;
            }
            else
            {
                wdn.Width = 700;
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
                p_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Seçili Personel Zaten Listede");
            }
        }

        private void personelSec_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = p_grid.SelectedItem;
                sorumlu_personel = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;


                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Tbl_Dokuman set DKM_Hazirlayan_Personel = @sp where DKM_id = @di";
                cmd.Parameters.AddWithValue("@di", docID);
                cmd.Parameters.AddWithValue("@sp", sorumlu_personel);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
             //   MessageBox.Show("Hatalı seçim");
            }
            fillBox();
        }



    }
}
