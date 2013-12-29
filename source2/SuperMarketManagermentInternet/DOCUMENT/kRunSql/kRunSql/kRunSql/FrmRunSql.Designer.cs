namespace kRunSql
{
    partial class FrmRunSql
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabConnect = new System.Windows.Forms.TabPage();
            this.chkShowPass = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSaveDhtConfig = new System.Windows.Forms.Button();
            this.btnLoadDhtConfig = new System.Windows.Forms.Button();
            this.txtCsdlName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTestConnect = new System.Windows.Forms.Button();
            this.rdoWinAu = new System.Windows.Forms.RadioButton();
            this.rdoSqlAu = new System.Windows.Forms.RadioButton();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.btnLoadScript = new System.Windows.Forms.Button();
            this.btnRunScript = new System.Windows.Forms.Button();
            this.txtSql = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabConnect.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabConnect);
            this.tabControl1.Controls.Add(this.tabDetails);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(651, 302);
            this.tabControl1.TabIndex = 0;
            // 
            // tabConnect
            // 
            this.tabConnect.Controls.Add(this.chkShowPass);
            this.tabConnect.Controls.Add(this.groupBox1);
            this.tabConnect.Controls.Add(this.txtCsdlName);
            this.tabConnect.Controls.Add(this.label4);
            this.tabConnect.Controls.Add(this.btnTestConnect);
            this.tabConnect.Controls.Add(this.rdoWinAu);
            this.tabConnect.Controls.Add(this.rdoSqlAu);
            this.tabConnect.Controls.Add(this.txtPass);
            this.tabConnect.Controls.Add(this.label3);
            this.tabConnect.Controls.Add(this.txtUser);
            this.tabConnect.Controls.Add(this.label2);
            this.tabConnect.Controls.Add(this.txtServerName);
            this.tabConnect.Controls.Add(this.label1);
            this.tabConnect.Location = new System.Drawing.Point(4, 22);
            this.tabConnect.Name = "tabConnect";
            this.tabConnect.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnect.Size = new System.Drawing.Size(643, 276);
            this.tabConnect.TabIndex = 0;
            this.tabConnect.Text = "Khai báo";
            this.tabConnect.UseVisualStyleBackColor = true;
            // 
            // chkShowPass
            // 
            this.chkShowPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowPass.AutoSize = true;
            this.chkShowPass.Location = new System.Drawing.Point(293, 93);
            this.chkShowPass.Name = "chkShowPass";
            this.chkShowPass.Size = new System.Drawing.Size(95, 17);
            this.chkShowPass.TabIndex = 12;
            this.chkShowPass.Text = "Hiện mật khẩu";
            this.chkShowPass.UseVisualStyleBackColor = true;
            this.chkShowPass.CheckedChanged += new System.EventHandler(this.chkShowPass_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnSaveDhtConfig);
            this.groupBox1.Controls.Add(this.btnLoadDhtConfig);
            this.groupBox1.Location = new System.Drawing.Point(398, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 153);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hỗ trợ";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(19, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "k29vn\'s Utils Tool - k29vnn@gmail.com";
            // 
            // btnSaveDhtConfig
            // 
            this.btnSaveDhtConfig.Location = new System.Drawing.Point(6, 50);
            this.btnSaveDhtConfig.Name = "btnSaveDhtConfig";
            this.btnSaveDhtConfig.Size = new System.Drawing.Size(224, 23);
            this.btnSaveDhtConfig.TabIndex = 1;
            this.btnSaveDhtConfig.Text = "Save DHT Config (Config.xml)";
            this.btnSaveDhtConfig.UseVisualStyleBackColor = true;
            this.btnSaveDhtConfig.Click += new System.EventHandler(this.btnSaveDhtConfig_Click);
            // 
            // btnLoadDhtConfig
            // 
            this.btnLoadDhtConfig.Location = new System.Drawing.Point(7, 20);
            this.btnLoadDhtConfig.Name = "btnLoadDhtConfig";
            this.btnLoadDhtConfig.Size = new System.Drawing.Size(224, 23);
            this.btnLoadDhtConfig.TabIndex = 0;
            this.btnLoadDhtConfig.Text = "Load DHT Config (Config.xml)";
            this.btnLoadDhtConfig.UseVisualStyleBackColor = true;
            this.btnLoadDhtConfig.Click += new System.EventHandler(this.btnLoadDhtConfig_Click);
            // 
            // txtCsdlName
            // 
            this.txtCsdlName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCsdlName.Location = new System.Drawing.Point(100, 118);
            this.txtCsdlName.Name = "txtCsdlName";
            this.txtCsdlName.Size = new System.Drawing.Size(281, 20);
            this.txtCsdlName.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tên CSDL:";
            // 
            // btnTestConnect
            // 
            this.btnTestConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestConnect.Location = new System.Drawing.Point(266, 144);
            this.btnTestConnect.Name = "btnTestConnect";
            this.btnTestConnect.Size = new System.Drawing.Size(115, 23);
            this.btnTestConnect.TabIndex = 8;
            this.btnTestConnect.Text = "Kiểm tra kết nối";
            this.btnTestConnect.UseVisualStyleBackColor = true;
            this.btnTestConnect.Click += new System.EventHandler(this.btnTestConnect_Click);
            // 
            // rdoWinAu
            // 
            this.rdoWinAu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoWinAu.AutoSize = true;
            this.rdoWinAu.Enabled = false;
            this.rdoWinAu.Location = new System.Drawing.Point(195, 40);
            this.rdoWinAu.Name = "rdoWinAu";
            this.rdoWinAu.Size = new System.Drawing.Size(186, 17);
            this.rdoWinAu.TabIndex = 7;
            this.rdoWinAu.Text = "Xác thực bằng tài khoản windows";
            this.rdoWinAu.UseVisualStyleBackColor = true;
            // 
            // rdoSqlAu
            // 
            this.rdoSqlAu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoSqlAu.AutoSize = true;
            this.rdoSqlAu.Checked = true;
            this.rdoSqlAu.Location = new System.Drawing.Point(13, 40);
            this.rdoSqlAu.Name = "rdoSqlAu";
            this.rdoSqlAu.Size = new System.Drawing.Size(166, 17);
            this.rdoSqlAu.TabIndex = 6;
            this.rdoSqlAu.TabStop = true;
            this.rdoSqlAu.Text = "Xác thực bằng tài khoản SQL";
            this.rdoSqlAu.UseVisualStyleBackColor = true;
            // 
            // txtPass
            // 
            this.txtPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPass.Location = new System.Drawing.Point(100, 90);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(186, 20);
            this.txtPass.TabIndex = 5;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mật khẩu:";
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.Location = new System.Drawing.Point(100, 64);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(281, 20);
            this.txtUser.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên đăng nhập:";
            // 
            // txtServerName
            // 
            this.txtServerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerName.Location = new System.Drawing.Point(99, 14);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(281, 20);
            this.txtServerName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên máy chủ:";
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.btnLoadScript);
            this.tabDetails.Controls.Add(this.btnRunScript);
            this.tabDetails.Controls.Add(this.txtSql);
            this.tabDetails.Location = new System.Drawing.Point(4, 22);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size = new System.Drawing.Size(643, 276);
            this.tabDetails.TabIndex = 1;
            this.tabDetails.Text = "Chạy Script SQL";
            this.tabDetails.UseVisualStyleBackColor = true;
            // 
            // btnLoadScript
            // 
            this.btnLoadScript.Location = new System.Drawing.Point(9, 10);
            this.btnLoadScript.Name = "btnLoadScript";
            this.btnLoadScript.Size = new System.Drawing.Size(104, 23);
            this.btnLoadScript.TabIndex = 2;
            this.btnLoadScript.Text = "Tìm tệp dữ liệu";
            this.btnLoadScript.UseVisualStyleBackColor = true;
            this.btnLoadScript.Click += new System.EventHandler(this.btnLoadScript_Click);
            // 
            // btnRunScript
            // 
            this.btnRunScript.Location = new System.Drawing.Point(119, 10);
            this.btnRunScript.Name = "btnRunScript";
            this.btnRunScript.Size = new System.Drawing.Size(104, 23);
            this.btnRunScript.TabIndex = 1;
            this.btnRunScript.Text = "Chạy đoạn mã";
            this.btnRunScript.UseVisualStyleBackColor = true;
            this.btnRunScript.Click += new System.EventHandler(this.btnRunScript_Click);
            // 
            // txtSql
            // 
            this.txtSql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSql.Location = new System.Drawing.Point(9, 39);
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSql.Size = new System.Drawing.Size(626, 229);
            this.txtSql.TabIndex = 0;
            // 
            // FrmRunSql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 302);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmRunSql";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hỗ trợ chạy script cho SQL Server";
            this.tabControl1.ResumeLayout(false);
            this.tabConnect.ResumeLayout(false);
            this.tabConnect.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabDetails.ResumeLayout(false);
            this.tabDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabConnect;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoWinAu;
        private System.Windows.Forms.RadioButton rdoSqlAu;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTestConnect;
        private System.Windows.Forms.TextBox txtCsdlName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLoadDhtConfig;
        private System.Windows.Forms.CheckBox chkShowPass;
        private System.Windows.Forms.Button btnSaveDhtConfig;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLoadScript;
        private System.Windows.Forms.Button btnRunScript;
        private System.Windows.Forms.TextBox txtSql;
    }
}

