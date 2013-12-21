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
    /// Interaction logic for PersonelRaporu.xaml
    /// </summary>
    public partial class PersonelRaporu : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        private int selected_personel;
       
        public PersonelRaporu(int sid)
        {
            try
            {
                selected_personel = sid;
                InitializeComponent();
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = yet.ki.con;
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * From Tbl_Personel  Where P_id=@id ";
                cmd.Parameters.AddWithValue("@id", sid);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id.Text=reader["P_id"].ToString();
                    adi.Text = reader["P_Adi"].ToString();
                    soyadi.Text = reader["P_Soyadi"].ToString();
                    tc.Text = reader["P_TcKimlik"].ToString();
                    tel1.Text = reader["P_Tel1"].ToString();
                    tel2.Text = reader["P_Tel2"].ToString();
                    email.Text = reader["P_Email"].ToString();
                    dtar.Text=reader["P_D_Tar"].ToString();
                    dyer.Text=reader["P_D_Yer"].ToString();
                    dep.Text=reader["P_Dept"].ToString();
                    poz.Text=reader["P_Pozisyon"].ToString();
                    med.Text=reader["P_Med_Hal"].ToString();
                }
                 if (con.State == ConnectionState.Open){con.Close();}
                sadi.Text = sir.name;
                sadi.Text = sir.lname;
                stel.Text = sir.tel;
                semail.Text = sir.email;
                sweb.Text = sir.web;
                logoS.Source = sir.ket;
                tarih.Text = DateTime.Today.ToShortDateString();
            }
            catch
            {
                MessageBox.Show("Raporlama Islemi Sirasinda Bir Hata Olustu");
                if (con.State == ConnectionState.Open) { con.Close(); }

            }
        }
        
         }
    }
    

