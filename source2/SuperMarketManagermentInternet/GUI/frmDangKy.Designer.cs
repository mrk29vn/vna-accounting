namespace GUI
{
    partial class frmDangKy
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
            this.progressBarTime = new System.Windows.Forms.ProgressBar();
            this.lblMSG = new System.Windows.Forms.Label();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnDungThu = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBarTime
            // 
            this.progressBarTime.Location = new System.Drawing.Point(12, 28);
            this.progressBarTime.Name = "progressBarTime";
            this.progressBarTime.Size = new System.Drawing.Size(426, 23);
            this.progressBarTime.TabIndex = 0;
            // 
            // lblMSG
            // 
            this.lblMSG.Location = new System.Drawing.Point(12, 54);
            this.lblMSG.Name = "lblMSG";
            this.lblMSG.Size = new System.Drawing.Size(426, 16);
            this.lblMSG.TabIndex = 1;
            this.lblMSG.Text = "MSG";
            this.lblMSG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDangKy
            // 
            this.btnDangKy.Location = new System.Drawing.Point(12, 90);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(120, 30);
            this.btnDangKy.TabIndex = 2;
            this.btnDangKy.Text = "Đăng Ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnDungThu
            // 
            this.btnDungThu.Location = new System.Drawing.Point(165, 90);
            this.btnDungThu.Name = "btnDungThu";
            this.btnDungThu.Size = new System.Drawing.Size(120, 30);
            this.btnDungThu.TabIndex = 3;
            this.btnDungThu.Text = "Dùng Thử";
            this.btnDungThu.UseVisualStyleBackColor = true;
            this.btnDungThu.Click += new System.EventHandler(this.btnDungThu_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(318, 90);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(120, 30);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 144);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDungThu);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.lblMSG);
            this.Controls.Add(this.progressBarTime);
            this.MaximizeBox = false;
            this.Name = "frmDangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Ký";
            this.Load += new System.EventHandler(this.frmDangKy_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarTime;
        private System.Windows.Forms.Label lblMSG;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnDungThu;
        private System.Windows.Forms.Button btnThoat;
    }
}