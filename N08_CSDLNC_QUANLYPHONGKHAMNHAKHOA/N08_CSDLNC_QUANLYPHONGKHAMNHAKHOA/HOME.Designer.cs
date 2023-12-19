namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    partial class HOME
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HOME));
            this.panel_cyan = new System.Windows.Forms.Panel();
            this.btn_DatLichHen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_phongkham = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgv_DIEUTRI = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_cyan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_DIEUTRI)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_cyan
            // 
            this.panel_cyan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel_cyan.Controls.Add(this.btn_DatLichHen);
            this.panel_cyan.Controls.Add(this.label1);
            this.panel_cyan.Controls.Add(this.lb_phongkham);
            this.panel_cyan.Controls.Add(this.pictureBox1);
            this.panel_cyan.Location = new System.Drawing.Point(4, 4);
            this.panel_cyan.Name = "panel_cyan";
            this.panel_cyan.Size = new System.Drawing.Size(814, 106);
            this.panel_cyan.TabIndex = 0;
            // 
            // btn_DatLichHen
            // 
            this.btn_DatLichHen.BackColor = System.Drawing.Color.Red;
            this.btn_DatLichHen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DatLichHen.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_DatLichHen.Location = new System.Drawing.Point(664, 26);
            this.btn_DatLichHen.Name = "btn_DatLichHen";
            this.btn_DatLichHen.Size = new System.Drawing.Size(129, 49);
            this.btn_DatLichHen.TabIndex = 1;
            this.btn_DatLichHen.Text = "ĐẶT HẸN";
            this.btn_DatLichHen.UseVisualStyleBackColor = false;
            this.btn_DatLichHen.Click += new System.EventHandler(this.btn_DatLichHen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nụ cười của bạn, trách nhiệm của chúng tôi";
            // 
            // lb_phongkham
            // 
            this.lb_phongkham.AutoSize = true;
            this.lb_phongkham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_phongkham.ForeColor = System.Drawing.Color.Red;
            this.lb_phongkham.Location = new System.Drawing.Point(110, 26);
            this.lb_phongkham.Name = "lb_phongkham";
            this.lb_phongkham.Size = new System.Drawing.Size(254, 20);
            this.lb_phongkham.TabIndex = 1;
            this.lb_phongkham.Text = "PHÒNG KHÁM RĂNG RỤT RÈ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA.Properties.Resources.teeth_ava;
            this.pictureBox1.Location = new System.Drawing.Point(8, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 111);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(814, 585);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.dtgv_DIEUTRI);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 556);
            this.panel1.TabIndex = 1;
            // 
            // dtgv_DIEUTRI
            // 
            this.dtgv_DIEUTRI.BackgroundColor = System.Drawing.Color.White;
            this.dtgv_DIEUTRI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_DIEUTRI.Location = new System.Drawing.Point(146, 87);
            this.dtgv_DIEUTRI.Name = "dtgv_DIEUTRI";
            this.dtgv_DIEUTRI.Size = new System.Drawing.Size(506, 466);
            this.dtgv_DIEUTRI.TabIndex = 1;
            //this.dtgv_DIEUTRI.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_DIEUTRI_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(226, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(358, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Bảng giá điều trị răng mới nhất năm 2024 ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(566, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HOME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 701);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel_cyan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HOME";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HOME";
            this.panel_cyan.ResumeLayout(false);
            this.panel_cyan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_DIEUTRI)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_cyan;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_DatLichHen;
        private System.Windows.Forms.Label lb_phongkham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtgv_DIEUTRI;
        private System.Windows.Forms.Button button1;
    }
}