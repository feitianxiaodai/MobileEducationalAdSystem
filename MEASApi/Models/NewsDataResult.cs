using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEASApi.Models
{
    public class NewsDataResult
    {
        public NewsDataResult()
        {
            NewsList = new List<MEASModel.DBModel.NewsInfo>();
        }
        public PageInfo PageInfo { get; set; }

        public List<MEASModel.DBModel.NewsInfo> NewsList { get; set; }
    }
}