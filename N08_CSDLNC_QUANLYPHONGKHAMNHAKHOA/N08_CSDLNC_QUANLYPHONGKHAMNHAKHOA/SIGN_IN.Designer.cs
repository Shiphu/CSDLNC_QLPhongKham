using System.Windows.Forms;

namespace N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA
{
    partial class SIGN_IN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SIGN_IN));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.username = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btn_QuayLaiHome = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.qmk = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(67, 186);
            this.username.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(98, 16);
            this.username.TabIndex = 0;
            this.username.Text = "Tên đăng nhập";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(180, 182);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(315, 22);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 222);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mật khẩu";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(180, 220);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(315, 22);
            this.textBox2.TabIndex = 3;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhap.Location = new System.Drawing.Point(401, 251);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(93, 30);
            this.btnDangNhap.TabIndex = 5;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btn_QuayLaiHome
            // 
            this.btn_QuayLaiHome.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_QuayLaiHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_QuayLaiHome.Location = new System.Drawing.Point(300, 251);
            this.btn_QuayLaiHome.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btn_QuayLaiHome.Name = "btn_QuayLaiHome";
            this.btn_QuayLaiHome.Size = new System.Drawing.Size(93, 30);
            this.btn_QuayLaiHome.TabIndex = 6;
            this.btn_QuayLaiHome.Text = "Quay Lại";
            this.btn_QuayLaiHome.UseVisualStyleBackColor = false;
            this.btn_QuayLaiHome.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA.Properties.Resources.teeth_ava;
            this.pictureBox1.InitialImage = global::N08_CSDLNC_QUANLYPHONGKHAMNHAKHOA.Properties.Resources.teeth_ava;
            this.pictureBox1.Location = new System.Drawing.Point(4, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // qmk
            // 
            this.qmk.AutoSize = true;
            this.qmk.Location = new System.Drawing.Point(179, 257);
            this.qmk.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.qmk.Name = "qmk";
            this.qmk.Size = new System.Drawing.Size(103, 16);
            this.qmk.TabIndex = 8;
            this.qmk.TabStop = true;
            this.qmk.Text = "Quên mật khẩu?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 102);
            this.panel1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(132, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(319, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nụ cười của bạn, trách nhiệm của chúng tôi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(132, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(308, 32);
            this.label2.TabIndex = 11;
            this.label2.Text = "Phòng Khám Răng Rụt Rè";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(223, 122);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 32);
            this.label5.TabIndex = 11;
            this.label5.Text = "ĐĂNG NHẬP";
            // 
            // SIGN_IN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 320);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.qmk);
            this.Controls.Add(this.btn_QuayLaiHome);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.username);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "SIGN_IN";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐĂNG NHẬP";
            this.Load += new System.EventHandler(this.SIGN_IN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SaveFileDialog saveFileDialog1;
        private Label username;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private Button btnDangNhap;
        private Button btn_QuayLaiHome;
        private PictureBox pictureBox1;
        private LinkLabel qmk;
        private Label label3;
        private Panel panel1;
        private Label label2;
        private Label label4;
        private Label label5;
    }

}

