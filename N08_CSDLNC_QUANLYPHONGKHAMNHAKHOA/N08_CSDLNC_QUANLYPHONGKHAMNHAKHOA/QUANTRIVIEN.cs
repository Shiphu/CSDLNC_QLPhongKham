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
    public partial class QUANTRIVIEN : Form
    {
        ConnectionTester conn = new ConnectionTester();
        private int numConn = -1;
        private bool isNumConnInitialized = false;

        public QUANTRIVIEN()
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

        DataSet LoadData_NhaSi()
        {
            int nConn = GetNumConn();
            DataSet data = new DataSet();

            //sql connection
            string query = "select * from NHASI where MaNhaSi < 200";
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);

                connection.Close();
            }
            //sql dataAdapter
            return data;
        }

        DataSet LoadData_Thuoc()
        {
            int nConn = GetNumConn();
            DataSet data = new DataSet();

            //sql connection
            string query = "select * from THUOC";
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);

                connection.Close();
            }
            //sql dataAdapter
            return data;
        }


        private void QUANTRIVIEN_Load(object sender, EventArgs e)
        {
            dgv_DSNhaSi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_DSNhaSi.DataSource = LoadData_NhaSi().Tables[0];
            dgv_DSThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_DSThuoc.DataSource = LoadData_Thuoc().Tables[0];

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgv_DSThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_DSThuoc.DataSource = LoadData_Thuoc().Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CapNhatSLTK cnSltk = new CapNhatSLTK();
            cnSltk.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ThemThuoc tt = new ThemThuoc();
            tt.ShowDialog();
        }
    }
}
