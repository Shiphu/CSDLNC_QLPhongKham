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
    public partial class ChangePassword : Form
    {
        ConnectionTester conn = new ConnectionTester();
        private int numConn = -1;
        private bool isNumConnInitialized = false;
        private string password;
        private string username;

        public ChangePassword()
        {
            InitializeComponent();
        }

        public ChangePassword(string username, string password)
        {
            InitializeComponent();
            this.password = password;
            this.username = username;
        }

        private int testConnect()
        {
            // Kiểm tra các kết nối và lấy vị trí của connectionString mà kết nối thành công
            int connectResult = conn.TestConnectionsAndGetIndex();
            return connectResult;
        }

        private int GetNumConn()
        {
            if (!isNumConnInitialized) // Nếu numConn chưa được khởi tạo
            {
                numConn = testConnect(); // Gọi hàm testConnect() để lấy giá trị numConn
                isNumConnInitialized = true; // Đánh dấu là numConn đã được khởi tạo
            }
            return numConn;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nConn = GetNumConn();
            string query = "";
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Cần nhập đầy đủ thông tin để đổi mật khẩu!!!");
                return;
            }
            if (textBox1.Text != this.password)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác. Hãy thử lại!!!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            if (textBox2.Text.Length > 50)
            {
                MessageBox.Show("Mật khẩu chỉ chứa tối đa 50 ký tự!!!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            if (textBox2.Text.Contains(" "))
            {
                MessageBox.Show("Mật khẩu không được chứa khoảng trắng!!!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            if (textBox2.Text.Any(c => !char.IsLetterOrDigit(c)))
            {
                MessageBox.Show("Mật khẩu không được phép chứa ký tự đặt biệt!!!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại chưa chính xác!!!");
            }
            if (textBox1.Text == this.password && textBox2.Text == textBox3.Text)
            {
                if (this.username == "0123456789")
                {
                    query = $"update QUANTRIVIEN set MatKhauQTV = '{textBox2.Text}' where TenDangNhapQTV = '{this.username}'";
                }
                else
                {
                    query = $"update TAIKHOAN set MatKhau = '{textBox2.Text}' where TenDangNhap = '{this.username}'";
                }            
                using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                MessageBox.Show("Đổi mật khẩu thành công!!!");
                this.Close();
            }
            //MessageBox.Show(this.password);
            //MessageBox.Show(textBox1.Text + " " + textBox2.Text + " " + textBox3.Text);
        }
    }
}
