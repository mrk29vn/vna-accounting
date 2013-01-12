using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GUI.Report
{
    public class ExportCrystalReport
    {
        public enum TypeBC { WordForWindows, Excel, PortableDocFormat };
        public bool Export(CrystalDecisions.CrystalReports.Engine.ReportClass report, string path, TypeBC type)
        {
            if (report == null)
                return false;
            switch (type)
            {
                case TypeBC.WordForWindows:
                    {
                        int index=path.LastIndexOf('.');
                        if (index > 0)
                        {
                            if (path.Substring(index + 1).ToLower().Equals("doc"))
                            {
                                report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.WordForWindows, path);
                            }
                            else if(index==path.Length-1)
                                report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.WordForWindows, path+"doc");
                            else
                                report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.WordForWindows, path + ".doc");
                        }
                        else
                            report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.WordForWindows, path + ".doc");
                        break;
                    }
                case TypeBC.Excel:
                    {
                        int index = path.LastIndexOf('.');
                        if (index > 0)
                        {
                            if (path.Substring(index + 1).ToLower().Equals("xls"))
                            {
                                report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, path);
                            }
                            else if (index == path.Length - 1)
                                report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, path + "xls");
                            else
                                report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, path + ".xls");
                        }
                        else
                            report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, path + ".xls");
                        break;
                    }
                case TypeBC.PortableDocFormat:
                    {
                        int index = path.LastIndexOf('.');
                        if (index > 0)
                        {
                            if (path.Substring(index + 1).ToLower().Equals("pdf"))
                            {
                                report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path);
                            }
                            else if (index == path.Length - 1)
                                report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path + "pdf");
                            else
                                report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path + ".pdf");
                        }
                        else
                            report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path + ".pdf");
                        break;
                    }
            }
            return true;
        }
    }
}
