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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for PersonelRapor.xaml
    /// </summary>
    public partial class PersonelRapor : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        private int selected_personel;

      public PersonelRapor(int sid)
        {
            selected_personel = sid;
            InitializeComponent();
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = "Server=ERSINBM-8; Database=Personel; Integrated Security=true;";
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * From Tbl_Personel   ";
            cmd.Parameters.AddWithValue("@id", sid);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                PersonelAdi.Text = reader["P_Adi"].ToString();
              PersonelSoyadi.Text = reader["P_Soyadi"].ToString();
                Tc.Text = reader["P_TcKimlik"].ToString();
             Tel1.Text = reader["P_Tel1"].ToString();
             tel2.Text = reader["P_Tel2"].ToString();
             Email.Text = reader["P_Email"].ToString();
            }
            con.Close();

        }
    }
}
