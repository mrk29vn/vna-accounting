using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Klib2
{
    public class Registry
    {
        public Registry() { }

        public static List<List<string>> GetRegistry(string SubKey)
        {
            List<List<string>> kq = new List<List<string>>();
            Microsoft.Win32.RegistryKey tem;
            string[] Select = SubKey.Split('\\');
            if (Select[0].ToUpper().Equals("HKEY_CLASSES_ROOT"))
            {
                string tt = "";
                for (int i = 1; i < Select.Length; i++)
                {
                    if (i == (Select.Length - 1))
                    {
                        tt += Select[i];
                    }
                    else
                    {
                        tt += Select[i] + @"\";
                    }
                }
                tem = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(tt);
            }
            else if (Select[0].ToUpper().Equals("HKEY_CURRENT_USER"))
            {
                string tt = "";
                for (int i = 1; i < Select.Length; i++)
                {
                    if (i == (Select.Length - 1))
                    {
                        tt += Select[i];
                    }
                    else
                    {
                        tt += Select[i] + @"\";
                    }
                }
                tem = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(tt);
            }
            else if (Select[0].ToUpper().Equals("HKEY_LOCAL_MACHINE"))
            {//Default
                string tt = "";
                for (int i = 1; i < Select.Length; i++)
                {
                    if (i == (Select.Length - 1))
                    {
                        tt += Select[i];
                    }
                    else
                    {
                        tt += Select[i] + @"\";
                    }
                }
                tem = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(tt);
            }
            else if (Select[0].ToUpper().Equals("HKEY_USERS"))
            {
                string tt = "";
                for (int i = 1; i < Select.Length; i++)
                {
                    if (i == (Select.Length - 1))
                    {
                        tt += Select[i];
                    }
                    else
                    {
                        tt += Select[i] + @"\";
                    }
                }
                tem = Microsoft.Win32.Registry.Users.OpenSubKey(tt);
            }
            else if (Select[0].ToUpper().Equals("HKEY_CURRENT_CONFIG"))
            {
                string tt = "";
                for (int i = 1; i < Select.Length; i++)
                {
                    if (i == (Select.Length - 1))
                    {
                        tt += Select[i];
                    }
                    else
                    {
                        tt += Select[i] + @"\";
                    }
                }
                tem = Microsoft.Win32.Registry.CurrentConfig.OpenSubKey(tt);
            }
            else
            {//Default = HKEY_LOCAL_MACHINE
                string tt = "";
                for (int i = 1; i < Select.Length; i++)
                {
                    if (i == (Select.Length - 1))
                    {
                        tt += Select[i];
                    }
                    else
                    {
                        tt += Select[i] + @"\";
                    }
                }
                tem = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(tt);
            }
            if (tem != null)
            {
                kq.Add(tem.GetValueNames().ToList());
                List<string> tem0 = new List<string>();
                for (int i = 0; i < tem.GetValueNames().Length; i++)
                {
                    tem0.Add(tem.GetValue(tem.GetValueNames()[i]).ToString());
                }
                kq.Add(tem0);
            }
            return kq;
        }

        public static void SetRegistry(string SubKey, List<List<string>> input)
        {

            Microsoft.Win32.RegistryKey tem;
            string[] Select = SubKey.Split('\\');
            if (Select[0].ToUpper().Equals("HKEY_CLASSES_ROOT"))
            {
                string tt = "";
                for (int i = 1; i < Select.Length; i++)
                {
                    if (i == (Select.Length - 1))
                    {
                        tt += Select[i];
                    }
                    else
                    {
                        tt += Select[i] + @"\";
                    }
                }
                tem = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(tt);
                //tem = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(tt);
            }
            else if (Select[0].ToUpper().Equals("HKEY_CURRENT_USER"))
            {
                string tt = "";
                for (int i = 1; i < Select.Length; i++)
                {
                    if (i == (Select.Length - 1))
                    {
                        tt += Select[i];
                    }
                    else
                    {
                        tt += Select[i] + @"\";
                    }
                }
                tem = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(tt);
                //tem = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(tt);
            }
            else if (Select[0].ToUpper().Equals("HKEY_LOCAL_MACHINE"))
            {//Default
                string tt = "";
                for (int i = 1; i < Select.Length; i++)
                {
                    if (i == (Select.Length - 1))
                    {
                        tt += Select[i];
                    }
                    else
                    {
                        tt += Select[i] + @"\";
                    }
                }
                try
                {
                    tem = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(tt);
                }
                catch (Exception ex)
                {
                    tem = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(tt);
                }
                
                //tem = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(tt);
            }
            else if (Select[0].ToUpper().Equals("HKEY_USERS"))
            {
                string tt = "";
                for (int i = 1; i < Select.Length; i++)
                {
                    if (i == (Select.Length - 1))
                    {
                        tt += Select[i];
                    }
                    else
                    {
                        tt += Select[i] + @"\";
                    }
                }
                tem = Microsoft.Win32.Registry.Users.CreateSubKey(tt);
                //tem = Microsoft.Win32.Registry.Users.OpenSubKey(tt);
            }
            else if (Select[0].ToUpper().Equals("HKEY_CURRENT_CONFIG"))
            {
                string tt = "";
                for (int i = 1; i < Select.Length; i++)
                {
                    if (i == (Select.Length - 1))
                    {
                        tt += Select[i];
                    }
                    else
                    {
                        tt += Select[i] + @"\";
                    }
                }
                tem = Microsoft.Win32.Registry.CurrentConfig.CreateSubKey(tt);
                //tem = Microsoft.Win32.Registry.CurrentConfig.OpenSubKey(tt);
            }
            else
            {//Default = HKEY_LOCAL_MACHINE
                string tt = "";
                for (int i = 1; i < Select.Length; i++)
                {
                    if (i == (Select.Length - 1))
                    {
                        tt += Select[i];
                    }
                    else
                    {
                        tt += Select[i] + @"\";
                    }
                }
                tem = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(tt);
                //tem = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(tt);
            }
            if (tem != null)
            {
                for (int i = 0; i < input[0].Count; i++)
                {
                    tem.SetValue(input[0][i], input[1][i].ToString());
                }
            }
        }
    }
}
