﻿using MEASWeb.Models;
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

        [HttpGet]
        public ActionResult _AjaxGetUserRecords(int sEcho, int iDisplayStart)
        {
            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
            int pageIndex = iDisplayStart / pageSize + 1;
            int pageCount = 0;
            var userList = iUserService.GetUserRecords(pageIndex, pageSize, out pageCount).Select(s=>Convetor.UserConvertor.ConvertToUserViewModel(s)).ToList();
            return Json(new PageResult
            {
                sEcho = sEcho,
                iTotalDisplayRecords = pageCount,
                iTotalRecords = pageCount,
                aaData = userList
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditUserTopic(int id)
        {
            var userDbModel = iUserService.GetUserInfoByID(id);
            Models.MemberViewModel viewModel = null;
            if(userDbModel!=null)
            {
                viewModel = Convetor.UserConvertor.ConvertToUserViewModel(userDbModel);
            }
            var topicRecords = iTopicService.GetAllTopicRecords().Select(s=>Convetor.TopicConvertor.ConvertToTopicViewModel(s)).ToList();
            ViewBag.topicRecords = topicRecords;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditUserTopic(MemberViewModel viewModel, int[] TopicGroup)
        {
            bool result = iUserService.UpdateUserTopic(viewModel.Id, TopicGroup);
            if(result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.MemberViewModel viewModel)
        {
            var result = iUserService.Login(viewModel.MemberId, viewModel.MemberPwd);
            if(result!=null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}
