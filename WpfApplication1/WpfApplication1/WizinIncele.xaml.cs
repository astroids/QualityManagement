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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for WizinIncele.xaml
    /// </summary>
    public partial class WizinIncele : MetroWindow
    {
        private int secilenizin;
        private SqlConnection con = new SqlConnection();
        public WizinIncele(int sid)
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
            con.Open();

            cmd.CommandText = "	select eg.P_Adi as 'Adı', eg.P_Soyadi as 'Soyadı' ,eg.P_Dept as 'Departmanı' from(select * from Tbl_Personel_Egitim e,Tbl_Personel p where p.P_id = e.PE_id)as eg where eg.PE_Egitim_id = @id;";
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dt);

            eAlanPers.ItemsSource = dt.DefaultView;
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}
