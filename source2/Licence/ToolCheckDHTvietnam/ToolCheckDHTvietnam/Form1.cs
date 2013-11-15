using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ToolCheckDHTvietnam.Entity;
using ToolCheckDHTvietnam.Properties;

namespace ToolCheckDHTvietnam
{
    public partial class Form1 : Form
    {
        string _regPatch = "nsVPovFETgTaPeS+iEsXJlMal2WvNwfgz9kDZSAyEh//Fqb3wxMHeNTr8rAkklj3";   //Mặc định là người dùng mới
        readonly bool _notChange;

        public Form1()
        {
            InitializeComponent();
            //Khởi tạo cbb người dùng
            List<ComboboxItemObj> lcbb = new List<ComboboxItemObj>
                                             {
                                                 new ComboboxItemObj { Hienthi = "người dùng mới", Giatri = "nsVPovFETgTaPeS+iEsXJlMal2WvNwfgz9kDZSAyEh//Fqb3wxMHeNTr8rAkklj3" },
                                                 new ComboboxItemObj { Hienthi = "người dùng cũ" , Giatri = "W3nmTi15jP53j3sfv0JMlaY16oUK5Qric10i7Hvxl/rNlQPcX2Xehp1/+nMT2mAZ" }
                                             };
            _notChange = true;
            cbbNguoiDung.DataSource = lcbb.ToArray();
            _notChange = false;
            cbbNguoiDung.DisplayMember = "Hienthi";
            cbbNguoiDung.ValueMember = "Giatri";
            cbbNguoiDung.SelectedIndex = 0;
        }

        private void Button2Click(object sender, EventArgs e)
        {
            txtGiaiMa.Text = Klib2.KEnDe.DS(txtMaHoa.Text);
        }

        private void Button3Click(object sender, EventArgs e)
        {
            txtMaHoa.Text = Klib2.KEnDe.ES(txtGiaiMa.Text);
        }

        private void BtnCleartxtMaHoaClick(object sender, EventArgs e)
        {
            txtMaHoa.Text = string.Empty;
        }

        private void BtnCleartxtGiaiMaClick(object sender, EventArgs e)
        {
            txtGiaiMa.Text = string.Empty;
        }

        private void CbbNguoiDungSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_notChange)
            {
                _regPatch = ((ComboboxItemObj)cbbNguoiDung.SelectedItem).Giatri;
                txtKey.Text = string.Empty;
                txtNgayBatDau.Text = string.Empty;
                txtNgayKetThuc.Text = string.Empty;
                txtSoTruong.Text = string.Empty;
            }
        }

        private void BtnLayThongTinClick(object sender, EventArgs e)
        {
            try
            {
                List<List<string>> lobj = Utils.CheckThongTinNguoiDung(_regPatch);
                txtSoTruong.Text = lobj.Count.ToString();
                if (lobj.Count <= 0) return;
                bool mahoa = _regPatch.Equals("nsVPovFETgTaPeS+iEsXJlMal2WvNwfgz9kDZSAyEh//Fqb3wxMHeNTr8rAkklj3");
                string key1 = mahoa ? "sk29vnbd2988" : "bd";
                string key2 = mahoa ? "ek29vnkt2988" : "kt";
                string key3 = mahoa ? "kk29vnkk2988" : "k";
                if (lobj[0].Contains(key1) || lobj[0].Contains(key2) || lobj[0].Contains(key3)) //Kiểm tra REG
                {
                    DateTime batdau = DateTime.Parse(mahoa ? Klib2.KEnDe.ES(Utils.Get(key1, lobj)) : Utils.Get(key1, lobj));
                    DateTime ketthuc = DateTime.Parse(mahoa ? Klib2.KEnDe.ES(Utils.Get(key2, lobj)) : Utils.Get(key2, lobj));
                    string getKey3Tem = mahoa ? Klib2.KEnDe.ES(Utils.Get(key3, lobj)) : Utils.Get(key3, lobj);
                    txtKey.Text = getKey3Tem;
                    txtNgayBatDau.Text = batdau.ToString("dd/MM/yyyy");
                    txtNgayKetThuc.Text = ketthuc.ToString("dd/MM/yyyy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void BtnDefaultValueClick(object sender, EventArgs e)
        {
            txtKeywordConfigXML.Text = Resources.Form1_button7_Click_SupermarketManagement;
            txtKeywordServerConfig.Text = Resources.Form1_button7_Click_ConnectionServer;
        }

        private void BtnMaHoaXmlDecodeClick(object sender, EventArgs e)
        {
            string key = rdoConfigXML.Checked ? txtKeywordConfigXML.Text : txtKeywordServerConfig.Text;
            txtGiaiMa_XMLDecode.Text = Utils.MaHoa(key, txtMaHoa_XMLDecode.Text);
        }

        private void BtnGiaiMaXmlDecodeClick(object sender, EventArgs e)
        {
            string key = rdoConfigXML.Checked ? txtKeywordConfigXML.Text : txtKeywordServerConfig.Text;
            txtMaHoa_XMLDecode.Text = Utils.GiaiMa(key, txtGiaiMa_XMLDecode.Text);
        }

        private void BtnXoaMhXmlDecodeClick(object sender, EventArgs e)
        {
            txtMaHoa_XMLDecode.Text = string.Empty;
        }

        private void BtnXoaGmXmlDecodeClick(object sender, EventArgs e)
        {
            txtGiaiMa_XMLDecode.Text = string.Empty;
        }

    }
}
