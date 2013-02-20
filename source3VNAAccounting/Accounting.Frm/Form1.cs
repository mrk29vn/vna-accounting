using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;

using Accounting.Core.Domain;
using Accounting.Core.IService;
using Accounting.Core.ServiceImp;

using FX.Core;
using FX.Data;




namespace Accounting.Frm
{
    public partial class Form1 : Form
    {
        IOptionTVANService _IOptionTVANService;
        //private readonly IHocSinhService _IHocSinhService;

        public Form1()
        {
            _IOptionTVANService = IoC.Resolve<IOptionTVANService>();
            //_IHocSinhService = IoC.Resolve<IHocSinhService>();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //List<HocSinh> list = _IHocSinhService.GetAll();
            //MessageBox.Show(_IOptionTVANService.GetAll().Count.ToString());
        }
    }
}
