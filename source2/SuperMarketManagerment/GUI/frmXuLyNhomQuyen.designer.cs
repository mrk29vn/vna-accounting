namespace GUI
{
    partial class frmXuLyNhomQuyen
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnThemMoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnDong = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenNhomQuyen = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThemMoi,
            this.toolStripStatusLabel5,
            this.btnDong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 125);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(348, 26);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Image = global::GUI.Properties.Resources.Them;
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(151, 21);
            this.btnThemMoi.Spring = true;
            this.btnThemMoi.Text = "Thêm";
            this.btnThemMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            this.btnThemMoi.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.btnThemMoi.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(0, 21);
            this.toolStripStatusLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel5.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // btnDong
            // 
            this.btnDong.Image = global::GUI.Properties.Resources.Xoa;
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(151, 21);
            this.btnDong.Spring = true;
            this.btnDong.Text = "Đóng";
            this.btnDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.btnDong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.btnDong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tên Nhóm Quyền:";
            // 
            // txtTenNhomQuyen
            // 
            this.txtTenNhomQuyen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenNhomQuyen.Location = new System.Drawing.Point(134, 56);
            this.txtTenNhomQuyen.Name = "txtTenNhomQuyen";
            this.txtTenNhomQuyen.Size = new System.Drawing.Size(199, 20);
            this.txtTenNhomQuyen.TabIndex = 1;
            this.txtTenNhomQuyen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenTaiKhoan_KeyPress);
            // 
            // frmXuLyNhomQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 151);
            this.Controls.Add(this.txtTenNhomQuyen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmXuLyNhomQuyen";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Nhóm Quyền";
            this.Load += new System.EventHandler(this.frmThemNguoiDung_Load);
            this.Resize += new System.EventHandler(this.frmXuLyNhomQuyen_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel btnThemMoi;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel btnDong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenNhomQuyen;
    }
}