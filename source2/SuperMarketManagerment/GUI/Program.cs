using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GUI;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Process curr = Process.GetCurrentProcess();
            //Process[] curarr = Process.GetProcessesByName(curr.ProcessName);
            //bool run=true;
            //foreach (Process item in curarr)
            //{
            //    if (item.Id != curr.Id && item.MainModule.FileName == curr.MainModule.FileName)
            //    {
            //        run = false;
            //    }
            //}
            //if (run)
                Application.Run(new frmLoad());
            //else
            //{
            //    MessageBox.Show("chương trình đang chạy");
            //    Application.Exit();
            //}
            //try
            //{
            //    Server_Client.Client cl = new Server_Client.Client();
            //    // gán TCPclient
            //    TcpClient client1 = cl.Connect(Luu.IP, Luu.Ports);
            //    NetworkStream clientstrem = cl.SerializeObj(client1, "LogOut", frmDangNhap.User);
            //    // đổ mảng đối tượng vào datagripview       
            //    cl.DeserializeHepper(clientstrem, null);
            //}
            //catch (Exception){}
            //finally
            //{
                Environment.Exit(-1);
            //}
        }
    }
}
