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
    public partial class TaoKeHoachDieuTri : Form
    {
        ConnectionTester conn = new ConnectionTester();
        private int numConn = -1;
        private bool isNumConnInitialized = false;
        //clb_DTGiaiDoan1_Load();

        public TaoKeHoachDieuTri()
        {
            InitializeComponent();
            LoadDataIntoRangComboBox();
            LoadDataIntoBeMatRangComboBox();
            LoadDataIntoCheckedListBox();
            clb_DTGiaiDoan1.ItemCheck += CheckedListBox_ItemCheck;
            clb_DTGiaiDoan2.ItemCheck += CheckedListBox_ItemCheck;
            clb_DTGiaiDoan3.ItemCheck += CheckedListBox_ItemCheck;
            clb_DTGiaiDoan4.ItemCheck += CheckedListBox_ItemCheck;
            clb_DTGiaiDoan5.ItemCheck += CheckedListBox_ItemCheck;
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
        private void LoadDataIntoRangComboBox()
        {
            int nConn = GetNumConn();
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();

                // Thực hiện truy vấn để lấy dữ liệu từ cột "SoRang"
                string query = "SELECT SoRang FROM RANG";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Xóa dữ liệu cũ (nếu có) trong ComboBox
                        cb_RANG.Items.Clear();

                        // Đổ dữ liệu vào ComboBox
                        while (reader.Read())
                        {
                            cb_RANG.Items.Add(reader["SoRang"].ToString());
                        }
                    }
                }
                connection.Close();
            }
        }
        private void LoadDataIntoBeMatRangComboBox()
        {
            int nConn = GetNumConn();
            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();

                // Thực hiện truy vấn để lấy dữ liệu từ cột "SoRang"
                string query = "SELECT MoTa FROM BEMATRANG";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Xóa dữ liệu cũ (nếu có) trong ComboBox
                        cb_BeMatRang.Items.Clear();

                        // Đổ dữ liệu vào ComboBox
                        while (reader.Read())
                        {
                            cb_BeMatRang.Items.Add(reader["MoTa"].ToString());
                        }
                    }
                }
                connection.Close();
            }
        }


        private void LoadDataIntoCheckedListBox()
        {
            // Thực hiện kết nối đến cơ sở dữ liệu
            int nConn = GetNumConn();
            List<string> tenDieuTriList = new List<string>();

            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();

                // Thực hiện truy vấn để lấy dữ liệu từ cột "SoRang"
                string query = "SELECT TenDieuTri FROM DIEUTRI";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Xóa dữ liệu cũ (nếu có) trong ComboBox

                        // Đổ dữ liệu vào ComboBox
                        while (reader.Read())
                        {
                            string tenDieuTri = reader["TenDieuTri"].ToString();
                            tenDieuTriList.Add(tenDieuTri);
                        }
                        clb_DTGiaiDoan1.Items.AddRange(tenDieuTriList.ToArray());
                        clb_DTGiaiDoan2.Items.AddRange(tenDieuTriList.ToArray());
                        clb_DTGiaiDoan3.Items.AddRange(tenDieuTriList.ToArray());
                        clb_DTGiaiDoan4.Items.AddRange(tenDieuTriList.ToArray());
                        clb_DTGiaiDoan5.Items.AddRange(tenDieuTriList.ToArray());
                    }
                }
                connection.Close();
            }
        }

        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Kiểm tra xem sự kiện có phải là do người dùng thay đổi trạng thái chọn hay không
            if (e.NewValue == CheckState.Checked)
            {
                // Lấy giá trị của item đang được thay đổi
                string selectedItem = ((CheckedListBox)sender).Items[e.Index].ToString();

                // Ở đây, chúng ta sẽ ẩn item tương ứng trong CheckedListBox khác
                if (sender == clb_DTGiaiDoan1)
                {
                    // Ẩn item trong checkedListBox2
                    clb_DTGiaiDoan2.Items.Remove(selectedItem);
                    clb_DTGiaiDoan3.Items.Remove(selectedItem);
                    clb_DTGiaiDoan4.Items.Remove(selectedItem);
                    clb_DTGiaiDoan5.Items.Remove(selectedItem);
                }
                else if (sender == clb_DTGiaiDoan2)
                {
                    // Ẩn item trong checkedListBox1
                    clb_DTGiaiDoan1.Items.Remove(selectedItem);
                    clb_DTGiaiDoan3.Items.Remove(selectedItem);
                    clb_DTGiaiDoan4.Items.Remove(selectedItem);
                    clb_DTGiaiDoan5.Items.Remove(selectedItem);
                }
                else if (sender == clb_DTGiaiDoan3)
                {
                    // Ẩn item trong checkedListBox1
                    clb_DTGiaiDoan1.Items.Remove(selectedItem);
                    clb_DTGiaiDoan2.Items.Remove(selectedItem);
                    clb_DTGiaiDoan4.Items.Remove(selectedItem);
                    clb_DTGiaiDoan5.Items.Remove(selectedItem);
                }
                else if (sender == clb_DTGiaiDoan4)
                {
                    clb_DTGiaiDoan1.Items.Remove(selectedItem);
                    clb_DTGiaiDoan2.Items.Remove(selectedItem);
                    clb_DTGiaiDoan3.Items.Remove(selectedItem);
                    clb_DTGiaiDoan5.Items.Remove(selectedItem);
                }
                else if (sender == clb_DTGiaiDoan5)
                {
                    clb_DTGiaiDoan1.Items.Remove(selectedItem);
                    clb_DTGiaiDoan2.Items.Remove(selectedItem);
                    clb_DTGiaiDoan3.Items.Remove(selectedItem);
                    clb_DTGiaiDoan4.Items.Remove(selectedItem);
                }

            }
            // Nếu giá trị là Unchecked, bạn có thể thực hiện các hành động khác nếu cần.
            else
            {
                string UnselectedItem = ((CheckedListBox)sender).Items[e.Index].ToString();


                // Ở đây, chúng ta sẽ thêm item vào đúng vị trí ban đầu
                if (sender == clb_DTGiaiDoan1)
                {
                    // Lấy vị trí ban đầu của item
                    int originalIndex = clb_DTGiaiDoan1.Items.IndexOf(UnselectedItem);

                    // Chèn item vào vị trí ban đầu
                    clb_DTGiaiDoan2.Items.Insert(originalIndex, UnselectedItem);
                    clb_DTGiaiDoan3.Items.Insert(originalIndex, UnselectedItem);
                    clb_DTGiaiDoan4.Items.Insert(originalIndex, UnselectedItem);
                    clb_DTGiaiDoan5.Items.Insert(originalIndex, UnselectedItem);
                }
                else if (sender == clb_DTGiaiDoan2)
                {
                    // Lấy vị trí ban đầu của item
                    int originalIndex = clb_DTGiaiDoan2.Items.IndexOf(UnselectedItem);

                    // Chèn item vào vị trí ban đầu
                    clb_DTGiaiDoan1.Items.Insert(originalIndex, UnselectedItem);
                    clb_DTGiaiDoan3.Items.Insert(originalIndex, UnselectedItem);
                    clb_DTGiaiDoan4.Items.Insert(originalIndex, UnselectedItem);
                    clb_DTGiaiDoan5.Items.Insert(originalIndex, UnselectedItem);
                }
                else if (sender == clb_DTGiaiDoan3)
                {
                    // Lấy vị trí ban đầu của item
                    int originalIndex = clb_DTGiaiDoan3.Items.IndexOf(UnselectedItem);

                    // Chèn item vào vị trí ban đầu
                    clb_DTGiaiDoan1.Items.Insert(originalIndex, UnselectedItem);
                    clb_DTGiaiDoan2.Items.Insert(originalIndex, UnselectedItem);
                    clb_DTGiaiDoan4.Items.Insert(originalIndex, UnselectedItem);
                    clb_DTGiaiDoan5.Items.Insert(originalIndex, UnselectedItem);
                }
                else if (sender == clb_DTGiaiDoan4)
                {
                    // Lấy vị trí ban đầu của item
                    int originalIndex = clb_DTGiaiDoan4.Items.IndexOf(UnselectedItem);

                    // Chèn item vào vị trí ban đầu
                    clb_DTGiaiDoan1.Items.Insert(originalIndex, UnselectedItem);
                    clb_DTGiaiDoan2.Items.Insert(originalIndex, UnselectedItem);
                    clb_DTGiaiDoan3.Items.Insert(originalIndex, UnselectedItem);
                    clb_DTGiaiDoan5.Items.Insert(originalIndex, UnselectedItem);
                }
                else if (sender == clb_DTGiaiDoan5)
                {
                    // Lấy vị trí ban đầu của item
                    int originalIndex = clb_DTGiaiDoan5.Items.IndexOf(UnselectedItem);

                    // Chèn item vào vị trí ban đầu
                    clb_DTGiaiDoan1.Items.Insert(originalIndex, UnselectedItem);
                    clb_DTGiaiDoan2.Items.Insert(originalIndex, UnselectedItem);
                    clb_DTGiaiDoan3.Items.Insert(originalIndex, UnselectedItem);
                    clb_DTGiaiDoan4.Items.Insert(originalIndex, UnselectedItem);
                }
            }
        }


        private bool isCancelled = false;
        private void btn_TaoKHDT_Click(object sender, EventArgs e)
        {
            CheckedListBox.CheckedItemCollection checkedItems = clb_DTGiaiDoan1.CheckedItems;
            if (cb_RANG.SelectedItem !=  null && cb_BeMatRang.SelectedItem != null && checkedItems.Count != 0)
            {
                if(MessageBox.Show("Bạn đã thật sự muốn tạo kế hoạch điều trị này chứ?", "XÁC NHẬN", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                {
                    isCancelled = true;
                }
                else
                {
                    isTaoKeHoachDieuTri();
                }    
            }    
        }
        private void isTaoKeHoachDieuTri()
        {
            // Tiếp tục quá trình lưu kế hoạch điều trị
            if (isCancelled)
            {
                this.Close();
            }
        }

        private void lb_titleKHDT_Click(object sender, EventArgs e)
        {

        }

        
    }
}
