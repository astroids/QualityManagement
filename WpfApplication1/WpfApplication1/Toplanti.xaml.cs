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
    /// Interaction logic for Toplanti.xaml
    /// </summary>
    public partial class Toplanti : MetroWindow
    {
        private SqlConnection con = new SqlConnection();
        private int selectedID = 0;
        public Toplanti()
        {
            InitializeComponent();
            listele(null);
        }
        private void listele(string s)
        {
            try
            {
                con.ConnectionString = yet.ki.con;
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                
                if (s == null || s.Length == 0)
                {
                    cmd.CommandText = "Select * From Tbl_Toplanti where Tpl_Iptal=0 or Tpl_Iptal is NULL";
                }
                else
                {
                    cmd.CommandText = "Select * From Tbl_Toplanti s Where s.Tpl_Gundem like @Title";
                    cmd.Parameters.AddWithValue("@Title", '%' + s + '%');
                }
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                data_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Listeleme Sirasinda Bir Hata Olustu");
            }

        }

        DataTable table = new DataTable();

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ToplantiEkle ekle = new ToplantiEkle();
            ekle.Show();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            listele(arama.Text);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            object item = data_grid.SelectedItem;
            if (item != null)
            {

                try
                {
                    if (MessageBox.Show("Silmek istediğinize eminmisiniz", "Onay", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        //if(MessageBox.Show("Devam etmek istiyormusunuz ?", "Uyarı", MessageBoxButton.YesNo);
                        string ID = (data_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                        selectedID = Convert.ToInt32(ID);

                        con.Open();

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "delete from Tbl_Toplanti where Top_id = @Top_id";

                        cmd.Parameters.AddWithValue("@Top_id", selectedID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Silme Yapıldı..");

                        con.Close();

                        //rows number of record got deleted

                    }
                }
                catch
                {
                    MessageBox.Show("Silme Islemi Sirasinda Bir Hata Oluştu");
                }



            }
            else
            {
                MessageBox.Show("Silinecek olan toplantiyi secdiginize emin olunuz!");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            object item = data_grid.SelectedItem;
            if (item != null)
            {



                //if(MessageBox.Show("Devam etmek istiyormusunuz ?", "Uyarı", MessageBoxButton.YesNo);
                string ID = (data_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                selectedID = Convert.ToInt32(ID);
                //ToplantiEkle x = new ToplantiEkle(selectedID, 2);
                //x.Show();

            }
            else
            {
                MessageBox.Show("Degistirmek icin bir toplanti secmelisiniz!");
            }




        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = yet.ki.con;
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select E_id as 'id', e.E_Adi as 'Egitim Adı',e.E_BasTarih as 'Başlangış tarihi', e.E_BitTarih as 'Bitiş Tarihi',p.P_Adi as 'Egitim Veren',p.P_Soyadi as 'soyadı' from Tbl_Egitim e, Tbl_Personel p where e.E_Egi_Veren=p.P_id";

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                p_grid.ItemsSource = null;
                p_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                con.Close();
                logoS.Source = sir.ket;
                sadi.Text = sir.lname;
                stel.Text = sir.tel;
                sweb.Text = sir.web;
                semail.Text = sir.email;
                sadres.Text = sir.adress;
            }
            catch
            {
                MessageBox.Show("Toplanti Olusturma Sirasinda Bir Hata Olustu");
            }
            listele(null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow bac = new MainWindow();
            bac.Show();
            this.Close();
        }

    }
}
