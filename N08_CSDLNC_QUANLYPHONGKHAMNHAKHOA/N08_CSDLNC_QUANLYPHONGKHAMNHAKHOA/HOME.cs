﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

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

        private void btn_DatLichHen_Click(object sender, EventArgs e)
        {
            DATLICHHEN dlh = new DATLICHHEN();
            this.Hide();
            dlh.ShowDialog();
            this.Close();
        }

        DataSet LoadData_DieuTri()
        {
            DataSet data = new DataSet();

            //sql connection
            string query = "select * from DIEUTRI";
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);

                connection.Close();
            }    
            //sql dataAdapter
            return data;
        }

        private void dtgv_DIEUTRI_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dtgv_DIEUTRI.DataSource = LoadData_DieuTri();
            //dtgv_DIEUTRI.DataMember= "DIEUTRI";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtgv_DIEUTRI.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_DIEUTRI.DataSource = LoadData_DieuTri().Tables[0];
        }
    }
}