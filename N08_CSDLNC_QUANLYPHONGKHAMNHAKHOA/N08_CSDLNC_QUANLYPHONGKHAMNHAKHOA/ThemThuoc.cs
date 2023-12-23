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
    public partial class ThemThuoc : Form
    {
        ConnectionTester conn = new ConnectionTester();
        private int numConn = -1;
        private bool isNumConnInitialized = false;

        public ThemThuoc()
        {
            InitializeComponent();
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
            if (textBox1.Text == "" || comboBox1.SelectedItem?.ToString() == "" || textBox2.Text == "" || dateTimePicker1.Value.ToString("yyyy-MM-dd") == "")
            {
                MessageBox.Show("Cần điền đầy đủ thông tin!!!");
                return;
            }
            string tenthuoc = textBox1.Text;
            string donvi = comboBox1.SelectedItem?.ToString(); // Sử dụng ?. để kiểm tra null
            string ccd = textBox2.Text;
            string nhh = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            int nConn = GetNumConn();
            string query = $"exec sp_ThemThuocMoi N'{tenthuoc}', N'{donvi}', N'{ccd}', '{nhh}'";
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

        private void ThemThuoc_Load(object sender, EventArgs e)
        {

        }
    }
}
