using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MEASWeb.Models;
using MEASWeb.Convetor;
using System.IO;
using System.Configuration;
namespace MEASWeb.Controllers
{
    public class NewsController : Controller
    {
        MEASService.Service.NewsInfo iNewService = new MEASService.Service.NewsInfo();
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(NewsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dbModel = newsViewModelConvertor.ConvertToDbModel(viewModel);
                if (iNewService.Add(dbModel) > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Upload()
        {
            string baseURL = ConfigurationManager.AppSettings["baseURL"].ToString();
            List<string> uploadImgPath = new List<string>();
            if (Request.Files.Count > 0)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase files = Request.Files[i];
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string picFileName = string.Format("{0}{1}", fileName, Path.GetExtension(files.FileName));
                    string path = Server.MapPath("~/Upload/newsImage/");
                    files.SaveAs(string.Format("{0}{1}", path, picFileName));
                    uploadImgPath.Add(string.Format("{0}{1}{2}", baseURL, "Upload/newsImage/", picFileName));
                }

            }
            return Json(new { path = uploadImgPath });

        }


        public ActionResult Edit(int id)
        {
            var dbModel = iNewService.GetNewsInfoModel(id);
            NewsViewModel viewModel = new NewsViewModel();
            if (dbModel != null)
            {
                viewModel = Convetor.newsViewModelConvertor.ConvertToNewViewModel(dbModel);
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NewsViewModel viewModel)
        {
            string[] update = { "author", "source", "newBodyHtml", "title", "imageUrl","newType" };
            if (ModelState.IsValid)
            {
                var dbModel = newsViewModelConvertor.ConvertToDbModel(viewModel);
                if (iNewService.Edit(dbModel, update) > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (iNewService.Delete(id))
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
