using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEASApi.Models
{
    public class NewsInfoResult:BaseResult
    {
        public NewsInfoResult()
        {
            Data = new NewsDataResult();
        }
        public NewsDataResult Data { get; set; }
    }

}