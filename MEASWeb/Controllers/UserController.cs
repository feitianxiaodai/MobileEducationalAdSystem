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
        MEASService.Service.OrganStructInfo iOrganStruct = new MEASService.Service.OrganStructInfo();
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = iUserService.GetUserInfoByID(id);
            MemberViewModel userViewModel = new MemberViewModel()
            {
                DepId = user.DepId,
                IsAdmin = user.IsAdmin,
                Id = user.Id,
                IsDel = user.IsDel,
                MemberId = user.MemberId,
                SName = user.SName,
            };
            var organStructList = iOrganStruct.GetAllOrganStructList(s => s.Status == 1);
            List<SelectListItem> selectItems = new List<SelectListItem>();

            //生成部门的下拉框
            if (organStructList != null && organStructList.Count > 0)
            {
                foreach (var item in organStructList)
                {
                    selectItems.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString(), Selected = item.Id == userViewModel.DepId ? true : false });
                }
            }

            //生成用户状态下拉框
            List<SelectListItem> userStatusSelect = new List<SelectListItem>()
            {
                new SelectListItem{ Text= "正常",Value="0"},
                new SelectListItem{Text="删除",Value="1"},
            };

            //生成用户是否为管理员下拉框
            List<SelectListItem> isAdminSelect = new List<SelectListItem>()
            {
               new SelectListItem{ Text= "管理员", Value="1", Selected = userViewModel.IsAdmin==1?true:false },
               new SelectListItem{Text="普通用户",Value="0" , Selected = userViewModel.IsAdmin==0?true:false},
            };

            ViewBag.OrganStruct = selectItems;
            ViewBag.Status = userStatusSelect;
            ViewBag.IsAdmin = isAdminSelect;
            return View(userViewModel);
        }

        [HttpPost]
        public ActionResult Edit(MEASWeb.Models.MemberViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var model = Convetor.UserConvertor.ConvertToDbModel(viewModel);
                iUserService.Update(model);
            }
            return RedirectToAction("Index");
            
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
