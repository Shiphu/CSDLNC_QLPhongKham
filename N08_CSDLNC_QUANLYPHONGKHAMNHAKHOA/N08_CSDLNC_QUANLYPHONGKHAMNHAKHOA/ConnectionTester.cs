using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class ConnectionTester
    {
        public string[] connectionStrings = new string[]
    {
        "Data Source=SHIPHUDOTCPP;Initial Catalog=CSDLNC_QLPhongKham;Integrated Security=True",
        "Data Source=DESKTOP-U8VK4R9\\MSSQLSERVER2022;Initial Catalog=CSDLNC_QLPhongKham;Integrated Security=true;",
        "Server=DESKTOP-OST9FTB;Database=CSDLNC_QLPhongKham;User Id=sa;Password=123;",
        "Data Source=HUYNHPHUC;Initial Catalog=CSDLNC_QLPhongKham;Integrated Security=True",
        "Data Source=P1293;Initial Catalog=CSDLNC_QLPhongKham;Integrated Security=True"
        // Thêm các connectionString khác ở đây tương ứng với từng người dùng
    };

        public int TestConnectionsAndGetIndex()
        {
            int result = -1;
            Task<int>[] tasks = new Task<int>[connectionStrings.Length];

            for (int i = 0; i < connectionStrings.Length; i++)
            {
                int index = i;
                tasks[i] = Task.Run(() => TestSingleConnection(index));
            }

            Task.WaitAny(tasks);

            foreach (var task in tasks)
            {
                if (task != null && task.IsCompleted && task.Result != -1)
                {
                    result = task.Result;
                    break;
                }
            }

            return result;
        }

        private int TestSingleConnection(int index)
        {
            SqlConnection connection = new SqlConnection(connectionStrings[index]);
            try
            {
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    return index;
                }
                else
                {
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                connection.Close();
            }
            return -1;
        }
    }
}
