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
    /// Interaction logic for Egitim_Rapor.xaml
    /// </summary>
    public partial class Egitim_Rapor : MetroWindow
    {

       
        private SqlConnection con = new SqlConnection();
        private int selected_egitim;


        public Egitim_Rapor(int sid)
        {
            selected_egitim = sid;
            InitializeComponent();
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = "Server=ACER; Database=Personel; Integrated Security=true;";
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Tbl_Egitim e,Tbl_Personel p where e.E_id =@id and p.P_id = e.E_Egi_Veren";
            cmd.Parameters.AddWithValue("@id", sid);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                baslik.Text = reader["E_Adi"].ToString();
                icerik.Text = reader["E_Icerik"].ToString();
                baslan.Text = reader["E_BasTarih"].ToString();
                bitis.Text = reader["E_BitTarih"].ToString();
                eVeren.Text = reader["P_Adi"].ToString() +" "+ reader["P_Soyadi"].ToString();

            }
            con.Close();

        }
    }
}
