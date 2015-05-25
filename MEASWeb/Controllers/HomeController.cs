using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MEASWeb.Models;
namespace MEASWeb.Controllers
{
    public class HomeController : Controller
    {
        MEASService.Service.NewsInfo iNewsInfo = new MEASService.Service.NewsInfo();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _AjaxGetNewsRecords(int sEcho, int iDisplayStart)
        {
            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
            int pageIndex = iDisplayStart / pageSize + 1;
            int pageCount=0;
            var newsList = Convetor.newsListShowConvertor.ConvertToNewsListViewModel(iNewsInfo.GetNewsRecords(pageIndex, pageSize, out pageCount));
            return Json(new PageResult { 
                sEcho=sEcho,
                iTotalDisplayRecords=pageCount,
                iTotalRecords=pageCount,
                aaData=newsList
            },JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Push()
        {
            pushService.MyPushServiceDelegateClient client = new pushService.MyPushServiceDelegateClient();
            Information info = new Information();
            //var content = HttpUtility.UrlEncode("这是内容", Encoding.UTF8);
            info.title = "哈哈";
            info.content = "这是内容";
            info.type = 2;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var result = client.PushMessage(jss.Serialize(info));
            if (result == 0)
            {
                return Json(new { res = 0 });
            }
            return Json(new { res = 1 });
        }

        public string EncodeMethod(string content)
        {
            return HttpUtility.UrlEncode(content, Encoding.UTF8);
        }
    }

    public class Information
    {
        public string title { get; set; }

        public string content { get; set; }

        public int type { get; set; }
    }
}
