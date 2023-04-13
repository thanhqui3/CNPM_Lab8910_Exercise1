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
    public partial class Form7 : Form
    {
        SqlConnection sqlconn = new SqlConnection(@"Data Source=LAPTOP-PNSMCM51\SQLEXPRESS;Initial Catalog=QLNhanVien;Integrated Security=True");
        SqlCommand command;
        public Form7()
        {
            InitializeComponent();
            sqlconn.Open();

            String sql = "select top(3) ItemID, count(ItemID) from OrderDetail group by OrderDetail.ItemID  order by count(ItemID) DESC";
            command = new SqlCommand(sql, sqlconn);
            DataSet ds = new DataSet();
            command.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlconn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form6 = new Form6();
            form6.ShowDialog();
            this.Close();
        }
    }
}
