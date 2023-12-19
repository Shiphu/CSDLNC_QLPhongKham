using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    public partial class DATLICHHEN : Form
    {
        public DATLICHHEN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ĐẶT LỊCH HẸN THÀNH CÔNG");
            this.Hide();
            HOME h = new HOME();
            h.ShowDialog();
            this.Close();
        }
    }
}
