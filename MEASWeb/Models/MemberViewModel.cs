using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEASWeb.Models
{
    public class MemberViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage="*")]
        public string MemberId { get; set; }

        [Required(ErrorMessage="*")]
        public string SName { get; set; }

        public int DepId { get; set; }
        public string DepName { get; set; }
        public string MemberPwd { get; set; }

        public int IsDel { get; set; }

        public int IsAdmin { get; set; }

        public DateTime CreateTime { get; set; }
    }
}