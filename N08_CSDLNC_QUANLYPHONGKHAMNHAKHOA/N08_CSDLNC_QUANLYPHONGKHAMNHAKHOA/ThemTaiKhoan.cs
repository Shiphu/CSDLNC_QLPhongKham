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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    public partial class ThemTaiKhoan : Form
    {
        ConnectionTester conn = new ConnectionTester();
        private int numConn = -1;
        private bool isNumConnInitialized = false;

        public ThemTaiKhoan()
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
            this.Close();
        }

        private void btn_TaoTK_Click(object sender, EventArgs e)
        {
            if (tbxName.Text == "" || tbxUsername.Text == "" || tbxPass.Text == "" || (rbtnNV.Checked == false && rbtnNS.Checked == false))
            {
                MessageBox.Show("Phải nhập đầy thủ thông tin để tạo tài khoản!!!");
                return;
            }
            else
            {
                int nConn = GetNumConn();
                string query = "";
                if (rbtnNS.Checked)
                {
                    query = $"exec sp_ThemTaiKhoan '{tbxUsername.Text}', '{tbxPass.Text}', N'{tbxName.Text}', '', '', 'NS'";
                }
                else
                {
                    query = $"exec sp_ThemTaiKhoan '{tbxUsername.Text}', '{tbxPass.Text}', N'{tbxName.Text}', '', '', 'NV'";
                }
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

        private void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            foreach (SqlError error in e.Errors)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
