namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtMaHoa = new System.Windows.Forms.TextBox();
            this.txtGiaiMa = new System.Windows.Forms.TextBox();
            this.btnCleartxtMaHoa = new System.Windows.Forms.Button();
            this.btnCleartxtGiaiMa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Mã hóa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 141);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Giải mã";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtMaHoa
            // 
            this.txtMaHoa.Location = new System.Drawing.Point(12, 115);
            this.txtMaHoa.Name = "txtMaHoa";
            this.txtMaHoa.Size = new System.Drawing.Size(440, 20);
            this.txtMaHoa.TabIndex = 3;
            // 
            // txtGiaiMa
            // 
            this.txtGiaiMa.Location = new System.Drawing.Point(12, 171);
            this.txtGiaiMa.Name = "txtGiaiMa";
            this.txtGiaiMa.Size = new System.Drawing.Size(440, 20);
            this.txtGiaiMa.TabIndex = 4;
            // 
            // btnCleartxtMaHoa
            // 
            this.btnCleartxtMaHoa.Location = new System.Drawing.Point(108, 85);
            this.btnCleartxtMaHoa.Name = "btnCleartxtMaHoa";
            this.btnCleartxtMaHoa.Size = new System.Drawing.Size(75, 23);
            this.btnCleartxtMaHoa.TabIndex = 5;
            this.btnCleartxtMaHoa.Text = "Xóa";
            this.btnCleartxtMaHoa.UseVisualStyleBackColor = true;
            this.btnCleartxtMaHoa.Click += new System.EventHandler(this.btnCleartxtMaHoa_Click);
            // 
            // btnCleartxtGiaiMa
            // 
            this.btnCleartxtGiaiMa.Location = new System.Drawing.Point(108, 142);
            this.btnCleartxtGiaiMa.Name = "btnCleartxtGiaiMa";
            this.btnCleartxtGiaiMa.Size = new System.Drawing.Size(75, 23);
            this.btnCleartxtGiaiMa.TabIndex = 6;
            this.btnCleartxtGiaiMa.Text = "Xóa";
            this.btnCleartxtGiaiMa.UseVisualStyleBackColor = true;
            this.btnCleartxtGiaiMa.Click += new System.EventHandler(this.btnCleartxtGiaiMa_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 260);
            this.Controls.Add(this.btnCleartxtGiaiMa);
            this.Controls.Add(this.btnCleartxtMaHoa);
            this.Controls.Add(this.txtGiaiMa);
            this.Controls.Add(this.txtMaHoa);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtMaHoa;
        private System.Windows.Forms.TextBox txtGiaiMa;
        private System.Windows.Forms.Button btnCleartxtMaHoa;
        private System.Windows.Forms.Button btnCleartxtGiaiMa;
    }
}

