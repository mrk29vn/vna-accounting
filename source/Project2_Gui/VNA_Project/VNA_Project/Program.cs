using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Qios.DevSuite.Components;

namespace VNA_Project
{
    static class Program
    {
        private static QTranslucentWindow m_oSplash;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ShowSplashScreen();
            Application.Run(new VNAMain());
            //Application.Run(new NGHIEPVU.DieuChinhGiaTriTaiSanFolder.frmNVDieuChinhGiaTriTaiSan());
        }

        /// <summary>
        /// Shows the Splash screen
        /// </summary>
        public static void ShowSplashScreen()
        {
            m_oSplash = new QTranslucentWindow();
            m_oSplash.BackgroundImage = new System.Drawing.Bitmap(Application.StartupPath + @"\IMG\Splash.jpg");
            m_oSplash.TopMost = true;
            m_oSplash.ShowCenteredOnScreen();
            Application.Idle += new EventHandler(Application_Idle);
        }

        private static void Application_Idle(object sender, EventArgs e)
        {
            Application.Idle -= new EventHandler(Application_Idle);
            if (m_oSplash != null)
            {
                m_oSplash.Close();
                m_oSplash = null;
            }

        }
    }
}
