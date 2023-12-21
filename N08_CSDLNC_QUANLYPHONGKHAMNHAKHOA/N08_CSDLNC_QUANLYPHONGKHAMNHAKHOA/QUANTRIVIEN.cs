using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
        private string username;
        private string password;

        public QUANTRIVIEN()
        {
            InitializeComponent();
        }

        public QUANTRIVIEN(string username, string password)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
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
            string query = "select MaNhaSi as N'Mã Nha Sĩ', HoTenNS as 'Họ và tên', NgSinhNS " +
                "as N'Ngày sinh', DiaChiNS as N'Địa chỉ',TenDangNhap as N'Tên đăng nhập', MatKhau as N'Mật khẩu', " +
                "TinhTrang as N'Tình trạng' from NHASI ns, TAIKHOAN tk where ns.MaNhaSi < 200 and tk.MaTaiKhoan = ns.MaNhaSi";
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
            string query = "select MaThuoc as N'Mã thuốc', TenThuoc as N'Tên thuốc', DonVi as N'Đơn vị', " +
                "ChongChiDinh as N'Chống chỉ định', SLTK, NgayHetHan as N'Ngày hết hạn' from THUOC";
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

        DataSet LoadData_NhanVien()
        {
            int nConn = GetNumConn();
            DataSet data = new DataSet();

            //sql connection
            string query = "select MaNhanVien as N'Mã Nhân Viên', HoTenNV as 'Họ và tên', NgSinhNV as" +
                " N'Ngày sinh', DiaChiNV as N'Địa chỉ',TenDangNhap as N'Tên đăng nhập', MatKhau as N'Mật khẩu', " +
                "TinhTrang as N'Tình trạng' from NHANVIEN nv, TAIKHOAN tk where nv.MaNhanVien < 200 and tk.MaTaiKhoan = nv.MaNhanVien";
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

        DataSet LoadData_DieuTri()
        {
            int nConn = GetNumConn();
            DataSet data = new DataSet();

            //sql connection
            string query = "select MaDieuTri as N'Mã điều trị', TenDieuTri as N'Tên điều trị', MoTa as N'Mô tả', " +
                "PhiDieuTri as N'Phí điều trị' from DIEUTRI";
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.DataSource = LoadData_NhanVien().Tables[0];
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.DataSource = LoadData_DieuTri().Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            int nConn = GetNumConn();
            string query = "";
            DataSet data = new DataSet();
            if (tbxMaNV.Text == "" && tbxTenNV.Text == "" && tbxSdtNV.Text == "")
            {
                MessageBox.Show("Cần nhập thông tin đề tìm kiếm!");
                return;
            }
            if (tbxMaNV.Text != "" && tbxTenNV.Text == "" && tbxSdtNV.Text == "")
            {
                query = $"select MaNhanVien as N'Mã Nhân Viên', HoTenNV as 'Họ và tên', NgSinhNV as N'Ngày sinh', DiaChiNV as N'Địa chỉ',TenDangNhap as N'Tên đăng nhập', MatKhau as N'Mật khẩu', TinhTrang as N'Tình trạng' from NHANVIEN nv, TAIKHOAN tk where nv.MaNhanVien = '{tbxMaNV.Text}' and tk.MaTaiKhoan = nv.MaNhanVien";
            }
            if (tbxMaNV.Text == "" && tbxTenNV.Text != "" && tbxSdtNV.Text == "")
            {
                query = $"select MaNhanVien as N'Mã Nhân Viên', HoTenNV as 'Họ và tên', NgSinhNV as N'Ngày sinh', DiaChiNV as N'Địa chỉ',TenDangNhap as N'Tên đăng nhập', MatKhau as N'Mật khẩu', TinhTrang as N'Tình trạng' from NHANVIEN nv, TAIKHOAN tk where nv.HoTenNV LIKE N'%{tbxTenNV.Text}%' and tk.MaTaiKhoan = nv.MaNhanVien";
            }
            if (tbxMaNV.Text == "" && tbxTenNV.Text == "" && tbxSdtNV.Text != "")
            {
                query = $"select MaNhanVien as N'Mã Nhân Viên', HoTenNV as 'Họ và tên', NgSinhNV as N'Ngày sinh', DiaChiNV as N'Địa chỉ',TenDangNhap as N'Tên đăng nhập', MatKhau as N'Mật khẩu', TinhTrang as N'Tình trạng' from NHANVIEN nv, TAIKHOAN tk where nv.DienThoaiNV = '{tbxSdtNV.Text}' and tk.MaTaiKhoan = nv.MaNhanVien";
            }
            //MessageBox.Show(query);
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();
                //connection.InfoMessage += Connection_InfoMessage;
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                connection.Close();
            }
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.DataSource = data.Tables[0];
            dataGridView1.Refresh();
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            HOME h = new HOME();
            this.Hide();
            h.ShowDialog();
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int nConn = GetNumConn();
            string query = "";
            DataSet data = new DataSet();
            if (tbxTenThuoc.Text == "" && tbxMaThuoc.Text == "") {
                MessageBox.Show("Cần nhập thông tin đề tìm kiếm!");
                return;
            }
            if (tbxTenThuoc.Text == "" && tbxMaThuoc.Text != "")
            {
                query = $"select* from THUOC where MaThuoc = {int.Parse(tbxMaThuoc.Text)}";
            }
            if (tbxTenThuoc.Text != "" && tbxMaThuoc.Text == "")
            {
                query = $"select* from THUOC where TenThuoc LIKE N'%{tbxTenThuoc.Text}%'";
            }
            if (tbxTenThuoc.Text != "" && tbxMaThuoc.Text != "")
            {
                query = $"select* from THUOC where TenThuoc = N'{tbxTenThuoc.Text}' and MaThuoc = {int.Parse(tbxMaThuoc.Text)}";
            }
            //MessageBox.Show(query);
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();
                //connection.InfoMessage += Connection_InfoMessage;
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                connection.Close();
            }
            dgv_DSThuoc.AutoGenerateColumns = true;
            dgv_DSThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_DSThuoc.DataSource = data.Tables[0];
            dgv_DSThuoc.Refresh();
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            ChangePassword chpass = new ChangePassword(this.username, this.password);
            chpass.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dgv_DSNhaSi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_DSNhaSi.DataSource = LoadData_NhaSi().Tables[0];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int nConn = GetNumConn();
            string query = "";
            DataSet data = new DataSet();
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("Cần nhập thông tin đề tìm kiếm!");
                return;
            }
            if (textBox1.Text != "" && textBox2.Text == "" && textBox3.Text == "")
            {
                query = $"select MaNhaSi as N'Mã Nha Sĩ', HoTenNS as 'Họ và tên', NgSinhNS as N'Ngày sinh', DiaChiNS as N'Địa chỉ',TenDangNhap as N'Tên đăng nhập', MatKhau as N'Mật khẩu', TinhTrang as N'Tình trạng' from NHASI ns, TAIKHOAN tk where ns.MaNhaSi = {textBox1.Text} and tk.MaTaiKhoan = ns.MaNhaSi";
            }
            if (textBox1.Text == "" && textBox2.Text != "" && textBox3.Text == "")
            {
                query = $"select MaNhaSi as N'Mã Nha Sĩ', HoTenNS as 'Họ và tên', NgSinhNS as N'Ngày sinh', DiaChiNS as N'Địa chỉ',TenDangNhap as N'Tên đăng nhập', MatKhau as N'Mật khẩu', TinhTrang as N'Tình trạng' from NHASI ns, TAIKHOAN tk where ns.HoTenNS LIKE N'%{textBox2.Text}%' and tk.MaTaiKhoan = ns.MaNhaSi";
            }
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text != "")
            {
                query = $"select MaNhaSi as N'Mã Nha Sĩ', HoTenNS as 'Họ và tên', NgSinhNS as N'Ngày sinh', DiaChiNS as N'Địa chỉ',TenDangNhap as N'Tên đăng nhập', MatKhau as N'Mật khẩu', TinhTrang as N'Tình trạng' from NHASI ns, TAIKHOAN tk where ns.DienThoaiNS = '{textBox3.Text}' and tk.MaTaiKhoan = ns.MaNhaSi";
            }
            //MessageBox.Show(query);
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();
                //connection.InfoMessage += Connection_InfoMessage;
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                connection.Close();
            }
            dgv_DSNhaSi.AutoGenerateColumns = true;
            dgv_DSNhaSi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_DSNhaSi.DataSource = data.Tables[0];
            dgv_DSNhaSi.Refresh();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.DataSource = LoadData_NhanVien().Tables[0];
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int nConn = GetNumConn();
            string query = "";
            DataSet data = new DataSet();
            if (tbxMaDieuTri.Text == "" && tbxTenDieuTri.Text == "")
            {
                MessageBox.Show("Cần nhập thông tin đề tìm kiếm!");
                return;
            }
            if (tbxMaDieuTri.Text != "" && tbxTenDieuTri.Text == "")
            {
                query = $"select MaDieuTri as N'Mã điều trị', TenDieuTri as N'Tên điều trị', MoTa as N'Mô tả', PhiDieuTri as N'Phí điều trị' from DIEUTRI where MaDieuTri = {tbxMaDieuTri.Text}";
            }
            if (tbxMaDieuTri.Text == "" && tbxTenDieuTri.Text != "")
            {
                query = $"select MaDieuTri as N'Mã điều trị', TenDieuTri as N'Tên điều trị', MoTa as N'Mô tả', PhiDieuTri as N'Phí điều trị' from DIEUTRI where TenDieuTri LIKE N'%{tbxTenDieuTri.Text}%'";
            }
            //MessageBox.Show(query);
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();
                //connection.InfoMessage += Connection_InfoMessage;
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                connection.Close();
            }
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.DataSource = data.Tables[0];
            dataGridView2.Refresh();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.DataSource = LoadData_DieuTri().Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dgv_DSNhaSi_SelectionChanged(sender, e);
        }

        private void dgv_DSNhaSi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_DSNhaSi.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_DSNhaSi.SelectedRows[0];
                int colTT = dgv_DSNhaSi.Columns["Tình trạng"].Index;
                int colID = dgv_DSNhaSi.Columns["Mã Nha Sĩ"].Index;
                int idNS = int.Parse(selectedRow.Cells[colID].Value?.ToString());  
                string ttrang = selectedRow.Cells[colTT].Value?.ToString();
                int nConn = GetNumConn();
                string query = "";  
                using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
                {
                    connection.Open();
                    if (ttrang == "enable")
                    {
                        //selectedRow.Cells[colTT].Value = "disable";
                        query = $"update TAIKHOAN set tinhtrang = 'disable' where MaTaiKhoan = {idNS}";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        connection.Close();
                        dgv_DSNhaSi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgv_DSNhaSi.DataSource = LoadData_NhaSi().Tables[0];
                        return;
                    }
                    else
                    {
                        //selectedRow.Cells[colTT].Value = "enable";
                        query = $"update TAIKHOAN set tinhtrang = 'enable' where MaTaiKhoan = {idNS}";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        connection.Close();
                        dgv_DSNhaSi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgv_DSNhaSi.DataSource = LoadData_NhaSi().Tables[0];
                        return;
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Phải chọn 1 dòng để khóa hoặc hủy khóa!!!");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dgv_DSNhanVien_SelectionChanged(sender, e);
        }

        private void dgv_DSNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int colTT = dataGridView1.Columns["Tình trạng"].Index;
                int colID = dataGridView1.Columns["Mã Nhân Viên"].Index;
                int idNV = int.Parse(selectedRow.Cells[colID].Value?.ToString());
                string ttrang = selectedRow.Cells[colTT].Value?.ToString();
                int nConn = GetNumConn();
                string query = "";
                using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
                {
                    connection.Open();
                    if (ttrang == "enable")
                    {
                        //selectedRow.Cells[colTT].Value = "disable";
                        query = $"update TAIKHOAN set tinhtrang = 'disable' where MaTaiKhoan = {idNV}";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        connection.Close();
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridView1.DataSource = LoadData_NhanVien().Tables[0];
                        return;
                    }
                    else
                    {
                        //selectedRow.Cells[colTT].Value = "enable";
                        query = $"update TAIKHOAN set tinhtrang = 'enable' where MaTaiKhoan = {idNV}";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        connection.Close();
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridView1.DataSource = LoadData_NhanVien().Tables[0];
                        return;
                    }

                }
            }
            else
            {
                MessageBox.Show("Phải chọn 1 dòng để khóa hoặc hủy khóa!!!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ThemTaiKhoan ttk = new ThemTaiKhoan();
            ttk.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ThemTaiKhoan ttk = new ThemTaiKhoan();
            ttk.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ThemDieuTri tdt = new ThemDieuTri();    
            tdt.ShowDialog();
        }
    }
}
