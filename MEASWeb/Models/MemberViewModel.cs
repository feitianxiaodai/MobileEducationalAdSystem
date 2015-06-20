using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEASWeb.Models
{
    public class MemberViewModel
    {
        public int Id { get; set; }

        public string MemberId { get; set; }

        public string SName { get; set; }

        public string DepName { get; set; }
        public string MemberPwd { get; set; }

        public int IsDel { get; set; }

        public int IsAdmin { get; set; }

        public DateTime CreateTime { get; set; }
    }
}