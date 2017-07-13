using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(ModelCounter ctr)
        {
            
            if (ctr.CurrentCounter == 0)
                ctr.GetCurrentCounter();
            return View(ctr);
        }

        public ActionResult AddCounter(ModelCounter ctr)
        {
            ctr.AddCounter();
            return RedirectToAction("Index", ctr);
        }
    }
}