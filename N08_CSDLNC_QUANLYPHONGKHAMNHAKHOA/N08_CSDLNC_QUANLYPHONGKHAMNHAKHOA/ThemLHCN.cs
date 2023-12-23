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
using WinFormsApp1;

namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    public partial class ThemLHCN : Form
    {
        ConnectionTester conn = new ConnectionTester();
        private int numConn = -1;
        private bool isNumConnInitialized = false;

        public ThemLHCN()
        {
            InitializeComponent();
        }

        private int testConnect()
        {
            int connectResult = conn.TestConnectionsAndGetIndex();
            return connectResult;
        }

        private int GetNumConn()
        {
            if (!isNumConnInitialized)
            {
                numConn = testConnect(); 
                isNumConnInitialized = true; 
            }
            return numConn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemLHCN_Click(object sender, EventArgs e)
        {
            if (tbxMaNS.Text == "" || tbxMota.Text == "" || dtpkLHCN.Value.ToString("yyyy-MM-dd") == "")
            {
                MessageBox.Show("Cần điền đầy đủ thông tin!!!");
                return;
            }
            int nConn = GetNumConn();
            string dtpk = dtpkLHCN.Value.ToString("yyyy-MM-dd");
            string query = $"exec ADD_LICHHEN_NHASI {int.Parse(tbxMaNS.Text)}, '{dtpk}', N'{tbxMota.Text}'";
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();
                connection.InfoMessage += Connection_InfoMessage;
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            this.Close();
        }

        private void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            // Xử lý thông điệp được in ra từ SQL Server (bằng PRINT)
            foreach (SqlError error in e.Errors)
            {
                MessageBox.Show(error.Message); // Hiển thị thông điệp trong MessageBox
            }
        }
    }
}
