using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEASWeb.Models
{
    public class MessageListViewModel
    {
        public MessageListViewModel()
        {
            this.PushTime = DateTime.Now.ToString();
        }
        public int ID { get; set; }
        public string MessageTitle { get; set; }

        public string MessageContent { get; set; }

        public string PushTime { get; set; }

        public int NewID { get; set; }
    }
}