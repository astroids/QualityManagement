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
        private int persid;
        private SqlConnection con = new SqlConnection();
        public izinIste(int iid)
        {

            InitializeComponent();
            _sicil.Content = iid;
            persid = iid;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            con.ConnectionString = "Server=NAGASH; Database=Personel; Integrated Security=true;";
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

        private void kaydet_Click(object sender, RoutedEventArgs e)
        {

            DateTime basl =(DateTime)baslan.SelectedDate;
            DateTime biti =(DateTime)baslan.SelectedDate;
            TimeSpan sure = biti-basl;

            try
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Tbl_Personel_Izin values(@id,@tur,@bas,@bit,@sure,NULL,NULL";
                cmd.Parameters.AddWithValue("@id", persid);
                cmd.Parameters.AddWithValue("@bas", (basl.ToString("yyyy-MM-dd")));
                cmd.Parameters.AddWithValue("@bit", (biti.ToString("yyyy-MM-dd")));
                cmd.Parameters.AddWithValue("@sure", sure.Days.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("İzin istegit başarıyla tamamlandı");
                this.Close();
            }
            catch {
                MessageBox.Show("Hatlı işlem");

            }
        }
    }
}
