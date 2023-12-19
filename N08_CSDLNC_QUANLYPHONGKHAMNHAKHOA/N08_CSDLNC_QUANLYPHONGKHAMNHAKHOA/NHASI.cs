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

namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    public partial class NHASI : Form
    {
        ConnectionTester conn = new ConnectionTester();
        private int numConn = -1;
        private bool isNumConnInitialized = false;

        public NHASI()
        {
            InitializeComponent();
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

        private DataSet LoadData(string query)
        {
            int nConn = GetNumConn();
            DataSet data = new DataSet();

            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);

                connection.Close();
            }
            return data;
        }

        private void LoadDataToTextBoxes()
        {
            int nConn = GetNumConn();
            string query = "SELECT * FROM NHASI WHERE DienThoaiNS = @tendangnhap"; // Your SQL query to fetch specific data

            using (SqlConnection connection = new SqlConnection(conn.connectionStrings[nConn]))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) // Assuming it returns only one row
                {
                    txt_HoTenNS.Text = reader["HoTenNS"].ToString();
                    DateTime ngSinhDateTime = (DateTime)reader["NgSinhNS"];
                    txt_NgSinhNS.Text = ngSinhDateTime.ToString("dd-MM-yyyy");
                    txt_DThoaiNS.Text = reader["DienThoaiNS"].ToString();
                    txt_DiaChiNS.Text = reader["DiaChiNS"].ToString();
                }

                reader.Close();
                connection.Close();
            }
        }

        private void NHASI_Load(object sender, EventArgs e)
        {
            LoadDataToTextBoxes();
        }
    }
}