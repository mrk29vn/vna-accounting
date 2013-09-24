using System;
using System.Data;
using System.Windows.Forms;

namespace ReportBank
{
    public partial class ViewReport : Form
    {
        public ViewReport()
        {
            InitializeComponent();
            FillData();
            reportViewer1.Source = inlineReportSlot1;
            inlineReportSlot1.Prepare();
        }

        void FillData()
        {
            DataRow row = dataTable1.NewRow();
            row["Company"] = "Cty Sông Hồng";
            row["Address"] = "Hà Nội";
            row["Contact"] = "Ông Tuấn";
            row["Phone"] = "030-0074321";
            dataTable1.Rows.Add(row);

            row = dataTable1.NewRow();
            row["Company"] = "Cty Sông Tranh";
            row["Address"] = "Hà Nam";
            row["Contact"] = "Ông Hùng";
            row["Phone"] = "(5) 555-4729";
            dataTable1.Rows.Add(row);

            row = dataTable1.NewRow();
            row["Company"] = "Cty Sông Cầu";
            row["Address"] = "Thái Nguyên";
            row["Contact"] = "Ông Tùng";
            row["Phone"] = "(5) 555-3932";
            dataTable1.Rows.Add(row);

            row = dataTable1.NewRow();
            row["Company"] = "Cty Sông Đáy";
            row["Address"] = "Lào Cai";
            row["Contact"] = "Ông Táo";
            row["Phone"] = "(171) 555-7788";
            dataTable1.Rows.Add(row);

            row = dataTable1.NewRow();
            row["Company"] = "Cty Sông Cửu Long";
            row["Address"] = "Lai Châu";
            row["Contact"] = "Ông Ba Bị";
            row["Phone"] = "0921-12 34 65";
            dataTable1.Rows.Add(row);
        }

        private void ToolStripStatusLabel2Click(object sender, EventArgs e)
        {
            //Xuất Excel
            excelExportFilter1.Export(inlineReportSlot1.RenderDocument(), Application.StartupPath + "\\Test.xlsx");
        }

        private void ToolStripStatusLabel3Click(object sender, EventArgs e)
        {
            //Xuất PDF
            pdfExportFilter1.Export(inlineReportSlot1.RenderDocument(), Application.StartupPath + "\\Test.pdf");
        }
    }
}
