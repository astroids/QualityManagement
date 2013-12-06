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
using System.Data.SqlClient;

namespace WpfApplication1
{


    /// <summary>
    /// Interaction logic for GirisEkrani.xaml
    /// </summary>
    public partial class GirisEkrani : MetroWindow
    {

        private SqlConnection con = new SqlConnection();
   //     private SqlConnection con2 = new SqlConnection();
       public SqlCommand cmd = new SqlCommand();
        static public string yetki;


        //public static int i = 1;
        public GirisEkrani()
        {

            InitializeComponent();
            //if (i % 2 == 0)
            //{
            //    this.Close();

            //}
            con.ConnectionString = yet.ki.con;
       //     con2.ConnectionString = yet.ki.con;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            
            
            try
            {
                con.Open();
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
                    MessageBox.Show("Hosgeldiniz");
                    yetki = dt.Rows[0].ItemArray[16].ToString();
                    
                    // Response.Redirect("Default.aspx");
                    MainWindow mw = new MainWindow();
                    //i ++;
                    yet.ki.kadi = kullanıcı.Text;
                    yet.ki.al = 1;
                    
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
                con.Close();
            }
             
                  
           

        }

    }
}