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
    /// Interaction logic for DokumanYazdir.xaml
    /// </summary>
    public partial class DokumanYazdir : MetroWindow
    {
        private int docid
        {
            get;
            set;
        }
        public DokumanYazdir(int sid)
        {
            InitializeComponent();
            docid = sid;
            fill();
            prt();
        }
        private void fill()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = yet.ki.con;
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SPdokRapor @did";
                cmd.Parameters.AddWithValue("@did", docid);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id.Text = reader["id"].ToString();
                    adi.Text = reader["dadı"].ToString();
                    rev.Text = reader["rev"].ToString();
                    acik.Text = reader["açık"].ToString();
                    dtip.Text = reader["dtip"].ToString();
                    dep.Text = reader["ddep"].ToString();
                    baslik.Text = reader["baslik"].ToString();
                    icerik.Text = reader["icer"].ToString();
                    tarih.Text = Convert.ToDateTime(reader["tar"]).ToString("dd-MM-yyyy");
                    hadi.Text = reader["hazper"].ToString();
                    hsadi.Text = reader["hazsoy"].ToString();
                    oadi.Text = reader["oper"].ToString();
                    osadi.Text = reader["osoy"].ToString();
                    hdep.Text = reader["odep"].ToString();
                    hopoz.Text = reader["hpoz"].ToString();
                    odep.Text = reader["odep"].ToString();
                    opoz.Text = reader["opoz"].ToString();

                }
                 if (con.State == ConnectionState.Open){con.Close();}
                logoS.Source = sir.ket;
                sadi.Text = sir.lname;
                stel.Text = sir.tel;
                sweb.Text = sir.web;
                semail.Text = sir.email;
                sadres.Text = sir.adress;
            }
            catch
            {
                MessageBox.Show("Dokuman Yazdirma Islemi Sirasinda Bir Hata Olustu");
            }
           


        }
        private void prt()
        {
            try
            {
                File.Delete(Directory.GetCurrentDirectory() + "\\doc.xps");
                var paginator = docRep.DocumentPaginator;
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
