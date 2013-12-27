namespace k29vnAU
{
    partial class K29VnAuTool
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(K29VnAuTool));
            this.ProcessBar = new System.Windows.Forms.ProgressBar();
            this.lbProcessBar = new System.Windows.Forms.Label();
            this.lbMSG = new System.Windows.Forms.Label();
            this.lbMSGValue = new System.Windows.Forms.Label();
            this.pic = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.p1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.timerStop = new System.Windows.Forms.Timer(this.components);
            this.timerStopZIP = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.p1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ProcessBar
            // 
            this.ProcessBar.Location = new System.Drawing.Point(3, 103);
            this.ProcessBar.Name = "ProcessBar";
            this.ProcessBar.Size = new System.Drawing.Size(396, 23);
            this.ProcessBar.TabIndex = 7;
            // 
            // lbProcessBar
            // 
            this.lbProcessBar.AutoSize = true;
            this.lbProcessBar.Location = new System.Drawing.Point(142, 63);
            this.lbProcessBar.Name = "lbProcessBar";
            this.lbProcessBar.Size = new System.Drawing.Size(24, 13);
            this.lbProcessBar.TabIndex = 8;
            this.lbProcessBar.Text = "0/0";
            // 
            // lbMSG
            // 
            this.lbMSG.AutoSize = true;
            this.lbMSG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMSG.ForeColor = System.Drawing.Color.Black;
            this.lbMSG.Location = new System.Drawing.Point(134, 26);
            this.lbMSG.Name = "lbMSG";
            this.lbMSG.Size = new System.Drawing.Size(80, 15);
            this.lbMSG.TabIndex = 9;
            this.lbMSG.Text = "Trạng Thái:";
            // 
            // lbMSGValue
            // 
            this.lbMSGValue.AutoSize = true;
            this.lbMSGValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMSGValue.ForeColor = System.Drawing.Color.Black;
            this.lbMSGValue.Location = new System.Drawing.Point(220, 26);
            this.lbMSGValue.Name = "lbMSGValue";
            this.lbMSGValue.Size = new System.Drawing.Size(118, 15);
            this.lbMSGValue.TabIndex = 10;
            this.lbMSGValue.Text = ".....................................";
            // 
            // pic
            // 
            this.pic.Image = ((System.Drawing.Image)(resources.GetObject("pic.Image")));
            this.pic.Location = new System.Drawing.Point(7, 8);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(105, 89);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 11;
            this.pic.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // p1
            // 
            this.p1.Controls.Add(this.pictureBox1);
            this.p1.Controls.Add(this.lbl1);
            this.p1.Location = new System.Drawing.Point(381, 12);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(402, 134);
            this.p1.TabIndex = 12;
            this.p1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(78, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(55, 25);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(253, 38);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Đang thực hiện cài đặt phiên bản mới\r\nXin vui lòng chờ trong giây lát....";
            // 
            // timerStop
            // 
            this.timerStop.Interval = 5000;
            this.timerStop.Tick += new System.EventHandler(this.TimerStopTick);
            // 
            // timerStopZIP
            // 
            this.timerStopZIP.Interval = 1000;
            this.timerStopZIP.Tick += new System.EventHandler(this.TimerStopZipTick);
            // 
            // AutoUpdateTvanTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 134);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.lbMSGValue);
            this.Controls.Add(this.lbMSG);
            this.Controls.Add(this.ProcessBar);
            this.Controls.Add(this.lbProcessBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutoUpdateTvanTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "k29vnAU Tools";
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.p1.ResumeLayout(false);
            this.p1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProcessBar;
        private System.Windows.Forms.Label lbProcessBar;
        private System.Windows.Forms.Label lbMSG;
        private System.Windows.Forms.Label lbMSGValue;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Timer timerStop;
        private System.Windows.Forms.Timer timerStopZIP;
    }
}

