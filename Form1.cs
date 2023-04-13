using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Cuoimon
{
    public partial class Form1 : Form
    {
        string conn = @"Data Source=LAPTOP-PNSMCM51\SQLEXPRESS;Initial Catalog=QLNhanVien;Integrated Security=True";
        SqlConnection sqlconn = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
                Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
              
                sqlconn = new SqlConnection(conn);
                sqlconn.Open();
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlconn;
                cmd.CommandText = "SP_AuthoLogin";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);
  
                object kq = cmd.ExecuteScalar();
                int code = Convert.ToInt32(kq);
                if (code == 0)
                {
                    MessageBox.Show("Chào mừng User đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (code == 1)
                {
                    MessageBox.Show("Chào mừng Admin đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                    this.Close();

                }
                else if (code == 2)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox2.Text = "";
                    textBox1.Text = "";
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox2.Text = "";
                    textBox1.Text = "";
                    textBox1.Focus();
                }
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        
        }

     
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (checkBox1.Checked)
                {
                    textBox2.UseSystemPasswordChar = false;
                }
                else
                {
                    textBox2.UseSystemPasswordChar = true;
                }
            }
        }
    }
}
