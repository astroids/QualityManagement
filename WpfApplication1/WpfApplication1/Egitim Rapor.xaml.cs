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
using System.Windows.Xps.Packaging;

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
            con.ConnectionString = yet.ki.con;
            InitializeComponent();
            fill();
            prt();
           



        }

        private void fill()
        {
            try
            {
                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Egitim e,Tbl_Personel p where e.E_id =@id and p.P_id = e.E_Egi_Veren";
                cmd.Parameters.AddWithValue("@id", selected_egitim.ToString());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    baslik.Text = reader["E_Adi"].ToString();
                    icerik.Text = reader["E_Icerik"].ToString();
                    baslan.Text = Convert.ToDateTime(reader["E_BasTarih"]).ToString("dd-MM-yyyy");
                    bitis.Text = Convert.ToDateTime(reader["E_BitTarih"]).ToString("dd-MM-yyyy");
                    eVeren.Text = reader["P_Adi"].ToString() + " " + reader["P_Soyadi"].ToString();

                }
                if (con.State == ConnectionState.Open) { con.Close(); }

                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select eg.P_id as 'Sicil No', eg.P_Adi as 'Adı', eg.P_Soyadi as 'Soyadı' ,eg.DPT_adi as 'Departmanı' ,eg.PE_Egitim_Degerlendirme as 'Egitim Degerlendirme' from(select * from Tbl_Personel_Egitim e , Tbl_Personel p ,Tbl_Departman d where p.P_id = e.PE_id and p.P_Dept = d.DPT_id)as eg where eg.PE_Egitim_id = @id";
                cmd.Parameters.AddWithValue("@id", selected_egitim);
                DataTable dt = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

                eAlanPers.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }

                logoS.Source = sir.ket;
                sadi.Text = sir.lname;
                stel.Text = sir.tel;
                sweb.Text = sir.web;
                semail.Text = sir.email;
                sadres.Text = sir.adress;
                tarih.Text = DateTime.Now.ToString("M/d/yyyy");
            }
            catch
            {
                MessageBox.Show("Raporlama Sırasında Bir Hata Oluştu");
            }
        }

        private void prt()
        {
            try
            {
                File.Delete(Directory.GetCurrentDirectory() + "\\doc.xps");
                var paginator = custRapor.DocumentPaginator;
                var xpsDocument = new XpsDocument(Directory.GetCurrentDirectory() + "\\doc.xps", FileAccess.ReadWrite);
                var documentWriter = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
                documentWriter.Write(paginator);
                xpsDocument.Close();
            }
            catch
            {
                MessageBox.Show("Yazdırma İşlemi Sırasında Bir Hata Oluştu");
            }

        }
    }
}
