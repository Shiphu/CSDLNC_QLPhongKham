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
using System.Xml.Linq;
using WinFormsApp1;

namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    public partial class ThemDieuTri : Form
    {
        ConnectionTester conn = new ConnectionTester();
        private int numConn = -1;
        private bool isNumConnInitialized = false;

        public ThemDieuTri()
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbxTenDieuTri.Text == "" || tbxMota.Text == "" || tbxPhiDieuTri.Text == "")
            {
                MessageBox.Show("Phải nhập đầy thủ thông tin để thêm điều trị!!!");
                return;
            }
            else
            {
                int nConn = GetNumConn();
                string query = $"exec sp_themDieuTri N'{tbxTenDieuTri.Text}', N'{tbxMota.Text}', {int.Parse(tbxPhiDieuTri.Text)}";
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            foreach (SqlError error in e.Errors)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
