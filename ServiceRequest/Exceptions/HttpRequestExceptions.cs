using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRequest.Exceptions
{
    public class HttpRequestExceptions : Exception
    {
        private int code;
        private Object err;
        private String message;

        public HttpRequestExceptions() { }
        public HttpRequestExceptions(int code, String message, Object err)
        {
            this.code = code;
            this.message = message;
            this.err = err;
        }

        public String getMessage()
        {
            return message;
        }
    }
}
