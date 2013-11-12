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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for WegitimDegistir.xaml
    /// </summary>
    public partial class WegitimDegistir : MetroWindow
    {
        private int secilenizin;
        private SqlConnection con = new SqlConnection();
        private int selected_personel;
        private bool tarihdegisti;
        private bool eVerenDegisti;
        private int egitimveren;

        public void setEgitimVeren(int eg)
        {
            egitimveren = eg;
            con.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Tbl_Personel where P_id = @id";

            cmd.Parameters.AddWithValue("@id", egitimveren);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                eVerenAdi.Text = reader["P_Adi"].ToString();
                eVerenSoy.Text = reader["p_Soyadi"].ToString();
            }

            con.Close();

        }
        
        private void refreshTable()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select eg.P_id as 'Sicil No', eg.P_Adi as 'Adı', eg.P_Soyadi as 'Soyadı' ,eg.P_Dept as 'Departmanı' ,eg.PE_Egitim_Degerlendirme as 'Egitim Degerlendirme' from(select * from Tbl_Personel_Egitim e,Tbl_Personel p where p.P_id = e.PE_id)as eg where eg.PE_Egitim_id = @id;";
            cmd.Parameters.AddWithValue("@id", secilenizin);
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dt);

            eAlanPers.ItemsSource = dt.DefaultView;
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public WegitimDegistir(int sid)
        {
            InitializeComponent();
            secilenizin = sid;

            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = "Server=NAGASH; Database=Personel; Integrated Security=true;";
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Tbl_Egitim e,Tbl_Personel p where e.E_id =@id and p.P_id = e.E_Egi_Veren";
            cmd.Parameters.AddWithValue("@id", sid);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                eAdi.Text = reader["E_Adi"].ToString();
                eIcerik.Text = reader["E_Icerik"].ToString();
                eBas.Text = reader["E_BasTarih"].ToString();
                eBit.Text = reader["E_BitTarih"].ToString();
                eVerenAdi.Text = reader["P_Adi"].ToString();
                eVerenSoy.Text = reader["P_Soyadi"].ToString();

            }
            con.Close();

            refreshTable();
        }

        private void ePersEkle_Click(object sender, RoutedEventArgs e)
        {
            sel.ected.setOpenwindowED(this);
            PersonelEkleSil eks = new PersonelEkleSil(5);
            eks.Show();


        }



        private void ePersCikar_Click(object sender, RoutedEventArgs e)
        {
            object item = eAlanPers.SelectedItem;
            string ID = (eAlanPers.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            selected_personel = Convert.ToInt32(ID);

            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = "Server=NAGASH; Database=Personel; Integrated Security=true;";
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Tbl_Personel_Egitim  where Tbl_Personel_Egitim.PE_Egitim_id = @secilenizin and Tbl_Personel_Egitim.PE_id=@selected_personel;";
            cmd.Parameters.AddWithValue("@secilenizin", secilenizin);
            cmd.Parameters.AddWithValue("@selected_personel", selected_personel);

            cmd.ExecuteNonQuery();
            con.Close();
            refreshTable();


        }



        public void setSelectedPers(int i)
        {
            InitializeComponent();
            selected_personel = i;
           
            tarihdegisti = false;
            eVerenDegisti = false;

            try
            {
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = "Server=NAGASH; Database=Personel; Integrated Security=true;";
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Tbl_Personel_Egitim values(@secilenizin,@selected_personel,NULL);";
                cmd.Parameters.AddWithValue("@secilenizin", secilenizin);
                cmd.Parameters.AddWithValue("@selected_personel", selected_personel);

                cmd.ExecuteNonQuery();
                con.Close();
                cmd = new SqlCommand();
                con.ConnectionString = "Server=NAGASH; Database=Personel; Integrated Security=true;";
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select eg.P_id as 'Sicil No', eg.P_Adi as 'Adı', eg.P_Soyadi as 'Soyadı' ,eg.P_Dept as 'Departmanı' ,eg.PE_Egitim_Degerlendirme as 'Egitim Degerlendirme' from(select * from Tbl_Personel_Egitim e,Tbl_Personel p where p.P_id = e.PE_id)as eg where eg.PE_Egitim_id = @id;"; //"	select eg.P_Adi as 'Adı', eg.P_Soyadi as 'Soyadı' ,eg.P_Dept as 'Departmanı' from(select * from Tbl_Personel_Egitim e,Tbl_Personel p where p.P_id = e.PE_id)as eg where eg.PE_Egitim_id = @id;";
                cmd.Parameters.AddWithValue("@id", secilenizin);
                DataTable dt = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);

                adap.Fill(dt);
                eAlanPers.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seçtiğiniz Kişi Zaten Eğitim Listesinde");
                this.Close();
            }

        }

        private void tarihD_Click(object sender, RoutedEventArgs e)
        {
            eBas.Visibility = Visibility.Hidden;
            eBit.Visibility = Visibility.Hidden;
            DateS.Visibility = Visibility.Visible;
            DateE.Visibility = Visibility.Visible;
            tarihdegisti = true;

        }

        private void egitimVD_Click(object sender, RoutedEventArgs e)
        {
            eVerenDegisti = true;
            sel.ected.setOpenwindowED(this);
            PersonelEkleSil per = new PersonelEkleSil(7);
            per.Show();

        }
    }
}
