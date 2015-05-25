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

        public string GroupTitle { get; set; }

        public int GroupId { get; set; }

        public string MemberPwd { get; set; }
    }
}