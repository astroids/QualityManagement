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
    /// Interaction logic for DokumanYeniRevize.xaml
    /// </summary>
    /// 


    //SADECE REVIZE //yeeni yok
    public partial class DokumanYeniRevize : MetroWindow
    {
        SqlConnection con = new SqlConnection();
        
        private string docID
        {
            set;
            get;
        }
        private string sorumlu_personel
        {
            set;
            get;
        }
        public DokumanYeniRevize(string _docID)
        {
            InitializeComponent();
            wdn.Width = 700;
            docID = _docID;
            con.ConnectionString = yet.ki.con;
            fillCombo();
            fillBox();
            fillPersonel();
        }
        void fillCombo()
        {

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Departman";
                cmd.Connection = con;
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                DataTable dt = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);

                adap.Fill(dt);
                depSec.ItemsSource = dt.DefaultView;
                depSec.DisplayMemberPath = "DPT_adi";
                depSec.SelectedValuePath = "DPT_id";
                 if (con.State == ConnectionState.Open){con.Close();}

                cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Dokuman_Tipi";
                cmd.Connection = con;
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                dt = new DataTable();
                adap = new SqlDataAdapter(cmd);

                adap.Fill(dt);
                tipSec.ItemsSource = dt.DefaultView;
                tipSec.DisplayMemberPath = "DKMT_Adi";
                tipSec.SelectedValuePath = "DKMT_id";
                 if (con.State == ConnectionState.Open){con.Close();}
            }
            catch
            {
                MessageBox.Show("Bir hata olustu");
            }
            
        }


        private void fillBox()
        {
            

            if (docID != "NULL")
            {
                try
                {
                    int docid = Convert.ToInt32(docID);
                    if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SPgetDocIDincele @did";
                    cmd.Parameters.AddWithValue("@did", docid);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id.Text = reader["id"].ToString();
                        adi.Text = reader["dadı"].ToString();
                        rev.Text = reader["rev"].ToString();
                        acik.Text = reader["açık"].ToString();
                        baslik.Text = reader["baslik"].ToString();
                        icerik.Text = reader["icer"].ToString();
                        hadi.Text = reader["hazper"].ToString();
                        hdep.Text = reader["odep"].ToString();
                        hopoz.Text = reader["hpoz"].ToString();
                        sorumlu_personel=reader["hid"].ToString();
                        tipSec.Text = reader["dtip"].ToString();
                        depSec.Text = reader["ddep"].ToString();
                    }
                     if (con.State == ConnectionState.Open){con.Close();}
                     
                }
                catch
                {
                    MessageBox.Show("Bir hata olustu");
                    if (con.State == ConnectionState.Open) { con.Close(); }
                    this.Close();
                }
            }


        }

        private void kaydet_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();

                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                if (docID != "NULL")
                {
                    cmd.CommandText = "insert into Tbl_Dokuman values(@dadi,@acik,@dtip,@baslik,@icer,@hazper,NULL,NULL,@rev,@neden,@parent,NULL,@ddep,NULL)SELECT SCOPE_IDENTITY()";
                    cmd.Parameters.AddWithValue("@parent", docID);
                }
                else
                {
                    cmd.CommandText = "insert into Tbl_Dokuman values(@dadi,@acik,@dtip,@baslik,@icer,@hazper,NULL,NULL,@rev,@neden,NULL,NULL,@ddep,NULL)SELECT SCOPE_IDENTITY()";
                }
                cmd.Parameters.AddWithValue("@dadi", adi.Text);
                cmd.Parameters.AddWithValue("@rev", rev.Text);
                cmd.Parameters.AddWithValue("@acik", acik.Text);
                cmd.Parameters.AddWithValue("@baslik", baslik.Text);
                cmd.Parameters.AddWithValue("@hazper", sorumlu_personel);
                cmd.Parameters.AddWithValue("@dtip", tipSec.SelectedValue);
                cmd.Parameters.AddWithValue("@ddep", depSec.SelectedValue);
                cmd.Parameters.AddWithValue("@icer", icerik.Text);
                
                cmd.Parameters.AddWithValue("@neden", revNeden.Text);
                string doc = cmd.ExecuteScalar().ToString();
                if (con.State == ConnectionState.Open) { con.Close(); }
                DokumanGecerlilikDagitim gec = new DokumanGecerlilikDagitim(Convert.ToInt32(doc));
                MessageBox.Show("Doküman Revizyon Başarılı");
                this.Close();
                gec.Show();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Dokuman revize islemi sirasinda bir hata olustu");
                if (con.State == ConnectionState.Open) { con.Close(); }

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (wdn.Width == 700)
            {
                wdn.Width = 1050;
            }
            else
            {
                wdn.Width = 700;
            }
        }
        private void fillPersonel()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SPgetPersonelShort";
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                p_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                 if (con.State == ConnectionState.Open){con.Close();}
            }
            catch
            {
                MessageBox.Show("Seçili Personel Zaten Listede");
                if (con.State == ConnectionState.Open) { con.Close(); }
           }
        }

        private void personelSec_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = p_grid.SelectedItem;
                sorumlu_personel = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                SqlCommand cmdr = new SqlCommand();
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmdr.Connection = con;
                cmdr.CommandType = CommandType.Text;
                cmdr.CommandText = "select p.P_Adi+ ' '+ p.P_Soyadi as 'hper',p.P_Pozisyon as 'poz',d.DPT_adi as 'dep' from Tbl_Personel p join Tbl_Departman d on p.P_Dept=d.DPT_id where p.P_id =@id";
                cmdr.Parameters.AddWithValue("@id", sorumlu_personel);
                SqlDataReader reade = cmdr.ExecuteReader();
                while (reade.Read())
                {
                    hadi.Text = reade["hper"].ToString();
                    hdep.Text = reade["dep"].ToString();
                    hopoz.Text = reade["poz"].ToString();

                }
                 if (con.State == ConnectionState.Open){con.Close();}
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Hatalı seçim");
            }
        }



    }
}
