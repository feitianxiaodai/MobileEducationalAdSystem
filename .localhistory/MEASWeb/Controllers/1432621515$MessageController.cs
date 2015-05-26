using MEASWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MEASWeb.Controllers
{
    public class MessageController : Controller
    {
        MEASService.Service.MessageInfo iMessageService = new MEASService.Service.MessageInfo();
        MEASService.Service.GroupInfo iGroupService = new MEASService.Service.GroupInfo();
        pushService.MyPushServiceDelegateClient pushService = new pushService.MyPushServiceDelegateClient();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _AjaxGetMessageRecords(int sEcho, int iDisplayStart)
        {
            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
            int pageIndex = iDisplayStart / pageSize + 1;
            int pageCount = 0;
            var messageList = Convetor.messageCovertor.ConvertToMessageViewModel(iMessageService.GetMessageRecordsList(pageIndex, pageSize, out pageCount));
            return Json(new PageResult
            {
                sEcho = sEcho,
                iTotalDisplayRecords = pageCount,
                iTotalRecords = pageCount,
                aaData = messageList
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            var groupList = iGroupService.GetGroupList();
            ViewBag.group = groupList;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.MessageListViewModel model)
        {
            //添加数据到数据库
            var dbModel = new MEASModel.DBModel.MessageInfo();
            dbModel.MessageContent = model.MessageContent;
            dbModel.MessageTitle = model.MessageTitle;
            dbModel.PushTime = DateTime.Now.ToString();

            if (model.PushGroup != null && model.PushGroup.Count() > 0)
            {
                foreach (var groupId in model.PushGroup)
                {
                    dbModel.GroupInfo.Add(new MEASModel.DBModel.GroupInfo { Id = groupId });
                }
            }
            iMessageService.AddMessage(dbModel);

            //推动消息给服务器
            var pushModel = new Models.PushMessageModel() { content = model.MessageContent, title = model.MessageTitle };
            if(model.NewID>0)
            {
                pushModel.newId = model.NewID.ToString();
                pushModel.type = "3";
            }
            else
            {
                pushModel.type = "1";
            }
            string pushMessageToMobile = new JavaScriptSerializer().Serialize(pushModel);
            try
            {
                List<string> topicList = GetTopicByGroupIDs(model.PushGroup);
                pushService.PushMessage(pushMessageToMobile);
                //pushService.PushMessageByTopic("1108010216", pushMessageToMobile);
                var msgHtml = Utility.HtmlHelper.RenderViewToString(ControllerContext, "~/Views/Message/_PartialMessage.cshtml", model, true);
                return Json(new { msg = msgHtml, res = "ok" });
            }
            catch (Exception ex)
            {
                var msgHtml = Utility.HtmlHelper.RenderViewToString(ControllerContext, "~/Views/Message/_PartialMessage.cshtml", model, true);
                return Json(new { msg = msgHtml, res = "ok" });
            }

        }

        private List<string> GetTopicByGroupIDs(int[] groupIds)
        {
            List<string> topicList = new List<string>();
            topicList = iMessageService.GetTopicByGroupIds(groupIds);
            return topicList;
        }
    }
}
