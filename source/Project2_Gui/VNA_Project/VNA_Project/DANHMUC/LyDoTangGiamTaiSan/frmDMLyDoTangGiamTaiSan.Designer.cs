namespace VNA_Project.DANHMUC.NguonVon
{
    partial class frmDMLyDoTangGiamTaiSan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMLyDoTangGiamTaiSan));
            this.qRibbonCaption1 = new Qios.DevSuite.Components.Ribbon.QRibbonCaption();
            this.palRight = new Qios.DevSuite.Components.QPanel();
            this.btnThoat = new Qios.DevSuite.Components.QButton();
            this.qsButton = new Qios.DevSuite.Components.QShape();
            this.btnXoa = new Qios.DevSuite.Components.QButton();
            this.btnSua = new Qios.DevSuite.Components.QButton();
            this.btnThem = new Qios.DevSuite.Components.QButton();
            this.palTop_Center = new Qios.DevSuite.Components.QPanel();
            this.palCenter = new Qios.DevSuite.Components.QPanel();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.palTop = new Qios.DevSuite.Components.QPanel();
            ((System.ComponentModel.ISupportInitialize)(this.qRibbonCaption1)).BeginInit();
            this.palRight.SuspendLayout();
            this.palTop_Center.SuspendLayout();
            this.palCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // qRibbonCaption1
            // 
            this.qRibbonCaption1.Location = new System.Drawing.Point(0, 0);
            this.qRibbonCaption1.Name = "qRibbonCaption1";
            this.qRibbonCaption1.Size = new System.Drawing.Size(794, 28);
            this.qRibbonCaption1.TabIndex = 0;
            this.qRibbonCaption1.Text = "Danh Mục - Lý do tăng giảm tài sản";
            // 
            // palRight
            // 
            this.palRight.Controls.Add(this.btnThoat);
            this.palRight.Controls.Add(this.btnXoa);
            this.palRight.Controls.Add(this.btnSua);
            this.palRight.Controls.Add(this.btnThem);
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
            this.btnThoat.Location = new System.Drawing.Point(22, 254);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.PaintTransparentBackground = true;
            this.btnThoat.Size = new System.Drawing.Size(75, 45);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
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
            // btnXoa
            // 
            this.btnXoa.Appearance.Shape = this.qsButton;
            this.btnXoa.Image = null;
            this.btnXoa.Location = new System.Drawing.Point(22, 180);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.PaintTransparentBackground = true;
            this.btnXoa.Size = new System.Drawing.Size(75, 45);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            // 
            // btnSua
            // 
            this.btnSua.Appearance.Shape = this.qsButton;
            this.btnSua.Image = null;
            this.btnSua.Location = new System.Drawing.Point(22, 110);
            this.btnSua.Name = "btnSua";
            this.btnSua.PaintTransparentBackground = true;
            this.btnSua.Size = new System.Drawing.Size(75, 45);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Shape = this.qsButton;
            this.btnThem.Image = null;
            this.btnThem.Location = new System.Drawing.Point(22, 42);
            this.btnThem.Name = "btnThem";
            this.btnThem.PaintTransparentBackground = true;
            this.btnThem.Size = new System.Drawing.Size(75, 45);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            // 
            // palTop_Center
            // 
            this.palTop_Center.Controls.Add(this.palCenter);
            this.palTop_Center.Controls.Add(this.palTop);
            this.palTop_Center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palTop_Center.Location = new System.Drawing.Point(0, 28);
            this.palTop_Center.Name = "palTop_Center";
            this.palTop_Center.Size = new System.Drawing.Size(674, 566);
            this.palTop_Center.TabIndex = 2;
            this.palTop_Center.Text = "qPanel2";
            // 
            // palCenter
            // 
            this.palCenter.Controls.Add(this.DataGridView);
            this.palCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palCenter.Location = new System.Drawing.Point(0, 93);
            this.palCenter.Name = "palCenter";
            this.palCenter.Size = new System.Drawing.Size(672, 471);
            this.palCenter.TabIndex = 1;
            this.palCenter.Text = "qPanel2";
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.AllowUserToDeleteRows = false;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView.Location = new System.Drawing.Point(0, 0);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.ReadOnly = true;
            this.DataGridView.Size = new System.Drawing.Size(670, 469);
            this.DataGridView.TabIndex = 0;
            // 
            // palTop
            // 
            this.palTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.palTop.Location = new System.Drawing.Point(0, 0);
            this.palTop.Name = "palTop";
            this.palTop.Size = new System.Drawing.Size(672, 93);
            this.palTop.TabIndex = 0;
            this.palTop.Text = "qPanel1";
            // 
            // frmDMLyDoTangGiamTaiSan
            // 
            this.ClientSize = new System.Drawing.Size(794, 594);
            this.Controls.Add(this.palTop_Center);
            this.Controls.Add(this.palRight);
            this.Controls.Add(this.qRibbonCaption1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDMLyDoTangGiamTaiSan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Mục - Lý do tăng giảm tài sản";
            ((System.ComponentModel.ISupportInitialize)(this.qRibbonCaption1)).EndInit();
            this.palRight.ResumeLayout(false);
            this.palTop_Center.ResumeLayout(false);
            this.palCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Qios.DevSuite.Components.Ribbon.QRibbonCaption qRibbonCaption1;
        private Qios.DevSuite.Components.QPanel palRight;
        private Qios.DevSuite.Components.QPanel palTop_Center;
        private Qios.DevSuite.Components.QPanel palCenter;
        private Qios.DevSuite.Components.QPanel palTop;
        private System.Windows.Forms.DataGridView DataGridView;
        private Qios.DevSuite.Components.QButton btnThoat;
        private Qios.DevSuite.Components.QButton btnXoa;
        private Qios.DevSuite.Components.QButton btnSua;
        private Qios.DevSuite.Components.QButton btnThem;
        private Qios.DevSuite.Components.QShape qsButton;
    }
}