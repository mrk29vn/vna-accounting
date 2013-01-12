namespace GUI
{
    partial class frmSoquy
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbbnam = new System.Windows.Forms.ComboBox();
            this.cbbthang = new System.Windows.Forms.ComboBox();
            this.lbltheonam = new System.Windows.Forms.Label();
            this.lbltheothang = new System.Windows.Forms.Label();
            this.lbltonghopsodutaikhoan = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslbldieukien = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslnap = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblchitiet = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslchitiet = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslPdf = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslWord = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslExcel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslbltrove = new System.Windows.Forms.ToolStripStatusLabel();
            this.dtgvsoquy = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvsoquy)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.cbbnam);
            this.panel1.Controls.Add(this.cbbthang);
            this.panel1.Controls.Add(this.lbltheonam);
            this.panel1.Controls.Add(this.lbltheothang);
            this.panel1.Controls.Add(this.lbltonghopsodutaikhoan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 62);
            this.panel1.TabIndex = 0;
            this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            this.panel1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDoubleClick);
            // 
            // cbbnam
            // 
            this.cbbnam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbnam.FormattingEnabled = true;
            this.cbbnam.Items.AddRange(new object[] {
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.cbbnam.Location = new System.Drawing.Point(143, 33);
            this.cbbnam.Name = "cbbnam";
            this.cbbnam.Size = new System.Drawing.Size(67, 22);
            this.cbbnam.TabIndex = 55;
            this.cbbnam.SelectedIndexChanged += new System.EventHandler(this.cbbnam_SelectedIndexChanged);
            // 
            // cbbthang
            // 
            this.cbbthang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbthang.FormattingEnabled = true;
            this.cbbthang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbbthang.Location = new System.Drawing.Point(52, 33);
            this.cbbthang.Name = "cbbthang";
            this.cbbthang.Size = new System.Drawing.Size(47, 22);
            this.cbbthang.TabIndex = 54;
            this.cbbthang.SelectedIndexChanged += new System.EventHandler(this.cbbthang_SelectedIndexChanged);
            // 
            // lbltheonam
            // 
            this.lbltheonam.AutoSize = true;
            this.lbltheonam.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltheonam.Location = new System.Drawing.Point(105, 37);
            this.lbltheonam.Name = "lbltheonam";
            this.lbltheonam.Size = new System.Drawing.Size(36, 15);
            this.lbltheonam.TabIndex = 53;
            this.lbltheonam.Text = "Năm:";
            // 
            // lbltheothang
            // 
            this.lbltheothang.AutoSize = true;
            this.lbltheothang.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltheothang.Location = new System.Drawing.Point(5, 37);
            this.lbltheothang.Name = "lbltheothang";
            this.lbltheothang.Size = new System.Drawing.Size(46, 15);
            this.lbltheothang.TabIndex = 52;
            this.lbltheothang.Text = "Tháng:";
            // 
            // lbltonghopsodutaikhoan
            // 
            this.lbltonghopsodutaikhoan.AutoSize = true;
            this.lbltonghopsodutaikhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltonghopsodutaikhoan.ForeColor = System.Drawing.SystemColors.Info;
            this.lbltonghopsodutaikhoan.Location = new System.Drawing.Point(3, 3);
            this.lbltonghopsodutaikhoan.Name = "lbltonghopsodutaikhoan";
            this.lbltonghopsodutaikhoan.Size = new System.Drawing.Size(134, 18);
            this.lbltonghopsodutaikhoan.TabIndex = 0;
            this.lbltonghopsodutaikhoan.Text = "Sổ Quỹ Tiền Mặt";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Controls.Add(this.dtgvsoquy);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(788, 385);
            this.panel2.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslbldieukien,
            this.tsslnap,
            this.tsslblchitiet,
            this.tsslchitiet,
            this.tsslPdf,
            this.tsslWord,
            this.tsslExcel,
            this.tsslbltrove});
            this.statusStrip1.Location = new System.Drawing.Point(0, 359);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(788, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslbldieukien
            // 
            this.tsslbldieukien.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.tsslbldieukien.Image = global::GUI.Properties.Resources.Loc;
            this.tsslbldieukien.Name = "tsslbldieukien";
            this.tsslbldieukien.Size = new System.Drawing.Size(92, 21);
            this.tsslbldieukien.Spring = true;
            this.tsslbldieukien.Text = "Điều kiện";
            this.tsslbldieukien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslbldieukien.Visible = false;
            this.tsslbldieukien.Click += new System.EventHandler(this.tsslbldieukien_Click);
            this.tsslbldieukien.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslbldieukien.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslnap
            // 
            this.tsslnap.Image = global::GUI.Properties.Resources.refresh;
            this.tsslnap.Name = "tsslnap";
            this.tsslnap.Size = new System.Drawing.Size(92, 21);
            this.tsslnap.Spring = true;
            this.tsslnap.Text = "Nạp lại";
            this.tsslnap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslnap.Click += new System.EventHandler(this.tsslnap_Click);
            this.tsslnap.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslnap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslblchitiet
            // 
            this.tsslblchitiet.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.tsslblchitiet.Image = global::GUI.Properties.Resources.Xem_chi_tiet;
            this.tsslblchitiet.Name = "tsslblchitiet";
            this.tsslblchitiet.Size = new System.Drawing.Size(92, 21);
            this.tsslblchitiet.Spring = true;
            this.tsslblchitiet.Text = "Chi tiết";
            this.tsslblchitiet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslblchitiet.Click += new System.EventHandler(this.tsslblchitiet_Click);
            this.tsslblchitiet.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslblchitiet.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslchitiet
            // 
            this.tsslchitiet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tsslchitiet.Image = global::GUI.Properties.Resources.In;
            this.tsslchitiet.Name = "tsslchitiet";
            this.tsslchitiet.Size = new System.Drawing.Size(92, 21);
            this.tsslchitiet.Spring = true;
            this.tsslchitiet.Text = "In";
            this.tsslchitiet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslchitiet.Click += new System.EventHandler(this.tsslchitiet_Click);
            // 
            // tsslPdf
            // 
            this.tsslPdf.Image = global::GUI.Properties.Resources.icon_pdf;
            this.tsslPdf.Name = "tsslPdf";
            this.tsslPdf.Size = new System.Drawing.Size(92, 21);
            this.tsslPdf.Spring = true;
            this.tsslPdf.Text = "PDF";
            this.tsslPdf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslPdf.Click += new System.EventHandler(this.tsslPdf_Click);
            // 
            // tsslWord
            // 
            this.tsslWord.Image = global::GUI.Properties.Resources.DocX_Viewer_icon;
            this.tsslWord.Name = "tsslWord";
            this.tsslWord.Size = new System.Drawing.Size(92, 21);
            this.tsslWord.Spring = true;
            this.tsslWord.Text = "Word";
            this.tsslWord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslWord.Click += new System.EventHandler(this.tsslWord_Click);
            // 
            // tsslExcel
            // 
            this.tsslExcel.Image = global::GUI.Properties.Resources.excel_icon4;
            this.tsslExcel.Name = "tsslExcel";
            this.tsslExcel.Size = new System.Drawing.Size(92, 21);
            this.tsslExcel.Spring = true;
            this.tsslExcel.Text = "Excel";
            this.tsslExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslExcel.Click += new System.EventHandler(this.tsslExcel_Click);
            // 
            // tsslbltrove
            // 
            this.tsslbltrove.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.tsslbltrove.Image = global::GUI.Properties.Resources.Xoa;
            this.tsslbltrove.Name = "tsslbltrove";
            this.tsslbltrove.Size = new System.Drawing.Size(92, 21);
            this.tsslbltrove.Spring = true;
            this.tsslbltrove.Text = "Đóng";
            this.tsslbltrove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslbltrove.Click += new System.EventHandler(this.tsslbltrove_Click);
            this.tsslbltrove.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslbltrove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // dtgvsoquy
            // 
            this.dtgvsoquy.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgvsoquy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvsoquy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvsoquy.Location = new System.Drawing.Point(0, 0);
            this.dtgvsoquy.Name = "dtgvsoquy";
            this.dtgvsoquy.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dtgvsoquy.Size = new System.Drawing.Size(788, 385);
            this.dtgvsoquy.TabIndex = 0;
            this.dtgvsoquy.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvsoquy_CellClick);
            this.dtgvsoquy.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvsoquy_CellDoubleClick);
            // 
            // frmSoquy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 447);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSoquy";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmSoquy_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvsoquy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbltonghopsodutaikhoan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslbldieukien;
        private System.Windows.Forms.ToolStripStatusLabel tsslblchitiet;
        private System.Windows.Forms.ToolStripStatusLabel tsslbltrove;
        private System.Windows.Forms.DataGridView dtgvsoquy;
        private System.Windows.Forms.ComboBox cbbnam;
        private System.Windows.Forms.ComboBox cbbthang;
        private System.Windows.Forms.Label lbltheonam;
        private System.Windows.Forms.Label lbltheothang;
        private System.Windows.Forms.ToolStripStatusLabel tsslnap;
        private System.Windows.Forms.ToolStripStatusLabel tsslchitiet;
        private System.Windows.Forms.ToolStripStatusLabel tsslPdf;
        private System.Windows.Forms.ToolStripStatusLabel tsslWord;
        private System.Windows.Forms.ToolStripStatusLabel tsslExcel;
    }
}