using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyUIDemo.MVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        /// <summary>
        /// iframe获取视图
        /// </summary>
        /// <returns></returns>
        public ActionResult GetView(string viewPara)
        {
            return View(viewPara);
        }
    }
}
