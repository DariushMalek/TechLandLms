using System;
using System.Collections.Generic;
using System.Text;

namespace TechLandTools.Common
{
    public class TechLandException:Exception
    {
        public string Message { get; set; }
        public string ExceptionHint { get; set; }
        public int? ExceptionNo { get; set; }

        public TechLandException()
        {

        }

        public TechLandException(string message)
        {
            Message = message;
        }

        public TechLandException(string message,string exceptionHint)
        {
            Message = message;
            ExceptionHint = exceptionHint;
        }

        public TechLandException(string message, int exceptionNo)
        {
            Message = message;
            ExceptionNo = exceptionNo;
        }
    }
}
