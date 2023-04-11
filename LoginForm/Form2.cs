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

namespace LoginForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //memasukan ke tabel
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-CMUG4L07\\SQLEXPRESS;Initial Catalog=db_login;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tb_data", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            //buat koneksi ke database
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-CMUG4L07\\SQLEXPRESS;Initial Catalog=db_login;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO tb_data VALUES (@name, @age)", conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@age", int.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Berhasil Ditambahkan");
            conn.Close();
            tampilkanData();



        }
        private void tampilkanData()
        {
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-CMUG4L07\\SQLEXPRESS;Initial Catalog=db_login;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tb_data", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-CMUG4L07\\SQLEXPRESS;Initial Catalog=db_login;Integrated Security=True");
            con.Open();
            SqlCommand CMD = new SqlCommand("delete tb_data where id=@id", con);
            CMD.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            CMD.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data has been deleted");
            tampilkanData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-CMUG4L07\\SQLEXPRESS;Initial Catalog=db_login;Integrated Security=True");
            con.Open();
            SqlCommand CMD = new SqlCommand("update tb_data set name=@name, age=@age where id=@id", con);
            CMD.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            CMD.Parameters.AddWithValue("@name", textBox2.Text);
            CMD.Parameters.AddWithValue("@age", double.Parse(textBox3.Text));
            CMD.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Edited");
            tampilkanData();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if(textBox1.Text != "" )
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-CMUG4L07\\SQLEXPRESS;Initial Catalog=db_login;Integrated Security=True");
                con.Open();
                SqlCommand CMD = new SqlCommand("select * from  tb_data where id = @id", con);
                CMD.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                CMD.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(CMD);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                //buat messagebox
                MessageBox.Show("Masukan id");

            }
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }
    }
}
