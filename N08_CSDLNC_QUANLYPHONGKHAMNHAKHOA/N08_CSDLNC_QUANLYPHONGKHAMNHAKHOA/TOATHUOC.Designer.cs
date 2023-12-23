namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    partial class TOATHUOC
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
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_ThuocKeDon = new System.Windows.Forms.DataGridView();
            this.txt_TenBN = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_DonVi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_NgayKeDon = new System.Windows.Forms.TextBox();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_ChiDinh = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_TenThuoc = new System.Windows.Forms.TextBox();
            this.txt_DienThoaiBN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_SLThuocKe = new System.Windows.Forms.TextBox();
            this.btn_AddThuoc = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ThuocKeDon)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(276, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 38);
            this.label2.TabIndex = 2;
            this.label2.Text = "TOA THUỐC";
            // 
            // dgv_ThuocKeDon
            // 
            this.dgv_ThuocKeDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ThuocKeDon.Location = new System.Drawing.Point(12, 339);
            this.dgv_ThuocKeDon.Name = "dgv_ThuocKeDon";
            this.dgv_ThuocKeDon.RowHeadersWidth = 51;
            this.dgv_ThuocKeDon.RowTemplate.Height = 24;
            this.dgv_ThuocKeDon.Size = new System.Drawing.Size(720, 435);
            this.dgv_ThuocKeDon.TabIndex = 3;
            this.dgv_ThuocKeDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ThuocKeDon_CellClick);
            // 
            // txt_TenBN
            // 
            this.txt_TenBN.Enabled = false;
            this.txt_TenBN.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenBN.Location = new System.Drawing.Point(363, 86);
            this.txt_TenBN.Name = "txt_TenBN";
            this.txt_TenBN.ReadOnly = true;
            this.txt_TenBN.Size = new System.Drawing.Size(137, 27);
            this.txt_TenBN.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(279, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 20);
            this.label11.TabIndex = 24;
            this.label11.Text = "Bệnh nhân";
            // 
            // txt_DonVi
            // 
            this.txt_DonVi.Enabled = false;
            this.txt_DonVi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DonVi.Location = new System.Drawing.Point(363, 143);
            this.txt_DonVi.Name = "txt_DonVi";
            this.txt_DonVi.ReadOnly = true;
            this.txt_DonVi.Size = new System.Drawing.Size(107, 27);
            this.txt_DonVi.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(517, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Điện thoại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Ngày";
            // 
            // txt_NgayKeDon
            // 
            this.txt_NgayKeDon.Enabled = false;
            this.txt_NgayKeDon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NgayKeDon.Location = new System.Drawing.Point(126, 86);
            this.txt_NgayKeDon.Name = "txt_NgayKeDon";
            this.txt_NgayKeDon.ReadOnly = true;
            this.txt_NgayKeDon.Size = new System.Drawing.Size(130, 27);
            this.txt_NgayKeDon.TabIndex = 27;
            // 
            // btn_Submit
            // 
            this.btn_Submit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Submit.Location = new System.Drawing.Point(616, 298);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(116, 35);
            this.btn_Submit.TabIndex = 36;
            this.btn_Submit.Text = "Xác nhận";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 37;
            this.label4.Text = "Tên Thuốc";
            // 
            // txt_ChiDinh
            // 
            this.txt_ChiDinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ChiDinh.Location = new System.Drawing.Point(126, 205);
            this.txt_ChiDinh.Name = "txt_ChiDinh";
            this.txt_ChiDinh.Size = new System.Drawing.Size(606, 27);
            this.txt_ChiDinh.TabIndex = 42;
            this.txt_ChiDinh.WordWrap = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 208);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 20);
            this.label12.TabIndex = 41;
            this.label12.Text = "Chỉ định";
            // 
            // txt_TenThuoc
            // 
            this.txt_TenThuoc.Enabled = false;
            this.txt_TenThuoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenThuoc.Location = new System.Drawing.Point(126, 143);
            this.txt_TenThuoc.Name = "txt_TenThuoc";
            this.txt_TenThuoc.ReadOnly = true;
            this.txt_TenThuoc.Size = new System.Drawing.Size(130, 27);
            this.txt_TenThuoc.TabIndex = 25;
            // 
            // txt_DienThoaiBN
            // 
            this.txt_DienThoaiBN.Enabled = false;
            this.txt_DienThoaiBN.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DienThoaiBN.Location = new System.Drawing.Point(601, 86);
            this.txt_DienThoaiBN.Name = "txt_DienThoaiBN";
            this.txt_DienThoaiBN.ReadOnly = true;
            this.txt_DienThoaiBN.Size = new System.Drawing.Size(131, 27);
            this.txt_DienThoaiBN.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(279, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 20);
            this.label6.TabIndex = 39;
            this.label6.Text = "Đơn vị";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(517, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 44;
            this.label5.Text = "Số lượng";
            // 
            // txt_SLThuocKe
            // 
            this.txt_SLThuocKe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SLThuocKe.Location = new System.Drawing.Point(601, 143);
            this.txt_SLThuocKe.Name = "txt_SLThuocKe";
            this.txt_SLThuocKe.Size = new System.Drawing.Size(131, 27);
            this.txt_SLThuocKe.TabIndex = 43;
            // 
            // btn_AddThuoc
            // 
            this.btn_AddThuoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddThuoc.Location = new System.Drawing.Point(12, 298);
            this.btn_AddThuoc.Name = "btn_AddThuoc";
            this.btn_AddThuoc.Size = new System.Drawing.Size(115, 35);
            this.btn_AddThuoc.TabIndex = 45;
            this.btn_AddThuoc.Text = "Thêm thuốc";
            this.btn_AddThuoc.UseVisualStyleBackColor = true;
            this.btn_AddThuoc.Click += new System.EventHandler(this.btn_AddThuoc_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Refresh.Location = new System.Drawing.Point(133, 298);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(115, 35);
            this.btn_Refresh.TabIndex = 46;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // TOATHUOC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 786);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.btn_AddThuoc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_SLThuocKe);
            this.Controls.Add(this.txt_ChiDinh);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.txt_NgayKeDon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_DonVi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_TenThuoc);
            this.Controls.Add(this.txt_DienThoaiBN);
            this.Controls.Add(this.txt_TenBN);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dgv_ThuocKeDon);
            this.Controls.Add(this.label2);
            this.Name = "TOATHUOC";
            this.Text = "TOATHUOC";
            this.Load += new System.EventHandler(this.TOATHUOC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ThuocKeDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_ThuocKeDon;
        private System.Windows.Forms.TextBox txt_TenBN;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_DonVi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_NgayKeDon;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_ChiDinh;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_TenThuoc;
        private System.Windows.Forms.TextBox txt_DienThoaiBN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_SLThuocKe;
        private System.Windows.Forms.Button btn_AddThuoc;
        private System.Windows.Forms.Button btn_Refresh;
    }
}