namespace ToolCheckDHTvietnam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCleartxtGiaiMa = new System.Windows.Forms.Button();
            this.btnCleartxtMaHoa = new System.Windows.Forms.Button();
            this.txtGiaiMa = new System.Windows.Forms.TextBox();
            this.txtMaHoa = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoTruong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNgayBatDau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNgayKetThuc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLayThongTin = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbNguoiDung = new System.Windows.Forms.ComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.rdoServerConfig = new System.Windows.Forms.RadioButton();
            this.rdoConfigXML = new System.Windows.Forms.RadioButton();
            this.btnDefaultValue = new System.Windows.Forms.Button();
            this.lblKeywordServerConfig = new System.Windows.Forms.Label();
            this.lblKeywordConfigXML = new System.Windows.Forms.Label();
            this.txtKeywordServerConfig = new System.Windows.Forms.TextBox();
            this.txtKeywordConfigXML = new System.Windows.Forms.TextBox();
            this.btnXoaGM_XMLDecode = new System.Windows.Forms.Button();
            this.btnXoaMH_XMLDecode = new System.Windows.Forms.Button();
            this.txtGiaiMa_XMLDecode = new System.Windows.Forms.TextBox();
            this.txtMaHoa_XMLDecode = new System.Windows.Forms.TextBox();
            this.btnGiaiMa_XMLDecode = new System.Windows.Forms.Button();
            this.btnMaHoa_XMLDecode = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(439, 383);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage1.BackgroundImage")));
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(431, 357);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thông tin chung";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCleartxtGiaiMa);
            this.tabPage2.Controls.Add(this.btnCleartxtMaHoa);
            this.tabPage2.Controls.Add(this.txtGiaiMa);
            this.tabPage2.Controls.Add(this.txtMaHoa);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(431, 357);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mã hóa, giải mã";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCleartxtGiaiMa
            // 
            this.btnCleartxtGiaiMa.Location = new System.Drawing.Point(112, 78);
            this.btnCleartxtGiaiMa.Name = "btnCleartxtGiaiMa";
            this.btnCleartxtGiaiMa.Size = new System.Drawing.Size(75, 23);
            this.btnCleartxtGiaiMa.TabIndex = 12;
            this.btnCleartxtGiaiMa.Text = "Xóa";
            this.btnCleartxtGiaiMa.UseVisualStyleBackColor = true;
            this.btnCleartxtGiaiMa.Click += new System.EventHandler(this.BtnCleartxtGiaiMaClick);
            // 
            // btnCleartxtMaHoa
            // 
            this.btnCleartxtMaHoa.Location = new System.Drawing.Point(112, 21);
            this.btnCleartxtMaHoa.Name = "btnCleartxtMaHoa";
            this.btnCleartxtMaHoa.Size = new System.Drawing.Size(75, 23);
            this.btnCleartxtMaHoa.TabIndex = 11;
            this.btnCleartxtMaHoa.Text = "Xóa";
            this.btnCleartxtMaHoa.UseVisualStyleBackColor = true;
            this.btnCleartxtMaHoa.Click += new System.EventHandler(this.BtnCleartxtMaHoaClick);
            // 
            // txtGiaiMa
            // 
            this.txtGiaiMa.Location = new System.Drawing.Point(16, 107);
            this.txtGiaiMa.Name = "txtGiaiMa";
            this.txtGiaiMa.Size = new System.Drawing.Size(407, 20);
            this.txtGiaiMa.TabIndex = 10;
            // 
            // txtMaHoa
            // 
            this.txtMaHoa.Location = new System.Drawing.Point(16, 51);
            this.txtMaHoa.Name = "txtMaHoa";
            this.txtMaHoa.Size = new System.Drawing.Size(407, 20);
            this.txtMaHoa.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Giải mã";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Mã hóa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.txtSoTruong);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.txtNgayBatDau);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.txtNgayKetThuc);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.btnLayThongTin);
            this.tabPage3.Controls.Add(this.txtKey);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.cbbNguoiDung);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(431, 357);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Kiểm tra thông tin bản quyền";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(233, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Số trường";
            // 
            // txtSoTruong
            // 
            this.txtSoTruong.Enabled = false;
            this.txtSoTruong.Location = new System.Drawing.Point(292, 53);
            this.txtSoTruong.Name = "txtSoTruong";
            this.txtSoTruong.Size = new System.Drawing.Size(116, 20);
            this.txtSoTruong.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ngày bắt đầu";
            // 
            // txtNgayBatDau
            // 
            this.txtNgayBatDau.Enabled = false;
            this.txtNgayBatDau.Location = new System.Drawing.Point(86, 123);
            this.txtNgayBatDau.Name = "txtNgayBatDau";
            this.txtNgayBatDau.Size = new System.Drawing.Size(333, 20);
            this.txtNgayBatDau.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ngày kết thúc";
            // 
            // txtNgayKetThuc
            // 
            this.txtNgayKetThuc.Enabled = false;
            this.txtNgayKetThuc.Location = new System.Drawing.Point(86, 156);
            this.txtNgayKetThuc.Name = "txtNgayKetThuc";
            this.txtNgayKetThuc.Size = new System.Drawing.Size(333, 20);
            this.txtNgayKetThuc.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Key";
            // 
            // btnLayThongTin
            // 
            this.btnLayThongTin.Location = new System.Drawing.Point(11, 53);
            this.btnLayThongTin.Name = "btnLayThongTin";
            this.btnLayThongTin.Size = new System.Drawing.Size(125, 23);
            this.btnLayThongTin.TabIndex = 6;
            this.btnLayThongTin.Text = "Lấy thông tin";
            this.btnLayThongTin.UseVisualStyleBackColor = true;
            this.btnLayThongTin.Click += new System.EventHandler(this.BtnLayThongTinClick);
            // 
            // txtKey
            // 
            this.txtKey.Enabled = false;
            this.txtKey.Location = new System.Drawing.Point(39, 88);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(380, 20);
            this.txtKey.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "1. Chọn người dùng";
            // 
            // cbbNguoiDung
            // 
            this.cbbNguoiDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNguoiDung.FormattingEnabled = true;
            this.cbbNguoiDung.Location = new System.Drawing.Point(114, 16);
            this.cbbNguoiDung.Name = "cbbNguoiDung";
            this.cbbNguoiDung.Size = new System.Drawing.Size(294, 21);
            this.cbbNguoiDung.TabIndex = 3;
            this.cbbNguoiDung.SelectedIndexChanged += new System.EventHandler(this.CbbNguoiDungSelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.rdoServerConfig);
            this.tabPage4.Controls.Add(this.rdoConfigXML);
            this.tabPage4.Controls.Add(this.btnDefaultValue);
            this.tabPage4.Controls.Add(this.lblKeywordServerConfig);
            this.tabPage4.Controls.Add(this.lblKeywordConfigXML);
            this.tabPage4.Controls.Add(this.txtKeywordServerConfig);
            this.tabPage4.Controls.Add(this.txtKeywordConfigXML);
            this.tabPage4.Controls.Add(this.btnXoaGM_XMLDecode);
            this.tabPage4.Controls.Add(this.btnXoaMH_XMLDecode);
            this.tabPage4.Controls.Add(this.txtGiaiMa_XMLDecode);
            this.tabPage4.Controls.Add(this.txtMaHoa_XMLDecode);
            this.tabPage4.Controls.Add(this.btnGiaiMa_XMLDecode);
            this.tabPage4.Controls.Add(this.btnMaHoa_XMLDecode);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(431, 357);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "XML Decode";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // rdoServerConfig
            // 
            this.rdoServerConfig.AutoSize = true;
            this.rdoServerConfig.Location = new System.Drawing.Point(344, 283);
            this.rdoServerConfig.Name = "rdoServerConfig";
            this.rdoServerConfig.Size = new System.Drawing.Size(50, 17);
            this.rdoServerConfig.TabIndex = 25;
            this.rdoServerConfig.Text = "Chọn";
            this.rdoServerConfig.UseVisualStyleBackColor = true;
            // 
            // rdoConfigXML
            // 
            this.rdoConfigXML.AutoSize = true;
            this.rdoConfigXML.Checked = true;
            this.rdoConfigXML.Location = new System.Drawing.Point(60, 283);
            this.rdoConfigXML.Name = "rdoConfigXML";
            this.rdoConfigXML.Size = new System.Drawing.Size(50, 17);
            this.rdoConfigXML.TabIndex = 24;
            this.rdoConfigXML.TabStop = true;
            this.rdoConfigXML.Text = "Chọn";
            this.rdoConfigXML.UseVisualStyleBackColor = true;
            // 
            // btnDefaultValue
            // 
            this.btnDefaultValue.Location = new System.Drawing.Point(180, 318);
            this.btnDefaultValue.Name = "btnDefaultValue";
            this.btnDefaultValue.Size = new System.Drawing.Size(108, 23);
            this.btnDefaultValue.TabIndex = 23;
            this.btnDefaultValue.Text = "<- Default Value ->";
            this.btnDefaultValue.UseVisualStyleBackColor = true;
            this.btnDefaultValue.Click += new System.EventHandler(this.BtnDefaultValueClick);
            // 
            // lblKeywordServerConfig
            // 
            this.lblKeywordServerConfig.AutoSize = true;
            this.lblKeywordServerConfig.Location = new System.Drawing.Point(309, 303);
            this.lblKeywordServerConfig.Name = "lblKeywordServerConfig";
            this.lblKeywordServerConfig.Size = new System.Drawing.Size(109, 13);
            this.lblKeywordServerConfig.TabIndex = 22;
            this.lblKeywordServerConfig.Text = "KeywordServerConfig";
            // 
            // lblKeywordConfigXML
            // 
            this.lblKeywordConfigXML.AutoSize = true;
            this.lblKeywordConfigXML.Location = new System.Drawing.Point(29, 303);
            this.lblKeywordConfigXML.Name = "lblKeywordConfigXML";
            this.lblKeywordConfigXML.Size = new System.Drawing.Size(100, 13);
            this.lblKeywordConfigXML.TabIndex = 21;
            this.lblKeywordConfigXML.Text = "KeywordConfigXML";
            // 
            // txtKeywordServerConfig
            // 
            this.txtKeywordServerConfig.Location = new System.Drawing.Point(316, 320);
            this.txtKeywordServerConfig.Name = "txtKeywordServerConfig";
            this.txtKeywordServerConfig.Size = new System.Drawing.Size(100, 20);
            this.txtKeywordServerConfig.TabIndex = 20;
            this.txtKeywordServerConfig.Text = "ConnectionServer";
            // 
            // txtKeywordConfigXML
            // 
            this.txtKeywordConfigXML.Location = new System.Drawing.Point(12, 320);
            this.txtKeywordConfigXML.Name = "txtKeywordConfigXML";
            this.txtKeywordConfigXML.Size = new System.Drawing.Size(143, 20);
            this.txtKeywordConfigXML.TabIndex = 19;
            this.txtKeywordConfigXML.Text = "SupermarketManagement";
            // 
            // btnXoaGM_XMLDecode
            // 
            this.btnXoaGM_XMLDecode.Location = new System.Drawing.Point(107, 76);
            this.btnXoaGM_XMLDecode.Name = "btnXoaGM_XMLDecode";
            this.btnXoaGM_XMLDecode.Size = new System.Drawing.Size(75, 23);
            this.btnXoaGM_XMLDecode.TabIndex = 18;
            this.btnXoaGM_XMLDecode.Text = "Xóa";
            this.btnXoaGM_XMLDecode.UseVisualStyleBackColor = true;
            this.btnXoaGM_XMLDecode.Click += new System.EventHandler(this.BtnXoaGmXmlDecodeClick);
            // 
            // btnXoaMH_XMLDecode
            // 
            this.btnXoaMH_XMLDecode.Location = new System.Drawing.Point(107, 19);
            this.btnXoaMH_XMLDecode.Name = "btnXoaMH_XMLDecode";
            this.btnXoaMH_XMLDecode.Size = new System.Drawing.Size(75, 23);
            this.btnXoaMH_XMLDecode.TabIndex = 17;
            this.btnXoaMH_XMLDecode.Text = "Xóa";
            this.btnXoaMH_XMLDecode.UseVisualStyleBackColor = true;
            this.btnXoaMH_XMLDecode.Click += new System.EventHandler(this.BtnXoaMhXmlDecodeClick);
            // 
            // txtGiaiMa_XMLDecode
            // 
            this.txtGiaiMa_XMLDecode.Location = new System.Drawing.Point(11, 105);
            this.txtGiaiMa_XMLDecode.Name = "txtGiaiMa_XMLDecode";
            this.txtGiaiMa_XMLDecode.Size = new System.Drawing.Size(407, 20);
            this.txtGiaiMa_XMLDecode.TabIndex = 16;
            // 
            // txtMaHoa_XMLDecode
            // 
            this.txtMaHoa_XMLDecode.Location = new System.Drawing.Point(11, 49);
            this.txtMaHoa_XMLDecode.Name = "txtMaHoa_XMLDecode";
            this.txtMaHoa_XMLDecode.Size = new System.Drawing.Size(407, 20);
            this.txtMaHoa_XMLDecode.TabIndex = 15;
            // 
            // btnGiaiMa_XMLDecode
            // 
            this.btnGiaiMa_XMLDecode.Location = new System.Drawing.Point(11, 75);
            this.btnGiaiMa_XMLDecode.Name = "btnGiaiMa_XMLDecode";
            this.btnGiaiMa_XMLDecode.Size = new System.Drawing.Size(75, 23);
            this.btnGiaiMa_XMLDecode.TabIndex = 14;
            this.btnGiaiMa_XMLDecode.Text = "Giải mã";
            this.btnGiaiMa_XMLDecode.UseVisualStyleBackColor = true;
            this.btnGiaiMa_XMLDecode.Click += new System.EventHandler(this.BtnGiaiMaXmlDecodeClick);
            // 
            // btnMaHoa_XMLDecode
            // 
            this.btnMaHoa_XMLDecode.Location = new System.Drawing.Point(12, 19);
            this.btnMaHoa_XMLDecode.Name = "btnMaHoa_XMLDecode";
            this.btnMaHoa_XMLDecode.Size = new System.Drawing.Size(75, 23);
            this.btnMaHoa_XMLDecode.TabIndex = 13;
            this.btnMaHoa_XMLDecode.Text = "Mã hóa";
            this.btnMaHoa_XMLDecode.UseVisualStyleBackColor = true;
            this.btnMaHoa_XMLDecode.Click += new System.EventHandler(this.BtnMaHoaXmlDecodeClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 383);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DHT Utils Tools";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnCleartxtGiaiMa;
        private System.Windows.Forms.Button btnCleartxtMaHoa;
        private System.Windows.Forms.TextBox txtGiaiMa;
        private System.Windows.Forms.TextBox txtMaHoa;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbbNguoiDung;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLayThongTin;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNgayBatDau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNgayKetThuc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoTruong;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnXoaGM_XMLDecode;
        private System.Windows.Forms.Button btnXoaMH_XMLDecode;
        private System.Windows.Forms.TextBox txtGiaiMa_XMLDecode;
        private System.Windows.Forms.TextBox txtMaHoa_XMLDecode;
        private System.Windows.Forms.Button btnGiaiMa_XMLDecode;
        private System.Windows.Forms.Button btnMaHoa_XMLDecode;
        private System.Windows.Forms.Button btnDefaultValue;
        private System.Windows.Forms.Label lblKeywordServerConfig;
        private System.Windows.Forms.Label lblKeywordConfigXML;
        private System.Windows.Forms.TextBox txtKeywordServerConfig;
        private System.Windows.Forms.TextBox txtKeywordConfigXML;
        private System.Windows.Forms.RadioButton rdoServerConfig;
        private System.Windows.Forms.RadioButton rdoConfigXML;
    }
}

