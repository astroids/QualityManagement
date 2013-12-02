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
    /// Interaction logic for DepartmanDüzenle.xaml
    /// </summary>
    public partial class DepartmanDüzenle : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        private string secilenPersonel;
        private int idd = 0;
        int x = 0;

        void fillCombo()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Tbl_Personel";
            cmd.Connection = con;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(cmd);

            adap.Fill(dt);
            DepBaskani.ItemsSource = dt.DefaultView;
            DepBaskani.DisplayMemberPath = "P_Adi";
            DepBaskani.SelectedValuePath = "P_id";
            con.Close();

        }

       

        void listele(string tip)
        {
            try
            {

                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.CommandType = CommandType.Text;
                //if (tip == null)
                //{

                //    cmd.CommandText = "select d.DKM_id as 'Doküman ID', d.DKM_Adi as 'Doküman Adı',d.DKM_Baslik as 'Doküman Başlığı',t.DKMT_Adi as 'Doküman Tipi'  from Tbl_Dokuman d join  Tbl_Dokuman_Tipi t on d.DKM_Tip=t.DKMT_id";
                //}
                //else
                {


                    cmd.Connection = con; cmd.CommandText = "select *  from Tbl_Personel where P_id=@pid";
                    cmd.Parameters.AddWithValue("@pid", tip);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        secilenPersonel = reader["P_id"].ToString();
                        secilenPer.Text = secilenPersonel;
                        // pkime.Text = " " + reader["P_Soyadi"].ToString();
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }

        }

        private void DepBaskani_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string t = DepBaskani.SelectedValue.ToString();
            listele(t);
        }

       

        
    }
}
