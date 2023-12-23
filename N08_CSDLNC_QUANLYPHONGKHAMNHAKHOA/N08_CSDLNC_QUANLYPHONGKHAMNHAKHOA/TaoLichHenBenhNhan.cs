using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    public partial class TaoLichHenBenhNhan : Form
    {
        public TaoLichHenBenhNhan()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string PhongKham = cb_PhongKham.SelectedItem as string;
            string MaNhaSi = textBox1.Text;

            if (string.IsNullOrEmpty(MaNhaSi) || PhongKham == null)
            {
                this.Close();
            }
        }
    }
}
