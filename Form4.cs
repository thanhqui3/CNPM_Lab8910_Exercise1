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

namespace Cuoimon
{
    public partial class Form4 : Form
    {

        SqlConnection sqlconn = new SqlConnection(@"Data Source=LAPTOP-PNSMCM51\SQLEXPRESS;Initial Catalog=QLNhanVien;Integrated Security=True");
        SqlCommand command;
        public Form4()
        {

            InitializeComponent();
            sqlconn.Open();

            String sql = "select * from Agent";
            command = new SqlCommand(sql, sqlconn);
            DataSet ds = new DataSet();
            command.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlconn.Close();
        }


        private void show()
        {
            sqlconn.Open();

            String sql = "select * from Agent";
            command = new SqlCommand(sql, sqlconn);
            DataSet ds = new DataSet();
            command.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlconn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Trống mã đại lý!");
                textBox1.Select();
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.Select();
            }
            else if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                textBox3.Select();
            }
            command = new SqlCommand();
            command.CommandType = CommandType.Text;
            string sqli = "insert into Item(ItemID, ItemName, Size) values (@ItemID, @ItemName, @Size)";
            command.CommandText = sqli;
            command.Connection = sqlconn;
            command.Parameters.AddWithValue("@ItemID", textBox1.Text);
            command.Parameters.AddWithValue("@ItemName", textBox2.Text);
            command.Parameters.AddWithValue("@Size", textBox3.Text);
            sqlconn.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Đã thêm");

                sqlconn.Close();
            }
            else
            {
                MessageBox.Show("Thêm không thành công!");
                sqlconn.Close();

            }
            show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Close();
        }
    }
}
