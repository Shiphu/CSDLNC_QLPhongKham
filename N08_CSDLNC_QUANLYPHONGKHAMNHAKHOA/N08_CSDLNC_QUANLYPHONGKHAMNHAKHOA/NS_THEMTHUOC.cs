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
    public partial class NS_THEMTHUOC : Form
    {
        ConnectionTester conn = new ConnectionTester();
        private int numConn = -1;
        private bool isNumConnInitialized = false;
        public string Mabenhan { get; set; }

        private int GetNumConn()
        {
            if (!isNumConnInitialized)
            {
                numConn = conn.TestConnectionsAndGetIndex();
                isNumConnInitialized = true;
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

        public NS_THEMTHUOC()
        {
            InitializeComponent();
        }

        public NS_THEMTHUOC(string mabenhan)
        {
            InitializeComponent();
            Mabenhan = mabenhan;
        }

        private void NS_THEMTHUOC_Load(object sender, EventArgs e)
        {
            dgv_THUOC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_THUOC.Columns.Clear();
            dgv_THUOC.DataSource = LoadData_THUOC().Tables[0];
        }

        DataSet LoadData_THUOC()
        {
            int nConn = GetNumConn();
            DataSet data = new DataSet();
            string query = @"SELECT
                            T.MaThuoc,
                            T.TenThuoc,
                            T.DonVi,
                            T.ChongChiDinh,
                            T.SLTK
                        FROM THUOC T
                        LEFT JOIN TOATHUOC TOA ON T.MaThuoc = TOA.MaThuoc
                        LEFT JOIN HOSOBENHNHAN H ON TOA.MaBenhAn = H.MaBenhAn AND H.MaBenhAn = @mabenhan
                        WHERE TOA.MaThuoc IS NULL
                        ";

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

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            int nConn = GetNumConn();

            if (txt_MaThuoc.Text == "" && txt_SLThuocKe.Text == "" && txt_ChiDinh.Text == "")
            {
                MessageBox.Show("Không có thay đổi");
                return;
            }

            int mba = int.Parse(Mabenhan);
            int mt = int.Parse(txt_MaThuoc.Text);
            int soluong = int.Parse(txt_SLThuocKe.Text);
            string chidinh = txt_ChiDinh.Text;
            string query = $"exec sp_ThemThuocVaoToa {mba}, {mt}, {soluong}, N'{chidinh}'";

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
            dgv_THUOC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_THUOC.Columns.Clear();
            dgv_THUOC.DataSource = LoadData_THUOC().Tables[0];
        }

        private void dgv_THUOC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgv_THUOC.Rows.Count)
            {
                DataGridViewRow row = dgv_THUOC.Rows[e.RowIndex];
                txt_MaThuoc.Text = row.Cells["MaThuoc"].Value?.ToString() ?? string.Empty;
                txt_TenThuoc.Text = row.Cells["TenThuoc"].Value?.ToString() ?? string.Empty;
                txt_DonVi.Text = row.Cells["DonVi"].Value?.ToString() ?? string.Empty;
            }
        }
    }
}
