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

        //private string username;
        private string password;

        public string username { get; set; }
        public string MaNhaSi { get; set; }
        public string MaBenhAn { get; set; }


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

        public NHASI(string username)
        {
            InitializeComponent();
            this.username = username;
            this.MaNhaSi = GetMaNhaSiFromDatabase(username);
        }

        private void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            // Xử lý thông điệp được in ra từ SQL Server (bằng PRINT)
            foreach (SqlError error in e.Errors)
            {
                MessageBox.Show(error.Message); // Hiển thị thông điệp trong MessageBox
            }
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

        DataSet LoadData_THUOC_HSBN(string mabenhan)
        {
            int nConn = GetNumConn();
            DataSet data = new DataSet();
            string query = @"SELECT
                    T.MaThuoc AS 'Mã Thuốc',
                    T.TenThuoc AS 'Tên Thuốc',
                    T.ChongChiDinh AS 'Chống Chỉ Định',
                    T.NgayHetHan AS 'Ngày Hết Hạn',
                    T.DonVi AS 'Đơn Vị',
                    T.SLTK AS 'Số Lượng Tồn Kho'
                FROM
                    THUOC T, TOATHUOC TT
                WHERE
                    T.MaThuoc = TT.MaThuoc AND TT.MaBenhAn = @mabenhan";

            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@mabenhan", mabenhan);
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
            LoadDataToTextBoxes();
            dgv_HSBN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_HSBN.Columns.Clear();
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
                MaBenhAn = row.Cells["Mã Bệnh Án"].Value?.ToString() ?? string.Empty;
                txt_maBA.Text = MaBenhAn;
                txt_TenBN.Text = row.Cells["Tên Bệnh Nhân"].Value?.ToString() ?? string.Empty;
                txt_Tuoi.Text = row.Cells["Tuổi"].Value?.ToString() ?? string.Empty;
                txt_GioiTinh.Text = row.Cells["Giới tính"].Value?.ToString() ?? string.Empty;
                txt_Tuoi.Text = row.Cells["Tuổi"].Value?.ToString() ?? string.Empty;
                txt_PayTotalDieuTri.Text = row.Cells["Tổng Tiền Điều Trị"].Value?.ToString() ?? string.Empty;
                txt_TotalDieuTri.Text = row.Cells["Tổng Tiền Thanh Toán"].Value?.ToString() ?? string.Empty;
                txt_SucKhoeRangMieng.Text = row.Cells["Sức Khỏe Răng"].Value?.ToString() ?? string.Empty;
                txt_TinhTrangDiUng.Text = row.Cells["Tình Trạng Dị Ứng"].Value?.ToString() ?? string.Empty;
                txt_GiayGioiThieu.Text = row.Cells["Giấy Giới Thiệu"].Value?.ToString() ?? string.Empty;

                dgv_ThuocKeDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_ThuocKeDon.Columns.Clear();
                dgv_ThuocKeDon.DataSource = LoadData_THUOC_HSBN(MaBenhAn).Tables[0];
            }
        }

        private void btn_ToaThuoc_Click(object sender, EventArgs e)
        {
            TOATHUOC toa = new TOATHUOC(MaBenhAn);
            toa.ShowDialog();
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            int nConn = GetNumConn();

            if (txt_TinhTrangDiUng.Text == "" && txt_SucKhoeRangMieng.Text == "")
            {
                MessageBox.Show("Không có thay đổi");
                return;
            }

            string ttdu = txt_TinhTrangDiUng.Text;
            string skrm = txt_SucKhoeRangMieng.Text;
            string query = $"exec sp_CapNhatHoSoBenhNhan {MaBenhAn}, N'{skrm}', N'{ttdu}'";

            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.InfoMessage += Connection_InfoMessage;
                    command.ExecuteNonQuery();
                    connection.Close();
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
            dgv_HSBN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_HSBN.Columns.Clear();
            dgv_HSBN.DataSource = LoadData_HSBN().Tables[0];
        }

        private void btn_changePass_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(this.username, this.password);
            changePassword.ShowDialog();
        }

        private void btn_ChinhSuaTT_Click(object sender, EventArgs e)
        {

        }

        private void tab_LHCN_Click(object sender, EventArgs e)
        {

        }
    }
}