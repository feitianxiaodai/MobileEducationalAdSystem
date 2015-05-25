using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEASWeb.Models
{
    public class PushMessageModel
    {
        public string title { get; set; }

        public string content { get; set; }

        public string newId { get; set; }

        public string type { get; set; }
    }
}