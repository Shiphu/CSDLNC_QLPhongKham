namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    partial class ThemLHCN
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
            this.button2 = new System.Windows.Forms.Button();
            this.btnThemLHCN = new System.Windows.Forms.Button();
            this.dtpkLHCN = new System.Windows.Forms.DateTimePicker();
            this.tbxMota = new System.Windows.Forms.TextBox();
            this.tbxMaNS = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(153, 251);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 33);
            this.button2.TabIndex = 21;
            this.button2.Text = "Đóng";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnThemLHCN
            // 
            this.btnThemLHCN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemLHCN.Location = new System.Drawing.Point(279, 251);
            this.btnThemLHCN.Name = "btnThemLHCN";
            this.btnThemLHCN.Size = new System.Drawing.Size(100, 33);
            this.btnThemLHCN.TabIndex = 20;
            this.btnThemLHCN.Text = "Thêm";
            this.btnThemLHCN.UseVisualStyleBackColor = true;
            this.btnThemLHCN.Click += new System.EventHandler(this.btnThemLHCN_Click);
            // 
            // dtpkLHCN
            // 
            this.dtpkLHCN.Location = new System.Drawing.Point(132, 138);
            this.dtpkLHCN.Name = "dtpkLHCN";
            this.dtpkLHCN.Size = new System.Drawing.Size(247, 22);
            this.dtpkLHCN.TabIndex = 19;
            // 
            // tbxMota
            // 
            this.tbxMota.Location = new System.Drawing.Point(132, 196);
            this.tbxMota.Name = "tbxMota";
            this.tbxMota.Size = new System.Drawing.Size(247, 22);
            this.tbxMota.TabIndex = 17;
            // 
            // tbxMaNS
            // 
            this.tbxMaNS.Location = new System.Drawing.Point(132, 78);
            this.tbxMaNS.Name = "tbxMaNS";
            this.tbxMaNS.Size = new System.Drawing.Size(159, 22);
            this.tbxMaNS.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "Ngày hẹn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Mô tả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Mã nha sĩ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "THÊM LỊCH HẸN CÁ NHÂN";
            // 
            // ThemLHCN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(400, 306);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnThemLHCN);
            this.Controls.Add(this.dtpkLHCN);
            this.Controls.Add(this.tbxMota);
            this.Controls.Add(this.tbxMaNS);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ThemLHCN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThemLHCN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnThemLHCN;
        private System.Windows.Forms.DateTimePicker dtpkLHCN;
        private System.Windows.Forms.TextBox tbxMota;
        private System.Windows.Forms.TextBox tbxMaNS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}