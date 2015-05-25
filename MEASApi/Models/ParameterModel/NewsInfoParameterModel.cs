using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEASApi.Models.ParameterModel
{
    public class NewsInfoParameterModel
    {
        public int pageIndex { get; set; }

        public int newType { get; set; }

        public int newId { get; set; }
    }
}