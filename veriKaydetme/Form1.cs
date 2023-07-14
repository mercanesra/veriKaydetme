using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace veriKaydetme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-SINNOVD9;Initial Catalog=Kayitler;Integrated Security=True");

        //global alanda verileri çağırmak için kullan daha sonra verileri çağırmak için kullanırız
        private void verilerigöster()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From gelenler", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem  ekle = new ListViewItem();

                ekle.Text = oku["adSoyad"].ToString();
                ekle.SubItems.Add(oku["Firmalar"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            verilerigöster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Insert into gelenler(adSoyad,Firmalar) Values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString()+"')",baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigöster();
        }
    }
}
