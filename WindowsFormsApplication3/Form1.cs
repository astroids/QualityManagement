using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
    gridden secme sag tiklama yada ust menuden select * from (secilen menu) where x.id=(secilen kolonun reader[0])
 * 
 * 
*/
namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        private SqlConnection con = new SqlConnection();



        public Form1()
        {
            InitializeComponent();
            con.ConnectionString = "Server=NAGASH; Database=Personel2; Integrated Security=true;";
        }

        private void listeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* p_grid.Visible = true;
            p_Close.Visible = true;
            string connectionString =
            "Server=NAGASH; Database=Personel; Integrated Security=true;";

            // Provide the query string with a parameter placeholder. 
            string queryString =
                "SELECT * from Personel;";

            // Specify the parameter value. 
            int paramValue = 5;

            // Create and open the connection in a using block. This 
            // ensures that all resources will be closed and disposed 
            // when the code exits. 
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@pricePoint", paramValue);

                // Open the connection in a try/catch block.  
                // Create and execute the DataReader, writing the result 
                // set to the console window. 
                try
                {
                    connection.Open();
                    DataTable p_Data = new DataTable();
                     

                    
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }*/
            p_grid.Visible = true;
            p_Close.Visible = true;

          
            con.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select * from Personel",con);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            p_grid.DataSource = dt;
            con.Close();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelDataSet1.Sirket' table. You can move, or remove it, as needed.
            this.sirketTableAdapter.Fill(this.personelDataSet1.Sirket);
            // TODO: This line of code loads data into the 'personelDataSet.Personel' table. You can move, or remove it, as needed.
            this.personelTableAdapter.Fill(this.personelDataSet.Personel);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            p_Close.Visible = false;
            p_grid.Visible = false;
        }

        private void p_Alim_Click(object sender, EventArgs e)
        {
            personeToolStripMenuItem.Enabled = false;
            p_grid.Visible = false;
            p_Close.Visible = false;
            p_AlimPop.Visible = true;
            p_Alim_Close.Visible = true; 
            
            con.Open();


            SqlDataAdapter adap = new SqlDataAdapter("select * from Personel", con);

            con.Close();

        }

        private void p_Alim_Close_Click(object sender, EventArgs e)
        {
            p_AlimPop.Visible = false;
            p_Alim_Close.Visible = false;// kaydetemk istiyormusun
            //connection closelari buraya alabirilirz
            personeToolStripMenuItem.Enabled = true;


        }

        private void p_Alim_Ekle_Click(object sender, EventArgs e)
        {

            //sirket combo box a select s_id from Sirket   ayrica departmanda eklenebilir  personel id de ++ gidebilir

            con.Open();

            try
            {
                string cinsiyet= comboBox1.SelectedItem.ToString();
                string sirket = comboBox3.SelectedItem.ToString();
                char s = sirket[0];
                char c = cinsiyet[0];
                string aday = comboBox3.SelectedItem.ToString();
                bool ad = ((aday.Equals("Evet"))?true:false);
                string query = "insert into personel values("+textBox1.Text+","+
                    textBox2.Text+","+textBox4.Text+","+textBox3.Text+","+textBox6.Text+","+c+","+textBox7.Text+","+s+","+ad+";";

                SqlDataAdapter adap = new SqlDataAdapter(query ,con);
            }catch(Exception ex){
                //error yaz
            }
            con.Close();
            p_AlimPop.Visible = false;// close da ne yapilacaksa aynisini bunada yap
            p_Alim_Close.Visible = false;
            personeToolStripMenuItem.Enabled = true;
            //textleri sifirla
        }
    }
}
