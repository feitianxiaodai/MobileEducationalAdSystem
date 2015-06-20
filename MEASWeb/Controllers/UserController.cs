using MEASWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MEASWeb.Controllers
{

    public class UserController : Controller
    {
        MEASService.Service.UserInfo iUserService = new MEASService.Service.UserInfo();
        MEASService.Service.TopicInfo iTopicService = new MEASService.Service.TopicInfo();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _AjaxGetUserRecords()
        {
            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
            int pageCount = 0;
            int pageIndex = Convert.ToInt16(Request.Form["pageIndex"]);
            var userList = iUserService.GetUserRecords(pageIndex, pageSize, out pageCount).Select(s => Convetor.UserConvertor.ConvertToUserViewModel(s)).ToList();
            return Json(new GridData<object>(userList, pageCount));
        }

        public ActionResult EditUserTopic(int id)
        {
            var userDbModel = iUserService.GetUserInfoByID(id);
            Models.MemberViewModel viewModel = null;
            if (userDbModel != null)
            {
                viewModel = Convetor.UserConvertor.ConvertToUserViewModel(userDbModel);
            }
            var topicRecords = iTopicService.GetAllTopicRecords().Select(s => Convetor.TopicConvertor.ConvertToTopicViewModel(s)).ToList();
            ViewBag.topicRecords = topicRecords;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditUserTopic(MemberViewModel viewModel, int[] TopicGroup)
        {
            bool result = iUserService.UpdateUserTopic(viewModel.Id, TopicGroup);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult _AjaxDeleteUsers(int[] ids)
        {
            bool result = iUserService.DeleteUserByIds(ids);
            var ajaxResult = new AjaxResultModel() { Type = "Error", Content = "删除失败" };
            if (result)
            {
                ajaxResult.Content = "删除成功";
                ajaxResult.Type = "Success";
            }
            return Json(ajaxResult);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.MemberViewModel viewModel)
        {
            var result = iUserService.Login(viewModel.MemberId, viewModel.MemberPwd);
            if (result != null)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("error", "用户名或密码错误");
            return View();
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }


    }
}
