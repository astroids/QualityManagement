using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ekleDuzenle.xaml
    /// </summary>
    public partial class ekleDuzenle : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        
        public ekleDuzenle(int tur,int id)
        {
            
            InitializeComponent();
          
            con.ConnectionString = "Server=ERSINBM-8; Database=Personel; Integrated Security=true;";
            if (tur == 2)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Personel where P_id = @id";

                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    isim.Text = reader["P_Adi"].ToString();
                }

                con.Close();
            }
        }


    }
}
