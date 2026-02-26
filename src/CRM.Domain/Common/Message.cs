using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Common
{
    public class Message
    {
        public static string Existed()
           => $"Dữ liệu đã tồn tại.";
        public static string NotFoundData()
            => $"Không tìm thấy dữ liệu.";
        public static string NotExistedById(string title, dynamic id)
          => $"{title} với id '{id}' chưa tồn tại trên hệ thống. Vui lòng kiểm tra lại dữ liệu.";
        public static string InputInvalid()
             => $"Lỗi nhập dữ liệu. Vui lòng kiểm tra lại dữ liệu.";
        public static string Error()
            => $"Đã có lỗi hệ thống xảy ra. Vui lòng kiểm tra lại.";
        public static string Success(string note)
            => $"{note} thành công.";
        public static string Used(string title, string table_name)
            => $"{title} đã được sử dụng ở '{table_name}' không được phép xóa.";
    }
}
