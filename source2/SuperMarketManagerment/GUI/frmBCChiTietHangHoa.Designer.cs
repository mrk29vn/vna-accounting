namespace GUI
{
    partial class FrmBcChiTietHangHoa
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
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslchitiet = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslPdf = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslWord = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslexcel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslthoat = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslchitiet,
            this.tsslPdf,
            this.tsslWord,
            this.tsslexcel,
            this.tsslthoat});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(521, 26);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::GUI.Properties.Resources.refresh;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(79, 21);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Nạp lại";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel1.Visible = false;
            // 
            // tsslchitiet
            // 
            this.tsslchitiet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tsslchitiet.Image = global::GUI.Properties.Resources.In;
            this.tsslchitiet.Name = "tsslchitiet";
            this.tsslchitiet.Size = new System.Drawing.Size(79, 21);
            this.tsslchitiet.Spring = true;
            this.tsslchitiet.Text = "Xem";
            this.tsslchitiet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslchitiet.Click += new System.EventHandler(this.tsslchitiet_Click);
            // 
            // tsslPdf
            // 
            this.tsslPdf.Image = global::GUI.Properties.Resources.icon_pdf;
            this.tsslPdf.Name = "tsslPdf";
            this.tsslPdf.Size = new System.Drawing.Size(79, 21);
            this.tsslPdf.Spring = true;
            this.tsslPdf.Text = "PDF";
            this.tsslPdf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslPdf.Click += new System.EventHandler(this.tsslPdf_Click);
            // 
            // tsslWord
            // 
            this.tsslWord.Image = global::GUI.Properties.Resources.DocX_Viewer_icon;
            this.tsslWord.Name = "tsslWord";
            this.tsslWord.Size = new System.Drawing.Size(79, 21);
            this.tsslWord.Spring = true;
            this.tsslWord.Text = "Word";
            this.tsslWord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslWord.Click += new System.EventHandler(this.tsslWord_Click);
            // 
            // tsslexcel
            // 
            this.tsslexcel.Image = global::GUI.Properties.Resources.excel_icon4;
            this.tsslexcel.Name = "tsslexcel";
            this.tsslexcel.Size = new System.Drawing.Size(79, 21);
            this.tsslexcel.Spring = true;
            this.tsslexcel.Text = "Excel";
            this.tsslexcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslexcel.Click += new System.EventHandler(this.tsslexcel_Click);
            // 
            // tsslthoat
            // 
            this.tsslthoat.Image = global::GUI.Properties.Resources.Xoa;
            this.tsslthoat.Name = "tsslthoat";
            this.tsslthoat.Size = new System.Drawing.Size(79, 21);
            this.tsslthoat.Spring = true;
            this.tsslthoat.Text = "Thoát";
            this.tsslthoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslthoat.Click += new System.EventHandler(this.tsslthoat_Click);
            // 
            // frmBCChiTietHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 26);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FrmBcChiTietHangHoa";
            this.Text = "Báo cáo chi tiết hàng hóa";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslchitiet;
        private System.Windows.Forms.ToolStripStatusLabel tsslPdf;
        private System.Windows.Forms.ToolStripStatusLabel tsslWord;
        private System.Windows.Forms.ToolStripStatusLabel tsslexcel;
        private System.Windows.Forms.ToolStripStatusLabel tsslthoat;
    }
}