namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    partial class NHASI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab_NHASI = new System.Windows.Forms.TabControl();
            this.tab_TTCN = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tab_HSBN = new System.Windows.Forms.TabPage();
            this.tab_LHCN = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_HoTenNS = new System.Windows.Forms.Label();
            this.txt_HoTenNS = new System.Windows.Forms.TextBox();
            this.txt_DThoaiNS = new System.Windows.Forms.TextBox();
            this.lbl_DienThoai = new System.Windows.Forms.Label();
            this.txt_NgSinhNS = new System.Windows.Forms.TextBox();
            this.lbl_NgSinhNS = new System.Windows.Forms.Label();
            this.txt_DiaChiNS = new System.Windows.Forms.TextBox();
            this.lbl_DiaChi = new System.Windows.Forms.Label();
            this.btn_suaTTCN = new System.Windows.Forms.Button();
            this.btn_changePass = new System.Windows.Forms.Button();
            this.btn_Logout = new System.Windows.Forms.Button();
            this.tab_NHASI.SuspendLayout();
            this.tab_TTCN.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_NHASI
            // 
            this.tab_NHASI.Controls.Add(this.tab_TTCN);
            this.tab_NHASI.Controls.Add(this.tab_HSBN);
            this.tab_NHASI.Controls.Add(this.tab_LHCN);
            this.tab_NHASI.Location = new System.Drawing.Point(0, 2);
            this.tab_NHASI.Name = "tab_NHASI";
            this.tab_NHASI.SelectedIndex = 0;
            this.tab_NHASI.Size = new System.Drawing.Size(1005, 592);
            this.tab_NHASI.TabIndex = 0;
            // 
            // tab_TTCN
            // 
            this.tab_TTCN.Controls.Add(this.btn_Logout);
            this.tab_TTCN.Controls.Add(this.btn_changePass);
            this.tab_TTCN.Controls.Add(this.btn_suaTTCN);
            this.tab_TTCN.Controls.Add(this.panel2);
            this.tab_TTCN.Controls.Add(this.panel1);
            this.tab_TTCN.Controls.Add(this.label1);
            this.tab_TTCN.Location = new System.Drawing.Point(4, 25);
            this.tab_TTCN.Name = "tab_TTCN";
            this.tab_TTCN.Padding = new System.Windows.Forms.Padding(3);
            this.tab_TTCN.Size = new System.Drawing.Size(997, 563);
            this.tab_TTCN.TabIndex = 0;
            this.tab_TTCN.Text = "Thông tin cá nhân";
            this.tab_TTCN.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(373, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÔNG TIN NHA SĨ";
            // 
            // tab_HSBN
            // 
            this.tab_HSBN.Location = new System.Drawing.Point(4, 25);
            this.tab_HSBN.Name = "tab_HSBN";
            this.tab_HSBN.Padding = new System.Windows.Forms.Padding(3);
            this.tab_HSBN.Size = new System.Drawing.Size(997, 563);
            this.tab_HSBN.TabIndex = 1;
            this.tab_HSBN.Text = "Hồ sơ bệnh nhân";
            this.tab_HSBN.UseVisualStyleBackColor = true;
            // 
            // tab_LHCN
            // 
            this.tab_LHCN.Location = new System.Drawing.Point(4, 25);
            this.tab_LHCN.Name = "tab_LHCN";
            this.tab_LHCN.Size = new System.Drawing.Size(997, 563);
            this.tab_LHCN.TabIndex = 2;
            this.tab_LHCN.Text = "Lịch hẹn";
            this.tab_LHCN.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(60, 179);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 225);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_DiaChiNS);
            this.panel2.Controls.Add(this.lbl_DiaChi);
            this.panel2.Controls.Add(this.txt_NgSinhNS);
            this.panel2.Controls.Add(this.lbl_NgSinhNS);
            this.panel2.Controls.Add(this.txt_DThoaiNS);
            this.panel2.Controls.Add(this.lbl_DienThoai);
            this.panel2.Controls.Add(this.txt_HoTenNS);
            this.panel2.Controls.Add(this.lbl_HoTenNS);
            this.panel2.Location = new System.Drawing.Point(591, 179);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(341, 344);
            this.panel2.TabIndex = 2;
            // 
            // lbl_HoTenNS
            // 
            this.lbl_HoTenNS.AutoSize = true;
            this.lbl_HoTenNS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HoTenNS.Location = new System.Drawing.Point(3, 34);
            this.lbl_HoTenNS.Name = "lbl_HoTenNS";
            this.lbl_HoTenNS.Size = new System.Drawing.Size(73, 20);
            this.lbl_HoTenNS.TabIndex = 0;
            this.lbl_HoTenNS.Text = "Họ và tên";
            // 
            // txt_HoTenNS
            // 
            this.txt_HoTenNS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HoTenNS.Location = new System.Drawing.Point(105, 27);
            this.txt_HoTenNS.Name = "txt_HoTenNS";
            this.txt_HoTenNS.Size = new System.Drawing.Size(206, 27);
            this.txt_HoTenNS.TabIndex = 1;
            // 
            // txt_DThoaiNS
            // 
            this.txt_DThoaiNS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DThoaiNS.Location = new System.Drawing.Point(105, 198);
            this.txt_DThoaiNS.Name = "txt_DThoaiNS";
            this.txt_DThoaiNS.Size = new System.Drawing.Size(206, 27);
            this.txt_DThoaiNS.TabIndex = 3;
            // 
            // lbl_DienThoai
            // 
            this.lbl_DienThoai.AutoSize = true;
            this.lbl_DienThoai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DienThoai.Location = new System.Drawing.Point(3, 205);
            this.lbl_DienThoai.Name = "lbl_DienThoai";
            this.lbl_DienThoai.Size = new System.Drawing.Size(78, 20);
            this.lbl_DienThoai.TabIndex = 2;
            this.lbl_DienThoai.Text = "Điện thoại";
            // 
            // txt_NgSinhNS
            // 
            this.txt_NgSinhNS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NgSinhNS.Location = new System.Drawing.Point(105, 105);
            this.txt_NgSinhNS.Name = "txt_NgSinhNS";
            this.txt_NgSinhNS.Size = new System.Drawing.Size(206, 27);
            this.txt_NgSinhNS.TabIndex = 5;
            // 
            // lbl_NgSinhNS
            // 
            this.lbl_NgSinhNS.AutoSize = true;
            this.lbl_NgSinhNS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NgSinhNS.Location = new System.Drawing.Point(3, 112);
            this.lbl_NgSinhNS.Name = "lbl_NgSinhNS";
            this.lbl_NgSinhNS.Size = new System.Drawing.Size(74, 20);
            this.lbl_NgSinhNS.TabIndex = 4;
            this.lbl_NgSinhNS.Text = "Ngày sinh";
            // 
            // txt_DiaChiNS
            // 
            this.txt_DiaChiNS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DiaChiNS.Location = new System.Drawing.Point(105, 285);
            this.txt_DiaChiNS.Name = "txt_DiaChiNS";
            this.txt_DiaChiNS.Size = new System.Drawing.Size(206, 27);
            this.txt_DiaChiNS.TabIndex = 7;
            // 
            // lbl_DiaChi
            // 
            this.lbl_DiaChi.AutoSize = true;
            this.lbl_DiaChi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DiaChi.Location = new System.Drawing.Point(3, 292);
            this.lbl_DiaChi.Name = "lbl_DiaChi";
            this.lbl_DiaChi.Size = new System.Drawing.Size(55, 20);
            this.lbl_DiaChi.TabIndex = 6;
            this.lbl_DiaChi.Text = "Địa chỉ";
            // 
            // btn_suaTTCN
            // 
            this.btn_suaTTCN.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_suaTTCN.Location = new System.Drawing.Point(809, 136);
            this.btn_suaTTCN.Name = "btn_suaTTCN";
            this.btn_suaTTCN.Size = new System.Drawing.Size(123, 37);
            this.btn_suaTTCN.TabIndex = 3;
            this.btn_suaTTCN.Text = "Sửa thông tin";
            this.btn_suaTTCN.UseVisualStyleBackColor = true;
            // 
            // btn_changePass
            // 
            this.btn_changePass.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_changePass.Location = new System.Drawing.Point(278, 486);
            this.btn_changePass.Name = "btn_changePass";
            this.btn_changePass.Size = new System.Drawing.Size(123, 37);
            this.btn_changePass.TabIndex = 4;
            this.btn_changePass.Text = "Đổi mật khẩu";
            this.btn_changePass.UseVisualStyleBackColor = true;
            // 
            // btn_Logout
            // 
            this.btn_Logout.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Logout.Location = new System.Drawing.Point(60, 486);
            this.btn_Logout.Name = "btn_Logout";
            this.btn_Logout.Size = new System.Drawing.Size(123, 37);
            this.btn_Logout.TabIndex = 5;
            this.btn_Logout.Text = "Đăng xuất";
            this.btn_Logout.UseVisualStyleBackColor = true;
            // 
            // NHASI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 593);
            this.Controls.Add(this.tab_NHASI);
            this.Name = "NHASI";
            this.Text = "NHASI";
            this.Load += new System.EventHandler(this.NHASI_Load);
            this.tab_NHASI.ResumeLayout(false);
            this.tab_TTCN.ResumeLayout(false);
            this.tab_TTCN.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_NHASI;
        private System.Windows.Forms.TabPage tab_TTCN;
        private System.Windows.Forms.TabPage tab_HSBN;
        private System.Windows.Forms.TabPage tab_LHCN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_HoTenNS;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_DiaChiNS;
        private System.Windows.Forms.Label lbl_DiaChi;
        private System.Windows.Forms.TextBox txt_NgSinhNS;
        private System.Windows.Forms.Label lbl_NgSinhNS;
        private System.Windows.Forms.TextBox txt_DThoaiNS;
        private System.Windows.Forms.Label lbl_DienThoai;
        private System.Windows.Forms.TextBox txt_HoTenNS;
        private System.Windows.Forms.Button btn_Logout;
        private System.Windows.Forms.Button btn_changePass;
        private System.Windows.Forms.Button btn_suaTTCN;
    }
}