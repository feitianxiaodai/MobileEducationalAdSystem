using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEASWeb.Models
{
    public class PageResult
    {
        public int sEcho { get; set; }

        public int iTotalRecords { get; set; }

        public int iTotalDisplayRecords { get; set; }

        public object aaData { get; set; }
    }
}