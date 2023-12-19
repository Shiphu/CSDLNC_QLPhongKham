using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using WinFormsApp1;

namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    public partial class HOME : Form
    {
        public HOME()
        {
            InitializeComponent();
            dtgv_DIEUTRI.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dtgv_DIEUTRI.DataSource = LoadData_DieuTri().Tables[0];
        }

        ConnectionTester conn = new ConnectionTester();

        private int testConnect()
        {
            // Kiểm tra các kết nối và lấy vị trí của connectionString mà kết nối thành công
            int numConnect = conn.TestConnectionsAndGetIndex();

            return numConnect;
        }

        private void btn_DatLichHen_Click(object sender, EventArgs e)
        {
            DATLICHHEN dlh = new DATLICHHEN();
            this.Hide();
            dlh.ShowDialog();
            this.Close();
        }

        DataSet LoadData_DieuTri()
        {
            int numConn = testConnect();
            DataSet data = new DataSet();

            //sql connection
            string query = "select * from DIEUTRI";
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

        private void button1_Click(object sender, EventArgs e)
        {
            dtgv_DIEUTRI.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_DIEUTRI.DataSource = LoadData_DieuTri().Tables[0];
        }
    }
}
