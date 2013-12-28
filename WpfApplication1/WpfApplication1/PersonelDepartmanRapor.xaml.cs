﻿using MahApps.Metro.Controls;
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
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Personel_Raporu_Toplu.xaml
    /// </summary>
    public partial class PersonelDepartmanRapor : MetroWindow
    {

        private int selectionType
        {
            get;
            set;
        }

        private string quer
        {
            set;
            get;
        }

        public PersonelDepartmanRapor(int sel)
        {
            InitializeComponent();
            selectionType = sel;
            queryselection();
            fill();
        }
        private void queryselection()
        {
            quer = "SPgetDepartmanPersonelRapor @dep";

        }
        

        private void fill()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                con.ConnectionString = yet.ki.con;
                if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = quer;
                cmd.Parameters.AddWithValue("@dep", selectionType);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                p_grid.ItemsSource = null;
                p_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
                logoS.Source = sir.ket;
                sadi.Text = sir.lname;
                stel.Text = sir.tel;
                sweb.Text = sir.web;
                semail.Text = sir.email;
                sadres.Text = sir.adress;
                tarih.Text = DateTime.Now.ToString("M/d/yyyy");
            }
            catch
            {
                MessageBox.Show("Doldurma İşlemi Sırasında Bir Hata Oluştu");
            }
        }


    }
}
