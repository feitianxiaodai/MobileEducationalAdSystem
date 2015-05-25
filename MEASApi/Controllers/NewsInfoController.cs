using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEASApi.Models;
using MEASApi.Models.ParameterModel;
using System.Configuration;
namespace MEASApi.Controllers
{
    public class NewsInfoController : ApiController
    {
        MEASService.Service.NewsInfo iNewsInfo = new MEASService.Service.NewsInfo();
        [HttpPost]
        public NewsInfoResult GetNewsTitle([FromBody]NewsInfoParameterModel page)
        {
            int pageIndex = page.pageIndex;
            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
            NewsInfoResult result = new NewsInfoResult();
            int pageCount=0;
            try
            {
                var newsRecords = iNewsInfo.GetNewsRecords(pageIndex, pageSize,page.newType, out pageCount);
                result.ErrorCode = 0;
                result.Message = "成功";
                result.Data.PageInfo = new PageInfo()
                {
                    PageIndex = pageIndex,
                    PageTotalNumber = pageCount
                };
                result.Data.NewsList = newsRecords;
            }
            catch(Exception ex)
            {
                result.ErrorCode = 1;
                result.Message = "失败";
            }
            return result;
            
        }

        [HttpPost]
        public NewsInfoModel GetNewsModel([FromBody]NewsInfoParameterModel page)
        {
            NewsInfoModel result = new NewsInfoModel();
            int newId = page.newId;
            try
            {
                var newsModel = iNewsInfo.GetNewsInfoModel(newId);
                result.Message = "Success";
                result.ErrorCode = 0;
                result.Data.New = newsModel;
            }
            catch (Exception ex)
            {
                result.Message = "Fail";
                result.ErrorCode = 1;
            }
            return result;
        }
    }

   
}
