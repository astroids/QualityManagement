﻿using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Drawing;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for ToplantiEkle.xaml
    /// </summary>
    public partial class ToplantiEkle : MetroWindow
    {

        private SqlConnection con = new SqlConnection();
        private int toplanti_baskani;
        private string toplanti_departmani;
        private string toplantiyeri;
        private int selectedTpl
        {
            set;
            get;
        }
        public ToplantiEkle()
        {
            InitializeComponent();
            con.ConnectionString = yet.ki.con;
            fillCombo();
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
            }
            catch
            {
                MessageBox.Show("Doldurma Sırasında Bir Hata Oluştu");
                if (con.State == ConnectionState.Open) { con.Close(); }

            }

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_TplYerleri";
                cmd.Connection = con;
                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                DataTable dt = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);

                adap.Fill(dt);
                tply.ItemsSource = dt.DefaultView;
                tply.DisplayMemberPath = "TPLY_adi";
                tply.SelectedValuePath = "TPLY_id";
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch
            {
                MessageBox.Show("Doldurma Sırasında Bir Hata Oluştu");
                if (con.State == ConnectionState.Open) { con.Close(); }

            }
















        }

        public void baskaniSec(int _toplanti_baskani)
        {
            try
            {
                toplanti_baskani = _toplanti_baskani;
                if (con.State == ConnectionState.Open){con.Close();con.Open(); } else{con.Open();}
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Tbl_Personel p where p.P_id = @id";
                cmd.Parameters.AddWithValue("@id", toplanti_baskani);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    baskanN.Text = reader["P_Adi"].ToString();
                    baskanS.Text = reader["P_Soyadi"].ToString();
                    baskanC.Text = reader["P_Pozisyon"].ToString();

                }
                 if (con.State == ConnectionState.Open){con.Close();}
            }
            catch
            {
                MessageBox.Show("Başkan Seçimi Sırasında Bir Hata Oluştu");
                if (con.State == ConnectionState.Open) { con.Close(); }

            }
        }



        private void kaydet_Click(object sender, RoutedEventArgs e)
        {



            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                }
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.CommandText = @"Insert Into Tbl_Toplanti(Tpl_Baskani,Tpl_Tarihi,Tpl_Gundem,Tpl_Aciklama,Tpl_Departman,Tpl_Yeri,Tpl_Iptal)
                            values(@Tpl_Baskani,@Tpl_Tarihi,@Tpl_Gundem,@Tpl_Aciklama,@Tpl_Departman,@Tpl_Yeri,@Tpl_Iptal);SELECT SCOPE_IDENTITY();";
                DateTime dt = (DateTime)tarih.SelectedDate;

                dt = Convert.ToDateTime(dt.ToString("yyyy-MM-dd") + " " + hr.Text + ":" + min.Text);
                cmd.Parameters.AddWithValue("@Tpl_Tarihi", dt.ToString("MM/dd/yyyy HH:mm"));
                cmd.Parameters.AddWithValue("@Tpl_Yeri", toplantiyeri);
                cmd.Parameters.AddWithValue("@Tpl_Baskani", toplanti_baskani);
                //         cmd.Parameters.AddWithValue("@Tpl_Katilanlar", katilan.Text);
                cmd.Parameters.AddWithValue("@Tpl_Gundem", gundem.Text);
                cmd.Parameters.AddWithValue("@Tpl_Aciklama", aciklama.Text);
                cmd.Parameters.AddWithValue("@Tpl_Iptal", "0");
                cmd.Parameters.AddWithValue("@Tpl_Departman", toplanti_departmani);

                //           cmd.Parameters.AddWithValue("@Tpl_Yapilanlar", yapilanlar.Text);
                string asd = cmd.ExecuteScalar().ToString();
                selectedTpl = Convert.ToInt32(asd);
                //  selectedTpl=(int)cmd.ExecuteScalar();

                MessageBox.Show("Kayıt Yapıldı");
                if (con.State == ConnectionState.Open) { con.Close(); }
                ToplantiDokumanPersonelEkle pd = new ToplantiDokumanPersonelEkle(selectedTpl);
                pd.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Kayit Başarısız!");
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (con.State == ConnectionState.Open) { con.Close(); }

            }
        }

        private void sec_Click(object sender, RoutedEventArgs e)
        {
            sel.ected.setOpenwindowTPL(this);
            PersonelSelector sele = new PersonelSelector();
            sele.Show();

        }

        private void depSec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            toplanti_departmani = depSec.SelectedValue.ToString();
         
        }

        private void tply_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            toplantiyeri = tply.SelectedValue.ToString();
        }

    }
}
