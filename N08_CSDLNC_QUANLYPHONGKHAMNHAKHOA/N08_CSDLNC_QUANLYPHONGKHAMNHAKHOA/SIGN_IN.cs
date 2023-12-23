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
    public partial class SIGN_IN : Form
    {
        public SIGN_IN()
        {
            InitializeComponent();
        }

        ConnectionTester conn = new ConnectionTester();
        private int numConn = -1;
        private bool isNumConnInitialized = false;

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

        private void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            // Xử lý thông điệp được in ra từ SQL Server (bằng PRINT)
            foreach (SqlError error in e.Errors)
            {
                MessageBox.Show(error.Message); // Hiển thị thông điệp trong MessageBox
            }
        }


        private void btnDangKy_Click(object sender, EventArgs e)
        {
            HOME hOME = new HOME();
            this.Hide();
            hOME.ShowDialog();
            this.Close();
        }

        private List<string> printMessages = new List<string>();

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            int loaiVT = -2;
            int nConn = GetNumConn();

            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.InfoMessage += Connection_InfoMessage; // Đăng ký sự kiện InfoMessage
                using (SqlCommand cmd = new SqlCommand("sp_XacThucTaiKhoan", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số vào stored procedure
                    cmd.Parameters.AddWithValue("@sdt", username);
                    cmd.Parameters.AddWithValue("@matkhau", password);
                    cmd.Parameters.Add("@loaivt", SqlDbType.Int).Direction = ParameterDirection.Output;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    // Lấy giá trị trả về từ biến @loaivt sau khi thực thi stored procedure
                    loaiVT = Convert.ToInt32(cmd.Parameters["@loaivt"].Value);
                }
            }
            if (loaiVT == 0) { }
            //MessageBox.Show("TÀI KHOẢN KHÔNG TỒN TẠI!!! HÃY THỬ LẠI");
            else if (loaiVT == 1)
            {
                QUANTRIVIEN qUANTRIVIEN = new QUANTRIVIEN(username, password);
                this.Hide();
                qUANTRIVIEN.ShowDialog();
                this.Close();
            }
            else if (loaiVT == 2)
            {
                NHASI nHASI = new NHASI(username, password);
                this.Hide();
                nHASI.ShowDialog();
                this.Close();
            }
            else if (loaiVT == 3)
            {
                NHANVIEN nHANVIEN = new NHANVIEN(username, password);
                this.Hide();
                nHANVIEN.ShowDialog();
                this.Close();
            }
            //else
            //    MessageBox.Show("TÀI KHOẢN ĐANG BỊ KHÓA !!!");


        }

        private void SIGN_IN_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(SIGNIN_KEYDOWN);
        }

        private void SIGNIN_KEYDOWN(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                int loaiVT = -2;
                int nConn = GetNumConn();

                using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
                {
                    connection.InfoMessage += Connection_InfoMessage; // Đăng ký sự kiện InfoMessage
                    using (SqlCommand cmd = new SqlCommand("sp_XacThucTaiKhoan", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số vào stored procedure
                        cmd.Parameters.AddWithValue("@sdt", username);
                        cmd.Parameters.AddWithValue("@matkhau", password);
                        cmd.Parameters.Add("@loaivt", SqlDbType.Int).Direction = ParameterDirection.Output;

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();

                        // Lấy giá trị trả về từ biến @loaivt sau khi thực thi stored procedure
                        loaiVT = Convert.ToInt32(cmd.Parameters["@loaivt"].Value);
                    }
                }
                if (loaiVT == 0) {
                    MessageBox.Show("TÀI KHOẢN KHÔNG TỒN TẠI!!! HÃY THỬ LẠI");
                }
                else if (loaiVT == 1)
                {
                    QUANTRIVIEN qUANTRIVIEN = new QUANTRIVIEN(username, password);
                    this.Hide();
                    qUANTRIVIEN.ShowDialog();
                    this.Close();
                }
                else if (loaiVT == 2)
                {
                    NHASI nHASI = new NHASI(username, password);
                    this.Hide();
                    nHASI.ShowDialog();
                    this.Close();
                }
                else if (loaiVT == 3)
                {
                    NHANVIEN nHANVIEN = new NHANVIEN(username, password);
                    this.Hide();
                    nHANVIEN.ShowDialog();
                    this.Close();
                }
                else
                    MessageBox.Show("TÀI KHOẢN ĐANG BỊ KHÓA !!!");
            }
        }
    }
}
