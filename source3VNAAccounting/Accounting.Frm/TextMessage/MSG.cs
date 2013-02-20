using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Frm.TextMessage
{
    public class MSG
    {
        public static string TieuDe = "Thông báo";

        #region Hệ thống
        /// <summary>
        /// Đang tải dữ liệu, xin vui lòng đợi trong giây lát!"
        /// </summary>
        /// <returns></returns>
        public static string MSG_HeThong_01() { return "Đang tải dữ liệu, xin vui lòng đợi trong giây lát!"; }
        /// <summary>
        /// Dữ liệu đã bị thay đổi, bạn có muốn ghi lại không?
        /// </summary>
        /// <returns></returns>
        public static string MSG_HeThong_02() { return "Dữ liệu đã bị thay đổi, bạn có muốn ghi lại không?"; }
        #endregion

        #region Thao tác csdl

        public static string MSG_ThaoTacCSDL(string thaotac, string obj, bool status)
        {
            thaotac = thaotac.Equals("add") ? "Thêm" : thaotac.Equals("edit") ? "Sửa" : "Xóa";
            string _status = status ? "thành công!" : "thất bại!";
            return string.IsNullOrEmpty(obj) ? thaotac + " " + status : thaotac + " " + obj + " " + status;
        }
        #endregion
    }
}
