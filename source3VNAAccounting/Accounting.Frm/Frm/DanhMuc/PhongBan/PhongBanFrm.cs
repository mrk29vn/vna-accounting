using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounting.Core.Domain;
using Accounting.Core.IService;
using Accounting.Core.ServiceImp;
using FX.Core;
using FX.Data;

namespace Accounting.Frm.Frm.DanhMuc.PhongBan
{
    public partial class PhongBanFrm : Form
    {
        #region khai báo
        IDepartmentService IDepartmentService;
        List<Department> dsDepartment = new List<Department>();
        #endregion

        #region khởi tạo
        public PhongBanFrm()
        {
            InitializeComponent();
        }

        private void PhongBanFrm_Load(object sender, EventArgs e)
        {
            //Load dữ liệu
            IDepartmentService = IoC.Resolve<IDepartmentService>();
            List<Department> list = IDepartmentService.GetAll();

            ultraGrid1.DataSource = list.ToArray();
            ConfigGrid(ultraGrid1);
        }
        #endregion

        #region Utils
        void ConfigGrid(Infragistics.Win.UltraWinGrid.UltraGrid utralGrid)
        {
            //Tiêu đề
            utralGrid.Text = "Danh sách phòng ban";

            //tiêu đề cột
            //for (int i = 0; i < utralGrid; i++)
            //{
                
            //}
        }
        #endregion
    }
}
