namespace VNA_Project.NGHIEPVU.ThoiKhauHaoTaiSanFolder
{
    partial class frmXuLyNVThoiKhauHaoTaiSan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXuLyNVThoiKhauHaoTaiSan));
            this.qRibbonCaption1 = new Qios.DevSuite.Components.Ribbon.QRibbonCaption();
            this.palRight = new Qios.DevSuite.Components.QPanel();
            this.btnThoat = new Qios.DevSuite.Components.QButton();
            this.qsButton = new Qios.DevSuite.Components.QShape();
            this.btnDongY = new Qios.DevSuite.Components.QButton();
            this.palTop_Center = new Qios.DevSuite.Components.QPanel();
            this.qMarkupLabel2 = new Qios.DevSuite.Components.QMarkupLabel();
            this.txtNgayThoiKhauHao = new Qios.DevSuite.Components.QTextBox();
            this.qMarkupLabel4 = new Qios.DevSuite.Components.QMarkupLabel();
            this.lblTenTaiSan = new Qios.DevSuite.Components.QMarkupLabel();
            this.txtMaTaiSan = new Qios.DevSuite.Components.QTextBox();
            this.qMarkupLabel3 = new Qios.DevSuite.Components.QMarkupLabel();
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
            this.qRibbonCaption1.Text = "Nghiệp vụ - Thôi khấu hao tài sản cố định";
            // 
            // palRight
            // 
            this.palRight.Controls.Add(this.btnThoat);
            this.palRight.Controls.Add(this.btnDongY);
            this.palRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.palRight.Location = new System.Drawing.Point(674, 28);
            this.palRight.Name = "palRight";
            this.palRight.Size = new System.Drawing.Size(120, 216);
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
            this.palTop_Center.Controls.Add(this.qMarkupLabel2);
            this.palTop_Center.Controls.Add(this.txtNgayThoiKhauHao);
            this.palTop_Center.Controls.Add(this.qMarkupLabel4);
            this.palTop_Center.Controls.Add(this.lblTenTaiSan);
            this.palTop_Center.Controls.Add(this.txtMaTaiSan);
            this.palTop_Center.Controls.Add(this.qMarkupLabel3);
            this.palTop_Center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palTop_Center.Location = new System.Drawing.Point(0, 28);
            this.palTop_Center.Name = "palTop_Center";
            this.palTop_Center.Size = new System.Drawing.Size(674, 216);
            this.palTop_Center.TabIndex = 2;
            this.palTop_Center.Text = "qPanel2";
            // 
            // qMarkupLabel2
            // 
            this.qMarkupLabel2.Location = new System.Drawing.Point(527, 109);
            this.qMarkupLabel2.MarkupText = "tháng/ngày/năm";
            this.qMarkupLabel2.Name = "qMarkupLabel2";
            this.qMarkupLabel2.Size = new System.Drawing.Size(140, 15);
            this.qMarkupLabel2.TabIndex = 63;
            // 
            // txtNgayThoiKhauHao
            // 
            this.txtNgayThoiKhauHao.Location = new System.Drawing.Point(139, 104);
            this.txtNgayThoiKhauHao.Name = "txtNgayThoiKhauHao";
            this.txtNgayThoiKhauHao.Size = new System.Drawing.Size(382, 21);
            this.txtNgayThoiKhauHao.TabIndex = 62;
            // 
            // qMarkupLabel4
            // 
            this.qMarkupLabel4.Location = new System.Drawing.Point(7, 108);
            this.qMarkupLabel4.MarkupText = "Ngày thôi khấu hao:";
            this.qMarkupLabel4.Name = "qMarkupLabel4";
            this.qMarkupLabel4.Size = new System.Drawing.Size(138, 15);
            this.qMarkupLabel4.TabIndex = 61;
            // 
            // lblTenTaiSan
            // 
            this.lblTenTaiSan.Location = new System.Drawing.Point(527, 71);
            this.lblTenTaiSan.MarkupText = "[ F4 tra cứu ]";
            this.lblTenTaiSan.Name = "lblTenTaiSan";
            this.lblTenTaiSan.Size = new System.Drawing.Size(140, 15);
            this.lblTenTaiSan.TabIndex = 56;
            this.lblTenTaiSan.Tag = "";
            // 
            // txtMaTaiSan
            // 
            this.txtMaTaiSan.Location = new System.Drawing.Point(139, 68);
            this.txtMaTaiSan.Name = "txtMaTaiSan";
            this.txtMaTaiSan.Size = new System.Drawing.Size(382, 21);
            this.txtMaTaiSan.TabIndex = 5;
            this.txtMaTaiSan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaTaiSan_KeyDown);
            // 
            // qMarkupLabel3
            // 
            this.qMarkupLabel3.Location = new System.Drawing.Point(27, 68);
            this.qMarkupLabel3.MarkupText = "Mã tài sản:";
            this.qMarkupLabel3.Name = "qMarkupLabel3";
            this.qMarkupLabel3.Size = new System.Drawing.Size(96, 15);
            this.qMarkupLabel3.TabIndex = 4;
            // 
            // frmXuLyNVThoiKhauHaoTaiSan
            // 
            this.ClientSize = new System.Drawing.Size(794, 244);
            this.Controls.Add(this.palTop_Center);
            this.Controls.Add(this.palRight);
            this.Controls.Add(this.qRibbonCaption1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXuLyNVThoiKhauHaoTaiSan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nghiệp vụ - Thôi khấu hao tài sản cố định";
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
        private Qios.DevSuite.Components.QTextBox txtMaTaiSan;
        private Qios.DevSuite.Components.QMarkupLabel qMarkupLabel3;
        private Qios.DevSuite.Components.QMarkupLabel lblTenTaiSan;
        private Qios.DevSuite.Components.QMarkupLabel qMarkupLabel2;
        private Qios.DevSuite.Components.QTextBox txtNgayThoiKhauHao;
        private Qios.DevSuite.Components.QMarkupLabel qMarkupLabel4;
    }
}