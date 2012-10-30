namespace VNA_Project.DANHMUC.NguonVon
{
    partial class frmDMNguonVon
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
            this.qRibbonCaption1 = new Qios.DevSuite.Components.Ribbon.QRibbonCaption();
            this.palRight = new Qios.DevSuite.Components.QPanel();
            this.palTop_Center = new Qios.DevSuite.Components.QPanel();
            this.palTop = new Qios.DevSuite.Components.QPanel();
            this.palCenter = new Qios.DevSuite.Components.QPanel();
            ((System.ComponentModel.ISupportInitialize)(this.qRibbonCaption1)).BeginInit();
            this.palTop_Center.SuspendLayout();
            this.SuspendLayout();
            // 
            // qRibbonCaption1
            // 
            this.qRibbonCaption1.Location = new System.Drawing.Point(0, 0);
            this.qRibbonCaption1.Name = "qRibbonCaption1";
            this.qRibbonCaption1.Size = new System.Drawing.Size(794, 28);
            this.qRibbonCaption1.TabIndex = 0;
            this.qRibbonCaption1.Text = "Danh Mục - Nguồn Vốn";
            // 
            // palRight
            // 
            this.palRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.palRight.Location = new System.Drawing.Point(674, 28);
            this.palRight.Name = "palRight";
            this.palRight.Size = new System.Drawing.Size(120, 566);
            this.palRight.TabIndex = 1;
            this.palRight.Text = "qPanel1";
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
            // palTop
            // 
            this.palTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.palTop.Location = new System.Drawing.Point(0, 0);
            this.palTop.Name = "palTop";
            this.palTop.Size = new System.Drawing.Size(672, 93);
            this.palTop.TabIndex = 0;
            this.palTop.Text = "qPanel1";
            // 
            // palCenter
            // 
            this.palCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palCenter.Location = new System.Drawing.Point(0, 93);
            this.palCenter.Name = "palCenter";
            this.palCenter.Size = new System.Drawing.Size(672, 471);
            this.palCenter.TabIndex = 1;
            this.palCenter.Text = "qPanel2";
            // 
            // frmDMNguonVon
            // 
            this.ClientSize = new System.Drawing.Size(794, 594);
            this.Controls.Add(this.palTop_Center);
            this.Controls.Add(this.palRight);
            this.Controls.Add(this.qRibbonCaption1);
            this.Name = "frmDMNguonVon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Mục - Nguồn Vốn";
            ((System.ComponentModel.ISupportInitialize)(this.qRibbonCaption1)).EndInit();
            this.palTop_Center.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Qios.DevSuite.Components.Ribbon.QRibbonCaption qRibbonCaption1;
        private Qios.DevSuite.Components.QPanel palRight;
        private Qios.DevSuite.Components.QPanel palTop_Center;
        private Qios.DevSuite.Components.QPanel palCenter;
        private Qios.DevSuite.Components.QPanel palTop;
    }
}