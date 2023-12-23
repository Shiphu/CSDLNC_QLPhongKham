using System;
using System.Collections;
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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    public partial class NHANVIEN : Form
    {
        ConnectionTester conn = new ConnectionTester();
        private int numConn = -1;
        private bool isNumConnInitialized = false;
        private string username;
        private string password;
        private int MaNVQL;

        public NHANVIEN(string username, string password)
        {
            InitializeComponent();
            dtgv_CHYC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_CHYC.DataSource = LoadData_CHYC_BENHNHAN().Tables[0];
            dtgv_BenhNhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_BenhNhan.DataSource = Load_HoSoBenhNhan("*").Tables[0];
            dtgv_DanhSachBenhNhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_DanhSachBenhNhan.DataSource = Load_DSBenhNhan("*").Tables[0];
            this.username = username;
            this.password = password;

            int nConn = GetNumConn();
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();
                string query = $"select HoTenNV, NgSinhNV, DiaChiNV, DienThoaiNV from TAIKHOAN, NHANVIEN WHERE DienThoaiNV='{username}'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Kiểm tra xem có dữ liệu không
                        if (reader.HasRows)
                        {
                            // Đọc dữ liệu từ SqlDataReader
                            while (reader.Read())
                            {
                                string hoTenNV = reader["HoTenNV"].ToString();
                                //DateTime ngSinhNV = Convert.ToDateTime(reader["NgSinhNV"]);
                                string ngSinhNV = reader["NgSinhNV"].ToString();

                                string diaChiNV = reader["DiaChiNV"].ToString();
                                string dienThoaiNV = reader["DienThoaiNV"].ToString();

                                // Sử dụng dữ liệu như mong muốn (ví dụ: hiển thị lên các controls trên form)
                                int viTriKhoangTrang = ngSinhNV.IndexOf(' ');

                                textBox3.Text = hoTenNV;
                                textBox4.Text = ngSinhNV.Substring(0, viTriKhoangTrang);
                                textBox5.Text = diaChiNV;
                                textBox6.Text = dienThoaiNV;
                            }
                        }
                    }
                }

                string query_TimMaNVQL = $"select MaNhanVien from NHANVIEN where DienThoaiNV = '{username}'";
                using (SqlCommand command = new SqlCommand(query_TimMaNVQL, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Kiểm tra xem có dữ liệu không
                        if (reader.HasRows)
                        {
                            // Đọc dữ liệu từ SqlDataReader
                            while (reader.Read())
                            {
                                this.MaNVQL = int.Parse(reader["MaNhanVien"].ToString());
                            }
                        }
                    }
                }
                connection.Close();
            }
        }

        public NHANVIEN()
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
        DataSet LoadData_CHYC_BENHNHAN()
        {
            int nConn = GetNumConn();
            DataSet data = new DataSet();

            //sql connection
            string query = "select ch.MaCHYC, bn.HoTenBN, bn.NgSinhBN, bn.GioiTinhBN, bn.DienThoaiBN, bn.EmailBN, " +
                            "ch.ThoiGianYC, ch.TinhTrangBenh from CH_YEUCAU ch, BENHNHAN bn where ch.MaBenhNhan = bn.MaBenhNhan";
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

        private void dtgv_CHYC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgv_CHYC.Rows.Count)
            {

                DataGridViewRow row = dtgv_CHYC.Rows[e.RowIndex];
                int viTriKhoangTrang = row.Cells["NgSinhBN"].Value.ToString().IndexOf(' ');
                tb1_CHYC.Text = row.Cells["HoTenBN"].Value?.ToString() ?? string.Empty;
                tb2_CHYC.Text = row.Cells["NgSinhBN"].Value?.ToString().Substring(0, viTriKhoangTrang) ?? string.Empty;
                tb3_CHYC.Text = row.Cells["GioiTinhBN"].Value?.ToString() ?? string.Empty;
                tb4_CHYC.Text = row.Cells["DienThoaiBN"].Value?.ToString() ?? string.Empty;
                tb5_CHYC.Text = row.Cells["ThoiGianYC"].Value?.ToString() ?? string.Empty;
                tb6_CHYC.Text = row.Cells["TinhTrangBenh"].Value?.ToString() ?? string.Empty;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dtgv_CHYC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_CHYC.DataSource = LoadData_CHYC_BENHNHAN().Tables[0];
            tb1_CHYC.Text = tb2_CHYC.Text = tb3_CHYC.Text = tb4_CHYC.Text = tb5_CHYC.Text = tb6_CHYC.Text = ""; 
        }

        private void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            // Xử lý thông điệp được in ra từ SQL Server (bằng PRINT)
            foreach (SqlError error in e.Errors)
            {
                MessageBox.Show(error.Message); // Hiển thị thông điệp trong MessageBox
            }
        }


        private void btn_XoaYC_Click(object sender, EventArgs e)
        {
            int nConn = GetNumConn();
            if(textBox2.Text != "")
            {
                int machyc = int.Parse(textBox2.Text);
                    string query = $"exec sp_XoaCHYC {machyc}";
                using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
                {
                    connection.Open();
                    connection.InfoMessage += Connection_InfoMessage;
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        private void btn_DuyetYC_Click(object sender, EventArgs e)
        {
            int nConn = GetNumConn();
            if (textBox2.Text != "")
            {
                int machyc = int.Parse(textBox2.Text);
                string query = $"exec sp_DuyetCHYC {machyc}, {this.MaNVQL}";
                using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
                {
                    connection.Open();
                    connection.InfoMessage += Connection_InfoMessage;
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TaoLichHenBenhNhan taoLichHenBenhNhan = new TaoLichHenBenhNhan();
            taoLichHenBenhNhan.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(this.username, this.password);
            changePassword.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HOME hOME = new HOME();
            this.Hide();
            hOME.ShowDialog();
            this.Close();
        }

        private void btn_RefreshQLHSBN_Click(object sender, EventArgs e)
        {
            dtgv_BenhNhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_BenhNhan.DataSource = Load_HoSoBenhNhan("*").Tables[0];
        }

        private void btn_TimKiemQLHSBN_Click(object sender, EventArgs e)
        {
            if(tb_SDT_QLHSBN.Text != "")
            {
                dtgv_BenhNhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dtgv_BenhNhan.DataSource = Load_HoSoBenhNhan(tb_SDT_QLHSBN.Text).Tables[0];
            }    
        }

        DataSet Load_HoSoBenhNhan(string type)
        {
            int numConn = testConnect();
            DataSet data = new DataSet();
            if (type == "*")
            {
                string query = "select top 200 bn.HoTenBN, hs.MaBenhAn, hs.TongTienDieuTri, hs.TongTienThanhToan, hs.SucKhoeRang, hs.TinhTrangDiUng, hs.MaNVQL from HOSOBENHNHAN hs, BENHNHAN bn WHERE bn.MaBenhNhan = hs.MaBenhNhan";
                using (SqlConnection connection = new SqlConnection(conn.connectionStrings[numConn]))
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(data);

                    connection.Close();
                }
            }   
            else
            {
                string query = $"select bn.HoTenBN, hs.MaBenhAn, hs.TongTienDieuTri, hs.TongTienThanhToan, hs.SucKhoeRang, hs.TinhTrangDiUng, hs.MaNVQL from HOSOBENHNHAN hs, BENHNHAN bn WHERE bn.MaBenhNhan = hs.MaBenhNhan and bn.DienThoaiBN = N'{type}'";
                using (SqlConnection connection = new SqlConnection(conn.connectionStrings[numConn]))
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(data);

                    connection.Close();
                }
            }
            return data;
        }

        private void btn_Refresh_DSBN_Click(object sender, EventArgs e)
        {
            dtgv_DanhSachBenhNhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_DanhSachBenhNhan.DataSource = Load_DSBenhNhan("*").Tables[0];
        }

        private void btn_TimKiem_DSBN_Click(object sender, EventArgs e)
        {
            if (tb_SDT_QLBN.Text != "")
            {
                dtgv_DanhSachBenhNhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dtgv_DanhSachBenhNhan.DataSource = Load_DSBenhNhan(tb_SDT_QLBN.Text).Tables[0];
            }
        }

        DataSet Load_DSBenhNhan(string type)
        {
            int numConn = testConnect();
            DataSet data = new DataSet();
            if (type == "*")
            {
                string query = "select top 200 * from BENHNHAN";
                using (SqlConnection connection = new SqlConnection(conn.connectionStrings[numConn]))
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(data);

                    connection.Close();
                }
            }
            else
            {
                string query = $"select * from BENHNHAN WHERE DienThoaiBN = N'{type}'";
                using (SqlConnection connection = new SqlConnection(conn.connectionStrings[numConn]))
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(data);

                    connection.Close();
                }
            }
            return data;
        }

        private void dtgv_DanhSachBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgv_DanhSachBenhNhan.Rows.Count)
            {

                DataGridViewRow row = dtgv_DanhSachBenhNhan.Rows[e.RowIndex];
                int viTriKhoangTrang = row.Cells["NgSinhBN"].Value.ToString().IndexOf(' ');
                tb1_DSBN.Text = row.Cells["HoTenBN"].Value?.ToString() ?? string.Empty;
                tb2_DSBN.Text = row.Cells["NgSinhBN"].Value?.ToString().Substring(0, viTriKhoangTrang) ?? string.Empty;
                tb3_DSBN.Text = row.Cells["DiaChiBN"].Value?.ToString() ?? string.Empty;
                tb4_DSBN.Text = row.Cells["DienThoaiBN"].Value?.ToString() ?? string.Empty;
                tb5_DSBN.Text = row.Cells["GioiTinhBN"].Value?.ToString() ?? string.Empty;
                tb6_DSBN.Text = row.Cells["EmailBN"].Value?.ToString() ?? string.Empty;

            }
        }

        private void btn_TaoKHDT_Click(object sender, EventArgs e)
        {
            TaoKeHoachDieuTri taoKHDT = new TaoKeHoachDieuTri();
            taoKHDT.ShowDialog();
        }
        private void dtgv_BenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgv_BenhNhan.Rows.Count)
            {
                DataGridViewRow row = dtgv_BenhNhan.Rows[e.RowIndex];
                tb1_HSBN.Text = row.Cells["HoTenBN"].Value?.ToString() ?? string.Empty;
                tb2_HSBN.Text = row.Cells["TongTienDieuTri"].Value?.ToString() ?? string.Empty;
                tb3_HSBN.Text = row.Cells["TongTienThanhToan"].Value?.ToString() ?? string.Empty;
                tb4_HSBN.Text = row.Cells["SucKhoeRang"].Value?.ToString() ?? string.Empty;
                tb5_HSBN.Text = row.Cells["TinhTrangDiUng"].Value?.ToString() ?? string.Empty;

            }
        }

        private void NHANVIEN_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }










        /// KIÊN: THANH TOÁN

        private void txt_SDT_BN_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as System.Windows.Forms.TextBox;
            if (textBox != null)
            {
                var text = textBox.Text;
                bool isPhoneNumber = System.Text.RegularExpressions.Regex.IsMatch(text, @"^\d+$");
                if (!isPhoneNumber)
                {
                    timKiem_KHDT.Enabled = false;
                }
                else
                {
                    timKiem_KHDT.Enabled = true;
                }
            }
        }


        DataSet LoadData_KHDT_BENHNHAN(string phone)
        {
            int numConn = testConnect();
            DataSet data = new DataSet();

            //sql connection
            string query = $"select khdt.mabenhan, khdt.marangkham, khdt.trangthaidieutri, tt.*" +
                $"from thanhtoan tt, kehoachdieutri khdt, hosobenhnhan hsbn, benhnhan bn " +
                $"where bn.dienthoaibn = '{phone}' and bn.mabenhnhan = hsbn.mabenhnhan and hsbn.mabenhan = khdt.mabenhan and khdt.mathanhtoan = tt.mathanhtoan";
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[numConn]))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);

                connection.Close();
            }
            //sql dataAdapter
            return data;
        }

        private string phoneNumber;
        private void timKiem_KHDT_Click(object sender, EventArgs e)
        {
            phoneNumber = txt_SDT_BN.Text;
            ThanhToan_KHDT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ThanhToan_KHDT.DataSource = LoadData_KHDT_BENHNHAN(phoneNumber).Tables[0];
            //if (timKiem_KHDT.Enabled == false)
            //{
            //    button_XuatHD.Enabled = false;
            //}
            //else button_XuatHD.Enabled = true;
        }
        private int mathanhtoan;
        private bool checkTrangThai =false;
        private void ThanhToan_KHDT_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < this.ThanhToan_KHDT.Rows.Count) // Make sure user select at least 1 row 
            { 
                DataGridViewRow row = this.ThanhToan_KHDT.Rows[e.RowIndex];
                if (row.Cells["trangthaidieutri"].Value.ToString() == "đã hoàn thành")
                {
                    checkTrangThai = false;
                    MessageBox.Show("Kế hoạch điều trị đã hoàn thành");

                }
                else
                {
                    checkTrangThai = true;
                    if (row.Cells["NgayGiaoDich"].Value is DBNull || row.Cells["NgayGiaoDich"].Value.ToString() == "")
                    {
                        date_NgayGiaoDich.Value = DateTime.Today;
                    }
                    else
                    {
                        date_NgayGiaoDich.Value = (DateTime)row.Cells["NgayGiaoDich"].Value;
                    }
                    mathanhtoan = (int)row.Cells["MaThanhToan"].Value;
                    radio_cas.Enabled = true;
                    radio_credit.Enabled = true;
                    if (row.Cells["LoaiThanhToan"].Value.ToString() == "")
                    {
                        radio_cas.Checked = false;
                        radio_credit.Checked = false;
                    }
                    //else if (row.Cells["LoaiThanhToan"].Value.ToString() == "cash")
                    //{
                    //    radio_cas.Checked = true;
                    //    radio_credit.Checked = false;
                    //}
                    //else if (row.Cells["LoaiThanhToan"].Value.ToString() == "credit")
                    //{
                    //    radio_cas.Checked = false;
                    //    radio_credit.Checked = true;
                    //}

                    txt_TienCanTT.Text = row.Cells["TienCanThanhToan"].Value.ToString(); // Replace "ColumnName" with the column name you want to access
                    txt_tienThoi.Text = row.Cells["TienThoi"].Value.ToString();
                    txt_TienDaTra.ReadOnly = false;
                    //button_XuatHD.Enabled = true;
                }
            }
            
            
        }
        private string hoTenBN;
        private string hoTenNV;
        private void button_XuatHD_Click(object sender, EventArgs e)
        {

            string date = date_NgayGiaoDich.Value.ToString("yyyy-MM-dd");
            string tienDaTra = txt_TienDaTra.Text;
            string tienThoi = (Int64.Parse(txt_TienDaTra.Text) - Int64.Parse(txt_TienCanTT.Text)).ToString(); 
            string loaiThanhToan = null;

            if (radio_credit.Checked)
            {
                loaiThanhToan = "credit";
            }
            else if (radio_cas.Checked)
            {
                loaiThanhToan = "cash";
            }
            int nConn = GetNumConn();
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[ nConn]))
            {
                connection.Open();

                // First query
                string query = $"update thanhtoan set ngaygiaodich = '{date}', tiendatra = '{tienDaTra}', tienthoi = '{tienThoi}', loaithanhtoan = '{loaiThanhToan}' where mathanhtoan = '{mathanhtoan}'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Second query
                string query1 = $"update kehoachdieutri set trangthaidieutri = N'đã hoàn thành' where MaThanhToan = '{mathanhtoan}'";
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Third query
                string query2 = $"select bn.HoTenBN, nv.HotenNV from kehoachdieutri khdt, HOSOBENHNHAN hsbn, benhnhan bn, nhanvien nv " +
                    $"where khdt.mathanhtoan = '{mathanhtoan}' and khdt.mabenhan = hsbn.mabenhan and hsbn.mabenhnhan = bn.mabenhnhan and nv.manhanvien = '{MaNVQL}'";
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if there are any results
                        if (reader.HasRows)
                        {
                            // Read the results
                            while (reader.Read())
                            {
                                string hoTenBN = reader["HoTenBN"].ToString();
                                string hoTenNV = reader["HotenNV"].ToString();

                                // Use the data as desired
                                // For example, display it on the form
                                this.hoTenBN = hoTenBN;
                                this.hoTenNV = hoTenNV;
                            }
                        }
                    }
                }

                connection.Close();
            }
            HoaDon h = new HoaDon(this.hoTenBN, this.hoTenNV, date,txt_TienCanTT.Text, tienDaTra,tienThoi);
            h.ShowDialog();
            this.Close();
        }

        private bool checkTienDaTra = false;
        private void txt_TienDaTra_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as System.Windows.Forms.TextBox;
            if (textBox != null)
            {
                var text = textBox.Text;
                bool isNumber = System.Text.RegularExpressions.Regex.IsMatch(text, @"^\d+$");
                if (isNumber && text.Length < 20)
                {
                    if (Int64.Parse(txt_TienCanTT.Text) < Int64.Parse(txt_TienDaTra.Text))
                    {
                        checkTienDaTra = true;
                    }
                    else checkTienDaTra = false;
                }
                else checkTienDaTra = false;
            }
            checkenablebutton();
        }

        private bool checkradio = false;
        private void radio_cas_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_cas.Checked && !this.radio_credit.Checked && Int64.Parse(txt_TienCanTT.Text) != 0)
            {
                checkradio = true;
            }
            else checkradio = false;
            checkenablebutton();
        }
        private void radio_credit_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.radio_cas.Checked && this.radio_credit.Checked && Int64.Parse(txt_TienCanTT.Text) != 0)
            {
                checkradio = true;
            }
            else checkradio = false;
            checkenablebutton();
        }

        private void checkenablebutton()
        {
            if ((checkradio && checkTienDaTra ) && checkTrangThai)
            {
                button_XuatHD.Enabled = true;
            }
            else button_XuatHD.Enabled = false;
        }

        
    }


}
