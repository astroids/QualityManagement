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
    /// Interaction logic for Personel_Raporu_Toplu.xaml
    /// </summary>
    public partial class Personel_Raporu_Toplu : MetroWindow
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

        public Personel_Raporu_Toplu(int sel)
        {
            InitializeComponent();
            selectionType = sel;
            queryselection();
            fill();
            prt();
        }
        private void queryselection()
        {
            if(selectionType==1){
                quer = "SPgetTumPersonelRapor";
                baslik.Text = "Tüm Personel Listesi";

            }else if(selectionType==2){
                quer = "SPgetTumKadroluPersonelRapor";
                baslik.Text = "Kadrolu Personel Listesi";
                
            }else if (selectionType==3){
                quer = "SPgetAdayPersonelRapor";
                baslik.Text = "Stajyer ve Aday Listesi";

            }
            else if (selectionType == 4)
            {
                MessageBox.Show("Hatalı Seçim");
                this.Close();

            }
            
            
            else
            {
                MessageBox.Show("Hatalı Seçim");
                this.Close();
            }
            
        }



        private void fill()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = yet.ki.con;
            if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = quer;
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            p_grid.ItemsSource = null;
            p_grid.ItemsSource = dt.DefaultView;
            cmd.ExecuteNonQuery();
             if (con.State == ConnectionState.Open){con.Close();}
            logoS.Source = sir.ket;
            sadi.Text = sir.lname;
            stel.Text = sir.tel;
            sweb.Text = sir.web;
            semail.Text = sir.email;
            sadres.Text = sir.adress;
            tarih.Text = DateTime.Now.ToString("M/d/yyyy");

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
                MessageBox.Show("Yazdırma işlemi sırasında bir hata oluştu");
            }
        }
    }
}
