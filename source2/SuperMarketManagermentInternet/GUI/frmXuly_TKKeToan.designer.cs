
namespace GUI
{
    partial class frmXuly_TKKeToan
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
            this.cbbNhomTK = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.txtmatkkt = new System.Windows.Forms.TextBox();
            this.txttentkkt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tsslSua = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslDong = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.tsslThem = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbNhomTK
            // 
            this.cbbNhomTK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNhomTK.FormattingEnabled = true;
            this.cbbNhomTK.Location = new System.Drawing.Point(133, 104);
            this.cbbNhomTK.Name = "cbbNhomTK";
            this.cbbNhomTK.Size = new System.Drawing.Size(253, 22);
            this.cbbNhomTK.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 14);
            this.label4.TabIndex = 51;
            this.label4.Text = "Nhóm Tài Khoản:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 136);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 14);
            this.label13.TabIndex = 50;
            this.label13.Text = "Ghi chú:";
            // 
            // txtghichu
            // 
            this.txtghichu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtghichu.Location = new System.Drawing.Point(133, 134);
            this.txtghichu.MaxLength = 100;
            this.txtghichu.Multiline = true;
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(253, 63);
            this.txtghichu.TabIndex = 5;
            // 
            // txtmatkkt
            // 
            this.txtmatkkt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtmatkkt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmatkkt.Location = new System.Drawing.Point(133, 38);
            this.txtmatkkt.MaxLength = 5;
            this.txtmatkkt.Name = "txtmatkkt";
            this.txtmatkkt.ReadOnly = true;
            this.txtmatkkt.Size = new System.Drawing.Size(253, 20);
            this.txtmatkkt.TabIndex = 2;
            this.txtmatkkt.TextChanged += new System.EventHandler(this.txtmatkkt_TextChanged);
            // 
            // txttentkkt
            // 
            this.txttentkkt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttentkkt.Location = new System.Drawing.Point(133, 70);
            this.txttentkkt.MaxLength = 200;
            this.txttentkkt.Name = "txttentkkt";
            this.txttentkkt.Size = new System.Drawing.Size(253, 20);
            this.txttentkkt.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 14);
            this.label3.TabIndex = 26;
            this.label3.Text = "Mã tài khoản kế toán:";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Location = new System.Drawing.Point(133, 12);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(253, 20);
            this.txtID.TabIndex = 1;
            this.txtID.Text = "1";
            this.txtID.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 14);
            this.label2.TabIndex = 26;
            this.label2.Text = "Tên tài khoản kế toán:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 14);
            this.label1.TabIndex = 25;
            this.label1.Text = "TKKT ID:";
            this.label1.Visible = false;
            // 
            // tsslSua
            // 
            this.tsslSua.Image = global::GUI.Properties.Resources.Sua;
            this.tsslSua.Name = "tsslSua";
            this.tsslSua.Size = new System.Drawing.Size(128, 21);
            this.tsslSua.Spring = true;
            this.tsslSua.Text = "Sửa ";
            this.tsslSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslSua.Click += new System.EventHandler(this.tsslSua_Click);
            this.tsslSua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslSua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(0, 21);
            // 
            // tsslDong
            // 
            this.tsslDong.Image = global::GUI.Properties.Resources.Tro_ve;
            this.tsslDong.Name = "tsslDong";
            this.tsslDong.Size = new System.Drawing.Size(128, 21);
            this.tsslDong.Spring = true;
            this.tsslDong.Text = "Trở Về";
            this.tsslDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslDong.Click += new System.EventHandler(this.tsslDong_Click);
            this.tsslDong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslDong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip2.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslThem,
            this.tsslSua,
            this.toolStripStatusLabel6,
            this.tsslDong});
            this.statusStrip2.Location = new System.Drawing.Point(0, 239);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(430, 26);
            this.statusStrip2.TabIndex = 33;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // tsslThem
            // 
            this.tsslThem.Image = global::GUI.Properties.Resources.Them;
            this.tsslThem.Name = "tsslThem";
            this.tsslThem.Size = new System.Drawing.Size(128, 21);
            this.tsslThem.Spring = true;
            this.tsslThem.Text = "Thêm";
            this.tsslThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslThem.Click += new System.EventHandler(this.tsslThem_Click);
            this.tsslThem.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslThem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // frmXuly_TKKeToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(430, 265);
            this.ControlBox = false;
            this.Controls.Add(this.cbbNhomTK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtghichu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtmatkkt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txttentkkt);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmXuly_TKKeToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xử Lý Tài Khoản Kế Toán";
            this.Load += new System.EventHandler(this.frmXuly_TKKeToan_Load);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbNhomTK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.TextBox txtmatkkt;
        private System.Windows.Forms.TextBox txttentkkt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel tsslSua;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel tsslDong;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel tsslThem;
    }
}