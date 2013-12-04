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

        public DepartmanDüzenle(int id, int secim)
        {
            x = secim;
            idd = id;
            InitializeComponent();

            con.ConnectionString = "Server=Mustafa-HP; Database=Personel; Integrated Security=true;";
            fillCombo();
            if (secim == 2)
            {
                depno.Visibility = Visibility.Visible;
                depno.IsEnabled = true;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Departman where  DPT_id = @pid";
                cmd.Parameters.AddWithValue("@pid", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DepAdi.Text = reader["DPT_adi"].ToString();
                    DepBaskani.Text = reader["DPT_baskani"].ToString();
                }
                con.Close();
            }
            //listele(null);

            else if (secim == 1)
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Departman where  DPT_id = @pid";
                cmd.Parameters.AddWithValue("@pid", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DepAdi.Text = reader["DPT_adi"].ToString();
                    DepBaskani.Text = reader["DPT_baskani"].ToString();
                }
                con.Close();
            }

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

        private void depKaydet_Click(object sender, RoutedEventArgs e)
        {
            if (x == 2)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Connection = con;
                cmd.CommandText = @"Insert Into Tbl_Departman(DPT_adi,DPT_baskani)
                            values(@DPT_adi,@DPT_baskani)";

                //  cmd.Parameters.AddWithValue("@Top_id", idd);
                cmd.Parameters.AddWithValue("@DPT_baskani", DepBaskani.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@DPT_adi", DepAdi.Text);


                cmd.ExecuteNonQuery();

                MessageBox.Show("Kayıt Yapıldı..");
                this.Hide();

                con.Close();


            }

            if (x == 1)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Connection = con;
                cmd.CommandText = @"Update Tbl_Departman set DPT_baskani=@DPT_baskani,DPT_adi=@DPT_adi
                                  where DPT_id = @DPT_id";

                //  cmd.Parameters.AddWithValue("@Top_id", idd);
                cmd.Parameters.AddWithValue("@DPT_id", idd);
                cmd.Parameters.AddWithValue("@DPT_baskani", DepBaskani.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@DPT_adi", DepAdi.Text);


                cmd.ExecuteNonQuery();

                MessageBox.Show("Düzenleme Yapıldı..");
                this.Hide();

                con.Close();


            }

        }
    }
}
