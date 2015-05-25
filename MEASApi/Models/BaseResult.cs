using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEASApi.Models
{
    public class BaseResult
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
    }
}