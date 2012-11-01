namespace VNA_Project.DANHMUC.LyDoTangGiamTaiSanFolder
{
    partial class frmXuLyDMLyDoTangGiamTaiSan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXuLyDMLyDoTangGiamTaiSan));
            this.qRibbonCaption1 = new Qios.DevSuite.Components.Ribbon.QRibbonCaption();
            this.palRight = new Qios.DevSuite.Components.QPanel();
            this.btnThoat = new Qios.DevSuite.Components.QButton();
            this.qsButton = new Qios.DevSuite.Components.QShape();
            this.btnDongY = new Qios.DevSuite.Components.QButton();
            this.palTop_Center = new Qios.DevSuite.Components.QPanel();
            this.qMarkupLabel4 = new Qios.DevSuite.Components.QMarkupLabel();
            this.cbbLoaiTangGiamTaiSan = new Qios.DevSuite.Components.QComboBox();
            this.qMarkupLabel3 = new Qios.DevSuite.Components.QMarkupLabel();
            this.txtTen = new Qios.DevSuite.Components.QTextBox();
            this.txtMa = new Qios.DevSuite.Components.QTextBox();
            this.qMarkupLabel2 = new Qios.DevSuite.Components.QMarkupLabel();
            this.qMarkupLabel1 = new Qios.DevSuite.Components.QMarkupLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qRibbonCaption1)).BeginInit();
            this.palRight.SuspendLayout();
            this.palTop_Center.SuspendLayout();
            this.SuspendLayout();
            // 
            // qRibbonCaption1
            // 
            this.qRibbonCaption1.Location = new System.Drawing.Point(0, 0);
            this.qRibbonCaption1.Name = "qRibbonCaption1";
            this.qRibbonCaption1.Size = new System.Drawing.Size(794, 28);
            this.qRibbonCaption1.TabIndex = 0;
            this.qRibbonCaption1.Text = "Danh Mục - Lý do tăng giảm tài sản cố định";
            // 
            // palRight
            // 
            this.palRight.Controls.Add(this.btnThoat);
            this.palRight.Controls.Add(this.btnDongY);
            this.palRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.palRight.Location = new System.Drawing.Point(674, 28);
            this.palRight.Name = "palRight";
            this.palRight.Size = new System.Drawing.Size(120, 566);
            this.palRight.TabIndex = 1;
            this.palRight.Text = "qPanel1";
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Shape = this.qsButton;
            this.btnThoat.Image = null;
            this.btnThoat.Location = new System.Drawing.Point(22, 120);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.PaintTransparentBackground = true;
            this.btnThoat.Size = new System.Drawing.Size(75, 45);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // qsButton
            // 
            this.qsButton.BaseShapeType = Qios.DevSuite.Components.QBaseShapeType.RibbonShowDialogButton;
            this.qsButton.ContentBounds = new System.Drawing.Rectangle(2, 2, 14, 11);
            this.qsButton.Items.Add(new Qios.DevSuite.Components.QShapeItem(-5F, 11F, ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left))), true));
            this.qsButton.Items.Add(new Qios.DevSuite.Components.QShapeItem(55F, 31F, ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left))), true));
            this.qsButton.Items.Add(new Qios.DevSuite.Components.QShapeItem(12F, -5F, ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))), true));
            this.qsButton.Items.Add(new Qios.DevSuite.Components.QShapeItem(22F, 12F, 20F, 19F, 19F, 20F, ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right))), true));
            this.qsButton.Items.Add(new Qios.DevSuite.Components.QShapeItem(12F, 22F, ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right))), true));
            // 
            // btnDongY
            // 
            this.btnDongY.Appearance.Shape = this.qsButton;
            this.btnDongY.Image = null;
            this.btnDongY.Location = new System.Drawing.Point(22, 42);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.PaintTransparentBackground = true;
            this.btnDongY.Size = new System.Drawing.Size(75, 45);
            this.btnDongY.TabIndex = 0;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // palTop_Center
            // 
            this.palTop_Center.Controls.Add(this.qMarkupLabel4);
            this.palTop_Center.Controls.Add(this.cbbLoaiTangGiamTaiSan);
            this.palTop_Center.Controls.Add(this.qMarkupLabel3);
            this.palTop_Center.Controls.Add(this.txtTen);
            this.palTop_Center.Controls.Add(this.txtMa);
            this.palTop_Center.Controls.Add(this.qMarkupLabel2);
            this.palTop_Center.Controls.Add(this.qMarkupLabel1);
            this.palTop_Center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palTop_Center.Location = new System.Drawing.Point(0, 28);
            this.palTop_Center.Name = "palTop_Center";
            this.palTop_Center.Size = new System.Drawing.Size(674, 566);
            this.palTop_Center.TabIndex = 2;
            this.palTop_Center.Text = "qPanel2";
            // 
            // qMarkupLabel4
            // 
            this.qMarkupLabel4.Location = new System.Drawing.Point(257, 76);
            this.qMarkupLabel4.MarkupText = "1 - Tăng tài sản, 2- Giảm tài sản";
            this.qMarkupLabel4.Name = "qMarkupLabel4";
            this.qMarkupLabel4.Size = new System.Drawing.Size(194, 15);
            this.qMarkupLabel4.TabIndex = 6;
            // 
            // cbbLoaiTangGiamTaiSan
            // 
            this.cbbLoaiTangGiamTaiSan.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cbbLoaiTangGiamTaiSan.Location = new System.Drawing.Point(185, 71);
            this.cbbLoaiTangGiamTaiSan.Name = "cbbLoaiTangGiamTaiSan";
            this.cbbLoaiTangGiamTaiSan.SelectedIndex = 0;
            this.cbbLoaiTangGiamTaiSan.SelectedItem = "1";
            this.cbbLoaiTangGiamTaiSan.Size = new System.Drawing.Size(47, 21);
            this.cbbLoaiTangGiamTaiSan.TabIndex = 5;
            this.cbbLoaiTangGiamTaiSan.Text = "1";
            // 
            // qMarkupLabel3
            // 
            this.qMarkupLabel3.Location = new System.Drawing.Point(19, 76);
            this.qMarkupLabel3.MarkupText = "Loại tăng giảm tài sản:";
            this.qMarkupLabel3.Name = "qMarkupLabel3";
            this.qMarkupLabel3.Size = new System.Drawing.Size(153, 15);
            this.qMarkupLabel3.TabIndex = 4;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(185, 166);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(460, 21);
            this.txtTen.TabIndex = 3;
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(185, 127);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(460, 21);
            this.txtMa.TabIndex = 2;
            // 
            // qMarkupLabel2
            // 
            this.qMarkupLabel2.Location = new System.Drawing.Point(19, 167);
            this.qMarkupLabel2.MarkupText = "Tên lý do tăng giảm tài sản:";
            this.qMarkupLabel2.Name = "qMarkupLabel2";
            this.qMarkupLabel2.Size = new System.Drawing.Size(153, 15);
            this.qMarkupLabel2.TabIndex = 1;
            // 
            // qMarkupLabel1
            // 
            this.qMarkupLabel1.Location = new System.Drawing.Point(19, 129);
            this.qMarkupLabel1.MarkupText = "Mã lý do tăng giảm tài sản:";
            this.qMarkupLabel1.Name = "qMarkupLabel1";
            this.qMarkupLabel1.Size = new System.Drawing.Size(153, 15);
            this.qMarkupLabel1.TabIndex = 0;
            // 
            // frmXuLyDMLyDoTangGiamTaiSan
            // 
            this.ClientSize = new System.Drawing.Size(794, 594);
            this.Controls.Add(this.palTop_Center);
            this.Controls.Add(this.palRight);
            this.Controls.Add(this.qRibbonCaption1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXuLyDMLyDoTangGiamTaiSan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Mục - Lý do tăng giảm tài sản cố định";
            ((System.ComponentModel.ISupportInitialize)(this.qRibbonCaption1)).EndInit();
            this.palRight.ResumeLayout(false);
            this.palTop_Center.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Qios.DevSuite.Components.Ribbon.QRibbonCaption qRibbonCaption1;
        private Qios.DevSuite.Components.QPanel palRight;
        private Qios.DevSuite.Components.QPanel palTop_Center;
        private Qios.DevSuite.Components.QButton btnThoat;
        private Qios.DevSuite.Components.QButton btnDongY;
        private Qios.DevSuite.Components.QShape qsButton;
        private Qios.DevSuite.Components.QMarkupLabel qMarkupLabel1;
        private Qios.DevSuite.Components.QTextBox txtTen;
        private Qios.DevSuite.Components.QTextBox txtMa;
        private Qios.DevSuite.Components.QMarkupLabel qMarkupLabel2;
        private Qios.DevSuite.Components.QComboBox cbbLoaiTangGiamTaiSan;
        private Qios.DevSuite.Components.QMarkupLabel qMarkupLabel3;
        private Qios.DevSuite.Components.QMarkupLabel qMarkupLabel4;
    }
}