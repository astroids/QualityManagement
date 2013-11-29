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
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Personel_Raporu_Toplu.xaml
    /// </summary>
    public partial class PersonelDepartmanRapor : MetroWindow
    {

        private int selectionType
        {
            get;
            set;
        }

        private string quer
        {
            set;
            get;
        }

        public PersonelDepartmanRapor(int sel)
        {
            InitializeComponent();
            selectionType = sel;
            queryselection();
            fill();
        }
        private void queryselection()
        {
            quer = "select p.P_id as 'Personel ID',p.P_Adi as 'Personel Adi',p.P_Soyadi as 'Soyadı',p.P_Pozisyon as 'Pozisyonu',p.P_Email as 'E-Mail',p.P_Tel1 as 'Telefon',p.P_D_Tar as 'Doğum Tarihi',p.P_D_Yer as 'Doğum Yeri',p.P_Med_Hal as 'Medeni Durumu'  from Tbl_Personel p join Tbl_Departman d on p.P_Dept = d.DPT_id where P_Silindi = 0  and p.P_Aday=0 and p.P_Dept =@dep";

        }
        

        private void fill()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = "Server=MURAT-HP; Database=Personel; Integrated Security=true;";
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = quer;
            cmd.Parameters.AddWithValue("@dep",selectionType);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            p_grid.ItemsSource = null;
            p_grid.ItemsSource = dt.DefaultView;
            cmd.ExecuteNonQuery();
            con.Close();
            logoS.Source = sir.ket;
            sadi.Text = sir.lname;
            stel.Text = sir.tel;
            sweb.Text = sir.web;
            semail.Text = sir.email;
            sadres.Text = sir.adress;
            tarih.Text = DateTime.Now.ToString("M/d/yyyy");
        }


    }
}
