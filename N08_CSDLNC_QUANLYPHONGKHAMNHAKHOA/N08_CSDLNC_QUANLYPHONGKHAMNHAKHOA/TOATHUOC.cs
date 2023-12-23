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
using N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA;
using WinFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    public partial class TOATHUOC : Form
    {
        ConnectionTester conn = new ConnectionTester();
        private int numConn = -1;
        private bool isNumConnInitialized = false;

        public string Mabenhan { get; set; }
        public string MaThuoc { get; set; }


        public TOATHUOC()
        {
            InitializeComponent();
        }
        public TOATHUOC(string mabenhan)
        {
            InitializeComponent();
            Mabenhan = mabenhan;
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

        private void TOATHUOC_Load(object sender, EventArgs e)
        {
            dgv_ThuocKeDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ThuocKeDon.Columns.Clear();
            dgv_ThuocKeDon.DataSource = LoadData_THUOC_HSBN(Mabenhan).Tables[0];
        }

        DataSet LoadData_THUOC_HSBN(string mabenhan)
        {
            int nConn = GetNumConn();
            DataSet data = new DataSet();
            string query = @"SELECT
					BN.HoTenBN AS 'Tên Bệnh Nhân',
					BN.DienThoaiBN AS 'DT Bệnh Nhân',
                    TT.NgayKeThuoc AS 'Ngày Kê Toa',
                    TT.SoLuong AS 'Số Lượng',
                    TT.ChiDinh AS 'Chỉ Định',
                    T.MaThuoc AS 'Mã Thuốc',
                    T.TenThuoc AS 'Tên Thuốc',
                    T.ChongChiDinh AS 'Chống Chỉ Định',
                    T.NgayHetHan AS 'Ngày Hết Hạn',
                    T.DonVi AS 'Đơn Vị',
                    T.SLTK AS 'Số Lượng Tồn Kho'
                FROM
                    THUOC T, TOATHUOC TT, BENHNHAN BN
                WHERE
					TT.MaBenhAn = @mabenhan AND BN.MaBenhNhan = @mabenhan AND
                    T.MaThuoc = TT.MaThuoc";

            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@mabenhan", Mabenhan);
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

        private void dgv_ThuocKeDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgv_ThuocKeDon.Rows.Count)
            {
                DataGridViewRow row = dgv_ThuocKeDon.Rows[e.RowIndex];
                MaThuoc = row.Cells["Mã Thuốc"].Value?.ToString() ?? string.Empty;
                // Gán giá trị từ DataGridView vào các TextBox tương ứng
                txt_TenBN.Text = row.Cells["Tên Bệnh Nhân"].Value?.ToString() ?? string.Empty;
                txt_DienThoaiBN.Text = row.Cells["DT Bệnh Nhân"].Value?.ToString() ?? string.Empty;
                txt_NgayKeDon.Text = row.Cells["Ngày Kê Toa"].Value?.ToString() ?? string.Empty;
                txt_ChiDinh.Text = row.Cells["Chỉ Định"].Value?.ToString() ?? string.Empty;
                txt_TenThuoc.Text = row.Cells["Tên Thuốc"].Value?.ToString() ?? string.Empty;
                txt_DienThoaiBN.Text = row.Cells["DT Bệnh Nhân"].Value?.ToString() ?? string.Empty;
                txt_SLThuocKe.Text = row.Cells["Số lượng"].Value?.ToString() ?? string.Empty;
                txt_DonVi.Text = row.Cells["Đơn Vị"].Value?.ToString() ?? string.Empty;
            }
        }

        private void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            // Xử lý thông điệp được in ra từ SQL Server (bằng PRINT)
            foreach (SqlError error in e.Errors)
            {
                MessageBox.Show(error.Message); // Hiển thị thông điệp trong MessageBox
            }
        }
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (txt_SLThuocKe.Text == "" && txt_ChiDinh.Text == "")
            {
                MessageBox.Show("Cần điền đầy đủ thông tin");
                return;
            }
            int mba = int.Parse(Mabenhan);
            int mt = int.Parse(MaThuoc);
            int soluong = int.Parse(txt_SLThuocKe.Text);
            int nConn = GetNumConn();
            string chidinh = txt_ChiDinh.Text;
            string query = $"exec sp_SuaToaThuoc {mba}, {mt}, {soluong}, N'{chidinh}'";

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
            dgv_ThuocKeDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ThuocKeDon.Columns.Clear();
            dgv_ThuocKeDon.DataSource = LoadData_THUOC_HSBN(Mabenhan).Tables[0];
        }

        private void btn_AddThuoc_Click(object sender, EventArgs e)
        {
            NS_THEMTHUOC nstt = new NS_THEMTHUOC(Mabenhan);
            nstt.ShowDialog();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            dgv_ThuocKeDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ThuocKeDon.Columns.Clear();
            dgv_ThuocKeDon.DataSource = LoadData_THUOC_HSBN(Mabenhan).Tables[0];
        }
    }
}
