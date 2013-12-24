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
using System.ComponentModel;

namespace WpfApplication1
{


    /// <summary>
    /// Interaction logic for GirisEkrani.xaml
    /// </summary>
    public partial class GirisEkrani : MetroWindow
    {

        private SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        


        public GirisEkrani()
        {

            InitializeComponent();
            con.ConnectionString = yet.ki.con;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            
            
            try
            {
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                SqlParameter prm1 = new SqlParameter("@P1", kullanıcı.Text);
                SqlParameter prm2 = new SqlParameter("@P2", sifre.Password);
               
                string sql = "";
                sql = "select * FROM Tbl_Personel WHERE P_id=@P1 and P_Sifre=@P2";
                SqlCommand cmd = new SqlCommand(sql, con);
                
                cmd.Parameters.Add(prm1);
                cmd.Parameters.Add(prm2);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);
                
                if (dt.Rows.Count > 0)
                {
                    
                    yet.ki.yetki = Convert.ToInt32( dt.Rows[0].ItemArray[16].ToString());
                    yet.ki.ilksifre = sifre.Password;
                    yet.ki.kulID = dt.Rows[0].ItemArray[0].ToString();
                    yet.ki.kulAdi = dt.Rows[0].ItemArray[1].ToString();
                    yet.ki.al =Convert.ToInt32( dt.Rows[0].ItemArray[16].ToString());
                    MainWindow mw = new MainWindow();
                    yet.ki.kulID = kullanıcı.Text;
                    
                    MessageBox.Show(yet.ki.kulAdi +" Bey\nHosgeldiniz");
                    this.Close();
                    mw.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı yada şifre hatalı!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                 if (con.State == ConnectionState.Open){con.Close();}
            }
             
                  
           

        }

    }
}