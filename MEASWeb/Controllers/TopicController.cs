using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MEASModel.DBModel;
using MEASService.IService;
using System.Configuration;
using MEASWeb.Models;
namespace MEASWeb.Controllers
{
    public class TopicController : Controller
    {
        MEASService.Service.TopicInfo iTopicService = new MEASService.Service.TopicInfo();
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.TopicViewModel viewModel)
        {
            Topic dbModel = Convetor.TopicConvertor.ConvertToTopicDbModel(viewModel);
            if (iTopicService.AddTopic(dbModel) > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _AjaxGetTopicRecords(int sEcho, int iDisplayStart)
        {
            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
            int pageIndex = iDisplayStart / pageSize + 1;
            int pageCount = 0;
            var topicRecords = iTopicService.GetTopicRecords(pageIndex, pageSize, out pageCount);
            var topicList = iTopicService.GetTopicRecords(pageIndex, pageSize, out pageCount).Select(s => Convetor.TopicConvertor.ConvertToTopicViewModel(s)).ToList();
            return Json(new PageResult
            {
                sEcho = sEcho,
                iTotalDisplayRecords = pageCount,
                iTotalRecords = pageCount,
                aaData = topicList
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            if (iTopicService.DeleteTopic(id))
            {
                return Json(new { result = 200 });
            }
            else
            {
                return Json(new { result = 500 });
            }
        }
    }
}
