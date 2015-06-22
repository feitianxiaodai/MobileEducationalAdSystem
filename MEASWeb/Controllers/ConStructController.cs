using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MEASWeb.Controllers
{
    public class OrganStructController : Controller
    {
        MEASService.Service.OrganStructInfo iOrganStructService = new MEASService.Service.OrganStructInfo();
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获得树节点
        /// </summary>
        /// <returns></returns>
        public ActionResult _AjaxGetOrganStructTree()
        {
            var organStruct = iOrganStructService.GetAllOrganStructList(s => true).ToList();
            var treeNodes = iOrganStructService.GetTreeNode(organStruct);
            return Json(treeNodes);

        }

        [HttpGet]
        public ActionResult Add()
        {
            var organStructList = iOrganStructService.GetAllOrganStructList(s => s.Status == 1);
            List<SelectListItem> organStructSelect = new List<SelectListItem>();
            if (organStructList != null && organStructList.Count > 0)
            {
                foreach (var item in organStructList)
                {
                    organStructSelect.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
                }

            }
            ViewBag.OrganStruct = organStructSelect;
            return View();
        }

        [HttpPost]
        public ActionResult Add(MEASModel.POCOModel.OrganStructViewModel viewModel)
        {
            bool result = iOrganStructService.Add(viewModel);
            return RedirectToAction("Index");
        }
    }
}
