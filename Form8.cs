using Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cuoimon
{
    public partial class Form8 : Form
    {
        DataSet ds;
        SqlConnection sqlconn = new SqlConnection(@"Data Source=LAPTOP-PNSMCM51\SQLEXPRESS;Initial Catalog=QLNhanVien;Integrated Security=True");
        SqlCommand command;
        public Form8()
        {
            InitializeComponent();
            using (OpenFileDialog dialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xls", ValidateNames = true })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    sqlconn.Open();
                    String sql = "SELECT OrderDetail.ID, Orders.OrderID, Item.ItemID, OrderDetail.Quantity, OrderDetail.UnitAmount, Orders.OrderDate, Item.ItemName, Item.Size FROM ((OrderDetail INNER JOIN Orders ON OrderDetail.OrderID = Orders.OrderID) INNER JOIN Item ON OrderDetail.ItemID = Item.ItemID);";
                    command = new SqlCommand(sql, sqlconn);
                    FileStream file = File.Open(dialog.FileName, FileMode.Open, FileAccess.Read);
                    IExcelDataReader reader = ExcelReaderFactory.CreateBinaryReader(file);
                    reader.IsFirstRowAsColumnNames = true;
                    ds =reader.AsDataSet();
                    command.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    sqlconn.Close();
                }
            }
        }

       
    }
}
