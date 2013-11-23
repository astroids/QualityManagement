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
    /// Interaction logic for izinIste.xaml
    /// </summary>
    public partial class izinIste : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        public izinIste(int iid)
        {

            InitializeComponent();
            _sicil.Content = iid;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            con.ConnectionString = "Server=MURAT-HP; Database=Personel; Integrated Security=true;";
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(cmd);


            cmd.CommandText = "Select IT_adi FROM Tbl_Izin_Tur;";

            adap.Fill(dt);

            DataSet ds = new DataSet();

            adap.Fill(ds, "Tbl_Personel_Izin");
            cmd.ExecuteNonQuery();

            cmd.CommandText = "Select * FROM Tbl_Personel where P_id = @id;";
            cmd.Parameters.AddWithValue("@id", iid);
            adap.Fill(dt);

            adap.Fill(ds, "Tbl_Personel");


            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                isim.Content = reader["P_Adi"].ToString();
                soyisim.Content = reader["P_Soyadi"].ToString();
            }


            neden.ItemsSource = ds.Tables[0].DefaultView.ToString();

            con.Close();

            //this column will display as text
            //     neden.DisplayMemberPath = ds.Tables[0].Columns["IT_adi"].ToString();

            //this column will use as back end value who can you use in selectedValue property
            //   neden.SelectedValuePath = ds.Tables[0].Columns["IT_id"].ToString();


        }
    }
}
