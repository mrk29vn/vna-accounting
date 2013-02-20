using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Security.Principal;
using log4net.Config;
using System.IO;

namespace Accounting.Frm
{

    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Bootstrapper.InitializeContainer();
            string str = "\\Config\\logging.config";
            XmlConfigurator.ConfigureAndWatch(new FileInfo(str));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm.MainFrm());
            //Application.Run(new Accounting.Frm.Frm.DanhMuc.PhongBan.PhongBanFrm());
        }
    }
}
