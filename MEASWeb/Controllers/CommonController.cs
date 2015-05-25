using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MEASWeb.Controllers
{
    public class CommonController : Controller
    {
       /// <summary>
       /// 出错之后跳转到的页面
       /// </summary>
       /// <returns></returns>
        public ActionResult Error()
        {
            return View();
        }

    }
}
