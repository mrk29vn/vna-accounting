namespace GUI
{
    partial class FrmXuLyBanLeCalculator
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
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCKTM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhanTram = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTongTien
            // 
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Location = new System.Drawing.Point(139, 10);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(284, 20);
            this.txtTongTien.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tổng tiền";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chiết khấu tiền mặt";
            // 
            // txtCKTM
            // 
            this.txtCKTM.Location = new System.Drawing.Point(139, 41);
            this.txtCKTM.Name = "txtCKTM";
            this.txtCKTM.Size = new System.Drawing.Size(284, 20);
            this.txtCKTM.TabIndex = 2;
            this.txtCKTM.TextChanged += new System.EventHandler(this.TxtCktmTextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Chiết khấu % tương ứng";
            // 
            // txtPhanTram
            // 
            this.txtPhanTram.Enabled = false;
            this.txtPhanTram.Location = new System.Drawing.Point(139, 78);
            this.txtPhanTram.Name = "txtPhanTram";
            this.txtPhanTram.Size = new System.Drawing.Size(284, 20);
            this.txtPhanTram.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(345, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Đồng ý";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmXuLyBanLeCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 145);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPhanTram);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCKTM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTongTien);
            this.Name = "FrmXuLyBanLeCalculator";
            this.Text = "frmXuLyBanLeCalculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCKTM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhanTram;
        private System.Windows.Forms.Button button1;
    }
}