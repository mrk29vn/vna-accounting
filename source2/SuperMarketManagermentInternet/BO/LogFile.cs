using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace BizLogic
{
    public class LogFile
    {
        public bool GhiFile(Entities.LogFile lf)
        {
            try
            {
                FileStream file = new FileStream("Log", FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(file, Encoding.UTF8);
                sr.WriteLine(lf.MaNhanVien+"-"+lf.TenDangNhap+"-"+lf.HanhDong+"-"+lf.NhoiGianThucHien+"-"+lf.NoiDung);
                sr.Close();
                file.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public Entities.LogFile[] DocFile()
        {
            Entities.LogFile[] arrlf=null;
            try
            {
                FileStream file = new FileStream("Log", FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader sr = new StreamReader(file, Encoding.UTF8);
                if(sr!=null){
                    string str="";
                    ArrayList arr=new ArrayList();
                    while((str=sr.ReadLine())!=null){
                        string[] arrStr=str.Split('-');
                        if(arrStr.Length==5)
                        {
                            Entities.LogFile temp=new Entities.LogFile(arrStr[0],arrStr[1],arrStr[2],arrStr[3],arrStr[4]);
                            arr.Add(temp);
                        }
                    }
                    if (arr.Count > 0)
                    {
                        int j = arr.Count;
                        arrlf = new Entities.LogFile[j];
                        
                        foreach (object item in arr)
                        {
                            j--;
                            arrlf[j]=(Entities.LogFile)item;
                        }
                    }
                }
                sr.Close();
                file.Close();
                return arrlf;
                
            }
            catch (Exception ex) { return null; }
        }

        public bool XoaFileLog(Entities.LogFile lf)
        {
            try
            {
                FileInfo file = new FileInfo("Log");
                if (file.Exists)
                {
                    file.Delete();
                    GhiFile(new Entities.LogFile(lf.MaNhanVien, lf.TenDangNhap, lf.HanhDong, lf.NhoiGianThucHien, lf.NoiDung));
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
