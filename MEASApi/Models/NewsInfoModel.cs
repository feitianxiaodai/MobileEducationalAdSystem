using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEASApi.Models
{
    public class NewsInfoModel:BaseResult
    {
        public NewsInfoModel()
        {
            Data = new NewsInfoModelData();
        }
        public NewsInfoModelData Data { get; set; }
    }

    public class NewsInfoModelData
    {
        public MEASModel.DBModel.NewsInfo New { get; set; }
    }
}