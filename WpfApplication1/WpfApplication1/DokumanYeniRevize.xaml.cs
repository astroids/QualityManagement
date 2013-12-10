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
    public partial class DokumanYeniRevize : MetroWindow
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        private string docID
        {
            set;
            get;
        }
        public DokumanYeniRevize(string _docID)
        {
            InitializeComponent();
            docID = _docID;
            con.ConnectionString = yet.ki.con;
            fillCombo();
            fillBox();
        }
        void fillCombo()
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


        private void fillBox()
        {
            if (docID != null)
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

                }
                con.Close();
            }


        }

        private void kaydet_Click(object sender, RoutedEventArgs e)
        {
            DokumanGecerlilikDagitim gec = new DokumanGecerlilikDagitim();
            this.Close();
            gec.Show();
        }




    }
}
