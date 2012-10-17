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
            this.qRibbonCaption1 = new Qios.DevSuite.Components.Ribbon.QRibbonCaption();
            this.qRibbonApplicationButton1 = new Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton();
            ((System.ComponentModel.ISupportInitialize)(this.qRibbonCaption1)).BeginInit();
            this.SuspendLayout();
            // 
            // qRibbonCaption1
            // 
            this.qRibbonCaption1.ApplicationButton = this.qRibbonApplicationButton1;
            this.qRibbonCaption1.Location = new System.Drawing.Point(0, 0);
            this.qRibbonCaption1.Name = "qRibbonCaption1";
            this.qRibbonCaption1.Size = new System.Drawing.Size(740, 28);
            this.qRibbonCaption1.TabIndex = 1;
            this.qRibbonCaption1.Text = "VNA Accounting Fixed assets modul - Phân hệ kế toán tài sản cố định";
            // 
            // VNAMain
            // 
            this.ClientSize = new System.Drawing.Size(740, 432);
            this.Controls.Add(this.qRibbonCaption1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VNAMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VNA Accounting Fixed assets modul - Phân hệ kế toán tài sản cố định";
            ((System.ComponentModel.ISupportInitialize)(this.qRibbonCaption1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Qios.DevSuite.Components.Ribbon.QRibbonCaption qRibbonCaption1;
        private Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton qRibbonApplicationButton1;

    }
}