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

        public ActionResult Index1()
        {
            return View();
        }

        [AjaxOnly]
        public ActionResult GetMenuData()
        {
            List<TreeNode> nodes = new List<TreeNode>()
            {
                new TreeNode()
                {
                    Text = "权限",
                    IconCls = "pic_26",
                    Children = new List<TreeNode>()
                    {
                        new TreeNode() { Text = "用户管理", IconCls = "pic_5", Url = Url.Action("Index", "Users") },
                        new TreeNode() { Text = "角色管理", IconCls = "pic_198", Url = Url.Action("Index", "Roles") },
                        new TreeNode() { Text = "组织机构管理", IconCls = "pic_93", Url = Url.Action("Index", "Organizations") },
                    }
                },
                new TreeNode()
                {
                    Text = "系统",
                    IconCls = "pic_100",
                    Children = new List<TreeNode>()
                    {
                        new TreeNode() { Text = "操作日志", IconCls = "pic_125", Url = Url.Action("Index", "OperateLogs") },
                        new TreeNode() { Text = "系统日志", IconCls = "pic_101", Url = Url.Action("Index", "SystemLogs") },
                        new TreeNode() { Text = "系统设置", IconCls = "pic_89", Url = Url.Action("Index", "SystemSettings") }
                    }
                }
            };

            Action<ICollection<TreeNode>> action = list =>
            {
                foreach (TreeNode node in list)
                {
                    node.Id = "node" + node.Text;
                }
            };

            foreach (TreeNode node in nodes)
            {
                node.Id = "node" + node.Text;
                if (node.Children != null && node.Children.Count > 0)
                {
                    action(node.Children);
                }
            }

            return Json(nodes, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }

    public class Information
    {
        public string title { get; set; }

        public string content { get; set; }

        public int type { get; set; }
    }

    public class TreeNode
    {
        public TreeNode()
        {
            Checked = false;
        }

        public string Id { get; set; }

        public string Text { get; set; }

        public bool Checked { get; set; }

        public int Order { get; set; }

        public string IconCls { get; set; }

        public string Url { get; set; }

        public ICollection<TreeNode> Children { get; set; }
    }
}
