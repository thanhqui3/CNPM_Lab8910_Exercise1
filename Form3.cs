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
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.Remoting.Contexts;

namespace Cuoimon
{
    public partial class Form3 : Form
    {
        SqlConnection sqlconn = new SqlConnection(@"Data Source=LAPTOP-PNSMCM51\SQLEXPRESS;Initial Catalog=QLNhanVien;Integrated Security=True");
        SqlCommand command;
        public Form3()
        {
            InitializeComponent();

            sqlconn.Open();

            String sql = "select * from Item";
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

            String sql = "select * from Item";
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
                MessageBox.Show("Trống mã sản phẩm!");
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
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Thông tin trống!");
            }
            else
            {
                sqlconn.Open();
                command.CommandType = CommandType.Text;
                string sqli = "delete from Item where ItemID = @ItemID";
                command.CommandText = sqli;
                command.Connection = sqlconn;
                command.Parameters.AddWithValue("@ItemID", textBox1.Text);

                if (command.ExecuteNonQuery() > 0)
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    MessageBox.Show("Đã xóa"); 
                }
                else
                {
                    MessageBox.Show("xóa không thành công!");
                }
                sqlconn.Close();
                show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Trống mã sản phẩm!");
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
                command.CommandText = "SP_Suasanpham" ;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@ItemID", SqlDbType.Char).Value = textBox1.Text;
                command.Parameters.Add("@ItemName", SqlDbType.Char).Value = textBox2.Text;
                command.Parameters.Add("@Size", SqlDbType.Char).Value = textBox3.Text;

                command.Connection = sqlconn;
                sqlconn.Open();
                command.ExecuteNonQuery();
                sqlconn.Close();
                MessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                show();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Close();
        }

    }
}
