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
    public partial class Form2 : Form
    {
        SqlConnection sqlconn = new SqlConnection(@"Data Source=LAPTOP-PNSMCM51\SQLEXPRESS;Initial Catalog=QLNhanVien;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 form5 = new Form5();
            form5.ShowDialog();
            this.Close();
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {

            this.Hide(); 
            Form6 form6 = new Form6();
            form6.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }
    }
}
