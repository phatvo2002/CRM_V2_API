using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Common
{
    public class Response<T>
    {
        public Response() { }
        public Response(T? data, string? message = null)
        {
            Succeed = true;
            Message = message;
            Data = data;
        }

        public Response(string? message, object? error = null)
        {
            Succeed = false;
            Message = message;
            Error = error;
        }

        public bool Succeed { get; set; } = false;
        public string? Message { get; set; }
        public object? Error { get; set; }
        public T? Data { get; set; }
    }
}
