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
    public partial class DATLICHHEN : Form
    {
        public DATLICHHEN()
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

        // Biến kiểm tra nhập text box
        private bool allTBFilled = false;

        // Xử lý sự kiện nhập của từng text box
        private void tb_hoten_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void tb_dienthoai_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void tb_diachi_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void tb_email_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void tb_tinhtrang_TextChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private bool radiocheck = false;

        private void rb_nam_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb_nam.Checked && !this.rb_nu.Checked)
            {
                radiocheck = true;
                ValidateFields();
            }
        }

        private void rb_nu_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb_nu.Checked && !this.rb_nam.Checked)
            {
                radiocheck = true;
                ValidateFields();
            }
        }

        private bool datepickercheck = false;

        private void dp_birth_ValueChanged(object sender, EventArgs e)
        {
            if (this.dp_birth.Value < DateTime.Today && this.dp_appointment.Value.Date > DateTime.Today.Date)
            {
                datepickercheck = true;
                ValidateFields();
            }
            else
            {
                datepickercheck = false;
                ValidateFields();
            }
        }

        private void dp_appointment_ValueChanged(object sender, EventArgs e)
        {
            if (this.dp_birth.Value < DateTime.Today && this.dp_appointment.Value.Date > DateTime.Today.Date)
            {
                datepickercheck = true;
                ValidateFields();
            }
            else
            {
                datepickercheck = false;
                ValidateFields();
            }
        }
      
        private void ValidateFields()
        {
            if (!String.IsNullOrEmpty(tb_hoten.Text) &&
                !String.IsNullOrEmpty(tb_dienthoai.Text) &&
                !String.IsNullOrEmpty(tb_diachi.Text) &&
                !String.IsNullOrEmpty(tb_email.Text) &&
                !String.IsNullOrEmpty(tb_tinhtrang.Text))
            {
                allTBFilled = true;
            }
            else
            {
                allTBFilled = false;
            }


            if (allTBFilled && radiocheck && datepickercheck)
            {
                this.b_datlich.Enabled = allTBFilled;
                this.b_datlich.BackColor = System.Drawing.Color.Red;
                this.b_datlich.Cursor = System.Windows.Forms.Cursors.Default;
                this.b_datlich.Enabled = true;
            }
            else
            {
                this.b_datlich.Enabled = allTBFilled;
                this.b_datlich.BackColor = System.Drawing.SystemColors.AppWorkspace;
                this.b_datlich.Cursor = System.Windows.Forms.Cursors.No;
                this.b_datlich.Enabled = false;
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

        private void b_datlich_Click(object sender, EventArgs e)
        {
            string hoten = this.tb_hoten.Text;
            string gioitinh;
            if (rb_nam.Checked)
            {
                gioitinh = "Nam";
            }
            else gioitinh = "Nữ";
            string ngaysinh = this.dp_birth.Value.ToString("yyyy-MM-dd");
            string dienthoai = this.tb_dienthoai.Text;
            string diachi = this.tb_diachi.Text;
            string email = this.tb_email.Text;
            string ngaydieutri = this.dp_appointment.Value.ToString("yyyy-MM-dd");
            string tinhtrangbenh = this.tb_tinhtrang.Text;
            int nConn = GetNumConn();
            string query = $"exec sp_ThemCuocHenYeuCau N'{hoten}', '{ngaysinh}', N'{diachi}', '{dienthoai}', '{email}', N'{gioitinh}', N'{tinhtrangbenh}', '{ngaydieutri}'";
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();
                connection.InfoMessage += Connection_InfoMessage;
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            this.Hide();
            HOME h = new HOME();
            h.ShowDialog();
            this.Close();
        }

        private void b_quaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            HOME h = new HOME();
            h.ShowDialog();
            this.Close();
        }

    }
}
