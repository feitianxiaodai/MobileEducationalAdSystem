using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEASWeb.Models
{
    public class NewsViewModel
    {
        public NewsViewModel()
        {
            this.PublishTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.Author = "Admin";
        }
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Source { get; set; }

        public int NewType { get; set; }

        public string PublishTime { get; set; }


        public string Author { get; set; }

        public string newBodyHtml { get; set; }

        public string ImageUrl { get; set; }
    }
}