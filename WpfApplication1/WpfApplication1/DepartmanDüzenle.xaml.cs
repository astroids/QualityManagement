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
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Personel";
                cmd.Connection = con;
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                DataTable dt = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);

                adap.Fill(dt);
                DepBaskani.ItemsSource = dt.DefaultView;
                DepBaskani.DisplayMemberPath = "P_Adi";
                DepBaskani.SelectedValuePath = "P_id";
                 if (con.State == ConnectionState.Open){con.Close();}
            }
            catch
            {
                MessageBox.Show("Doldurma Islemi Sirasinda Bir Hata Olustu");
            }

        }

        public DepartmanDüzenle(int id, int secim)
        {
            try
            {
                x = secim;
                idd = id;
                InitializeComponent();

                con.ConnectionString = yet.ki.con;
                fillCombo();
                if (secim == 2)
                {
                    depn.IsEnabled = false;
                    depno.IsEnabled = false;
                    if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
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
                     if (con.State == ConnectionState.Open){con.Close();}
                }
                //listele(null);

                else if (secim == 1)
                {

                    if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
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
                     if (con.State == ConnectionState.Open){con.Close();}
                }
            }
            catch
            {
                MessageBox.Show("Depertman Duzenleme Islemleri Sirasinda Bir Hata Olustu");
            }

        }


        void listele(string tip)
        {
            try
            {

                SqlCommand cmd = new SqlCommand();
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                cmd.CommandType = CommandType.Text;
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

                 if (con.State == ConnectionState.Open){con.Close();}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                 if (con.State == ConnectionState.Open){con.Close();}
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
                    if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
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

                 if (con.State == ConnectionState.Open){con.Close();}


            }

            if (x == 1)
            {
                if (con.State == ConnectionState.Closed)
                {
                    if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
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

                 if (con.State == ConnectionState.Open){con.Close();}


            }

        }
    }
}
