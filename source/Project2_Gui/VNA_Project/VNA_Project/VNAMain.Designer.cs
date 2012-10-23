namespace VNA_Project
{
    partial class VNAMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VNAMain));
            this.qButton1 = new Qios.DevSuite.Components.QButton();
            this.qPanel1 = new Qios.DevSuite.Components.QPanel();
            this.qPanel2 = new Qios.DevSuite.Components.QPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.qRibbonCaption1 = new Qios.DevSuite.Components.Ribbon.QRibbonCaption();
            this.qRibbonLaunchBar1 = new Qios.DevSuite.Components.Ribbon.QRibbonLaunchBar();
            this.qRibbonApplicationButton1 = new Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton();
            this.qPanel1.SuspendLayout();
            this.qPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qRibbonCaption1)).BeginInit();
            this.SuspendLayout();
            // 
            // qButton1
            // 
            this.qButton1.Image = null;
            this.qButton1.Location = new System.Drawing.Point(332, 12);
            this.qButton1.Name = "qButton1";
            this.qButton1.Size = new System.Drawing.Size(124, 27);
            this.qButton1.TabIndex = 2;
            this.qButton1.Text = "qButton1";
            this.qButton1.Click += new System.EventHandler(this.qButton1_Click);
            // 
            // qPanel1
            // 
            this.qPanel1.Controls.Add(this.qButton1);
            this.qPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.qPanel1.Location = new System.Drawing.Point(0, 380);
            this.qPanel1.Name = "qPanel1";
            this.qPanel1.Size = new System.Drawing.Size(740, 52);
            this.qPanel1.TabIndex = 3;
            this.qPanel1.Text = "qPanel1";
            // 
            // qPanel2
            // 
            this.qPanel2.Controls.Add(this.dataGridView1);
            this.qPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qPanel2.Location = new System.Drawing.Point(0, 28);
            this.qPanel2.Name = "qPanel2";
            this.qPanel2.Size = new System.Drawing.Size(740, 352);
            this.qPanel2.TabIndex = 4;
            this.qPanel2.Text = "qPanel2";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(738, 350);
            this.dataGridView1.TabIndex = 0;
            // 
            // qRibbonCaption1
            // 
            this.qRibbonCaption1.ApplicationButton = this.qRibbonApplicationButton1;
            this.qRibbonCaption1.Configuration.IconConfiguration.Visible = Qios.DevSuite.Components.QTristateBool.False;
            this.qRibbonCaption1.LaunchBar = this.qRibbonLaunchBar1;
            this.qRibbonCaption1.Location = new System.Drawing.Point(0, 0);
            this.qRibbonCaption1.Name = "qRibbonCaption1";
            this.qRibbonCaption1.Size = new System.Drawing.Size(740, 28);
            this.qRibbonCaption1.TabIndex = 1;
            this.qRibbonCaption1.Text = "VNA Accounting Fixed assets modul - Phân hệ kế toán tài sản cố định";
            // 
            // VNAMain
            // 
            this.BackgroundImageAlign = Qios.DevSuite.Components.QImageAlign.TopMiddle;
            this.BackgroundImageOffset = new System.Drawing.Point(0, 200);
            this.ClientSize = new System.Drawing.Size(740, 432);
            this.Controls.Add(this.qPanel2);
            this.Controls.Add(this.qPanel1);
            this.Controls.Add(this.qRibbonCaption1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VNAMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VNA Accounting Fixed assets modul - Phân hệ kế toán tài sản cố định";
            this.qPanel1.ResumeLayout(false);
            this.qPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qRibbonCaption1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Qios.DevSuite.Components.QButton qButton1;
        private Qios.DevSuite.Components.QPanel qPanel1;
        private Qios.DevSuite.Components.QPanel qPanel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Qios.DevSuite.Components.Ribbon.QRibbonCaption qRibbonCaption1;
        private Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton qRibbonApplicationButton1;
        private Qios.DevSuite.Components.Ribbon.QRibbonLaunchBar qRibbonLaunchBar1;



    }
}