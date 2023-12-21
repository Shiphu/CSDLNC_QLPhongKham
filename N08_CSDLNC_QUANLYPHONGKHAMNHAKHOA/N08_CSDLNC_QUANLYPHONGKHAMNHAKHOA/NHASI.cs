using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WinFormsApp1;
using System.Windows.Input;

namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    public partial class NHASI : Form
    {
        ConnectionTester conn = new ConnectionTester();
        private int numConn = -1;
        private bool isNumConnInitialized = false;
        private string username;
        private string password;
        public string MaNhaSi { get; set; }
        public NHASI()
        {
            InitializeComponent();
        }

        public NHASI(string username, string password)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.MaNhaSi = GetMaNhaSiFromDatabase(username);
        }

        private string GetMaNhaSiFromDatabase(string username)
        {
            string query = $"SELECT MaNhaSi FROM NHASI WHERE DienThoaiNS = {username}";
            string maNhaSi = null;

            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[GetNumConn()]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            maNhaSi = result.ToString();
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("SQL Error: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return maNhaSi;
        }

        private int GetNumConn()
        {
            if (!isNumConnInitialized)
            {
                numConn = conn.TestConnectionsAndGetIndex();
                isNumConnInitialized = true;
            }
            return numConn;
        }

        private void LoadDataToTextBoxes()
        {
            int nConn = GetNumConn();
            string query = $"SELECT * FROM NHASI WHERE DienThoaiNS = {username}";

            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) // Assuming it returns only one row
                    {
                        txt_HoTenNS.Text = reader["HoTenNS"].ToString();
                        DateTime ngSinhDateTime = Convert.ToDateTime(reader["NgSinhNS"]);
                        txt_NgSinhNS.Text = ngSinhDateTime.ToString("dd-MM-yyyy");
                        txt_DThoaiNS.Text = reader["DienThoaiNS"].ToString();
                        txt_DiaChiNS.Text = reader["DiaChiNS"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle the exception (log, display error message, etc.)
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        DataSet LoadData_HSBN()
        {
            int nConn = GetNumConn();
            DataSet data = new DataSet();
            string query = @"SELECT
	HSBN.MaBenhAn AS [Mã Bệnh Án],
	BN.HoTenBN AS [Tên Bệnh Nhân],
	DATEDIFF(YEAR, BN.NgSinhBN, GETDATE()) AS [Tuổi],
	BN.GioiTinhBN AS [Giới tính],
    HSBN.TongTienDieuTri AS [Tổng Tiền Điều Trị],
    HSBN.TongTienThanhToan AS [Tổng Tiền Thanh Toán],
    HSBN.SucKhoeRang AS [Sức Khỏe Răng],
    HSBN.TinhTrangDiUng AS [Tình Trạng Dị Ứng],
    HSBN.GiayGioiThieu AS [Giấy Giới Thiệu]
FROM
    HOSOBENHNHAN HSBN
INNER JOIN KEHOACHDIEUTRI KHDT ON HSBN.MaBenhAn = KHDT.MaBenhAn
INNER JOIN BENHNHAN BN ON BN.MaBenhNhan = HSBN.MaBenhNhan
WHERE
    KHDT.MaNhaSi = @MaNhaSi";

            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNhaSi", MaNhaSi);
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            return data;
        }
        private void NHASI_Load(object sender, EventArgs e)
        {
            LoadDataToTextBoxes(); // Call a method to load data to TextBoxes if needed
            dgv_HSBN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_HSBN.DataSource = LoadData_HSBN().Tables[0];
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            HOME f = new HOME();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void btn_SearchHSBN_Click(object sender, EventArgs e)
        {
            int nConn = GetNumConn();
            string query = "";
            DataSet data = new DataSet();
            if (txt_maBA_search.Text == "")
            {
                MessageBox.Show("Cần nhập thông tin đề tìm kiếm!");
                return;
            }
            else 
            {
                query = $"select MaNhaSi as N'Mã Nha Sĩ', HoTenNS as 'Họ và tên', NgSinhNS as N'Ngày sinh', DiaChiNS as N'Địa chỉ',TenDangNhap as N'Tên đăng nhập', MatKhau as N'Mật khẩu', TinhTrang as N'Tình trạng' from NHASI ns, TAIKHOAN tk where ns.MaNhaSi = {txt_maBA_search.Text} and tk.MaTaiKhoan = ns.MaNhaSi";
            }
            //MessageBox.Show(query);
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                connection.Close();
            }
            dgv_HSBN.AutoGenerateColumns = true;
            dgv_HSBN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_HSBN.DataSource = data.Tables[0];
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            dgv_HSBN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_HSBN.Columns.Clear();
            dgv_HSBN.DataSource = LoadData_HSBN().Tables[0];
        }

        private void dgv_HSBN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgv_HSBN.Rows.Count)
            {
                DataGridViewRow row = dgv_HSBN.Rows[e.RowIndex];

                txt_TenBN.Text = row.Cells["Tên Bệnh Nhân"].Value.ToString();
                txt_Tuoi.Text = row.Cells["Tuổi"].Value.ToString();
                txt_GioiTinh.Text = row.Cells["Giới tính"].Value.ToString();
                txt_Tuoi.Text = row.Cells["Tuổi"].Value.ToString();

            }
        }


    }
}