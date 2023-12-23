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
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }
        private string benhnhan;
        private string nhanvien;
        private string ngaygd;
        private string tiencantt;
        private string tiendatra;
        private string tienthoi;
        public HoaDon(string benhnhan, string nhanvien, string ngaygd, string tiencantt, string tiendatra, string tienthoi)
        {
            InitializeComponent();
            this.benhnhan = benhnhan;
            this.nhanvien = nhanvien;
            this.ngaygd = ngaygd;
            this.tiencantt = tiencantt;
            this.tiendatra = tiendatra;
            this.tienthoi = tienthoi;

        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            txt_benhnhan.Text = benhnhan;
            txt_nhanvien.Text = nhanvien;
            txt_ngaygd.Text = ngaygd;
            txt_tongtien.Text = tiencantt;
            txt_tiendatra.Text = tiendatra;
            txt_tienthoi.Text = tienthoi;
        }
    }
}
