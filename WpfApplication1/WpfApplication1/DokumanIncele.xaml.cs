using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
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
    /// Interaction logic for DokumanIncele.xaml
    /// </summary>
    public partial class DokumanIncele : MetroWindow
    {
        private int docid{
            get;
            set;
        }
        public DokumanIncele(int id)
        {
            InitializeComponent();
            docid = id;
            fill();
        }
        private void fill()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = "Server=ACER; Database=Personel; Integrated Security=true;";
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select d.DKM_id as 'id',d.DKM_Adi as 'dadı',d.DKM_Revizyon_Tar as 'rev',d.DKM_Aciklama as 'açık',d.DKM_Baslik as 'baslik',d.DKM_Icerik as 'icer',t.DKMT_Adi as 'dtip',d.DKM_Revizyon_Tar as 'tar',p.P_Adi as 'hazper',p.P_Soyadi as 'hazsoy',p2.P_Adi as 'oper',p2.P_Soyadi as 'osoy',de.DPT_adi as 'ddep',de2.DPT_adi as 'hdep',de3.DPT_adi as 'odep',p.P_Pozisyon as 'hpoz',p2.P_Pozisyon as 'opoz' from (((((Tbl_Dokuman d join  Tbl_Dokuman_Tipi t on d.DKM_Tip=t.DKMT_id)join Tbl_Personel p on d.DKM_Hazirlayan_Personel=p.P_id) left join Tbl_Personel p2 on d.DKM_Onaylayan_Personel=p2.P_id) join Tbl_Departman de on d.DKM_Ilgili_Departman= de.DPT_id )join Tbl_Departman de2 on p.P_Dept= de2.DPT_id) left join Tbl_Departman de3 on p2.P_Dept = de3.DPT_id where d.DKM_Child is NULL and d.DKM_id =@did";
            cmd.Parameters.AddWithValue("@did",docid);
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
                tarih.Text = reader["tar"].ToString();
                hadi.Text = reader["hazper"].ToString();
                hsadi.Text = reader["hazsoy"].ToString();
                oadi.Text = reader["oper"].ToString();
                osadi.Text = reader["osoy"].ToString();
                hdep.Text = reader["odep"].ToString();
                hopoz.Text = reader["hpoz"].ToString();
                odep.Text = reader["odep"].ToString();
                opoz.Text = reader["opoz"].ToString();

            }
            con.Close();
    

        }

        private void yazdir_Click(object sender, RoutedEventArgs e)
        {
            DokumanYazdir doc = new DokumanYazdir(docid);
            doc.Show();
        }




    }
}
