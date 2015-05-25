using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEASWeb.Models
{
    public class NewsListViewModel
    {
        public int Id { get; set; }
        public string Author { get; set; }

        public string NewType { get; set; }

        public string PublishTime { get; set; }

        public string Source { get; set; }

        public string Title { get; set; }
    }
}