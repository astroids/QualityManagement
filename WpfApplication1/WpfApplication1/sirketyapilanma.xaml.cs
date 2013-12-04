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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for sirketyapilanma.xaml
    /// </summary>
    public partial class sirketyapilanma : Window
    {
        public sirketyapilanma()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            if (tip == null)
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select d.DKM_id as 'Doküman ID', d.DKM_Adi as 'Doküman Adı',d.DKM_Baslik as 'Doküman Başlığı',t.DKMT_Adi as 'Doküman Tipi'  from Tbl_Dokuman d join  Tbl_Dokuman_Tipi t on d.DKM_Tip=t.DKMT_id";
            }
            else
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select d.DKM_id as 'Doküman ID', d.DKM_Adi as 'Doküman Adı',d.DKM_Baslik as 'Doküman Başlığı',t.DKMT_Adi as 'Doküman Tipi'  from Tbl_Dokuman d join  Tbl_Dokuman_Tipi t on d.DKM_Tip=t.DKMT_id where d.DKM_Ilgili_Departman=@id";
                cmd.Parameters.AddWithValue("@id", tip);
            }
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            p_grid.ItemsSource = dt.DefaultView;
            cmd.ExecuteNonQuery();
            con.Close();

        }
          try
                    {
                        string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                        selectedID = Convert.ToInt32(ID);
                        SqlCommand cmd = new SqlCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "delete Tbl_Egitim where E_id =@sid";
                        cmd.Parameters.AddWithValue("@sid", selectedID);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        listele(null);
                        MessageBox.Show

       ("İşleminiz Başarıyla gerçekleştirildi");
                    }
                    catch
                    {
                        MessageBox.Show("İşleminiz Sırasında Bir Hata Oluştu");
                    }
                    

                }

            }
            else
            {
                MessageBox.Show("After Edit BRB");
            }

 private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
 object item = p_grid.SelectedItem;
            if (item != null)
            {
                try
                {
                string ID = (p_grid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                selectedID = Convert.ToInt32(ID);
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Tbl_Personel_Izin set PI_Onay=1,PI_OnayVeren_id =7003 where PI_id = @sid";
                cmd.Parameters.AddWithValue("@sid", selectedID);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                p_grid.ItemsSource = dt.DefaultView;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Onay Veren Personeli Loginle Yap Kayıt Başarılı");
                }
                catch
                {
                MessageBox.Show("Sonuç hata");
                }

            }
            else
            {
                MessageBox.Show("SOnuç görüntülenemedi");
            }
try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Tbl_Egitim values (@adi,@icerik,@verenid,@btr,@sontr);";
                cmd.Parameters.AddWithValue("@adi", eAdi.Text);
                cmd.Parameters.AddWithValue("@verenid", egitimverenid);
                cmd.Parameters.AddWithValue("@icerik", eIcerik.Text);
                cmd.Parameters.AddWithValue("@btr", baslngic.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@sontr", bitisTar.ToString("yyyy-MM-dd"));
                cmd.ExecuteNonQuery();
                con.Close();


                //izinin idsini bul
                con.Open();
                cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select max(e.E_id) as next from Tbl_Egitim e ";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    egitimno = Convert.ToInt32(reader["next"].ToString());
                }


                //cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(egitimno.ToString());

                Wegitimincele n = new Wegitimincele(egitimno);
                n.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Kaydetme Sirasinda Bir Hata Oluştu");
            }



        }





        }
    }
}
