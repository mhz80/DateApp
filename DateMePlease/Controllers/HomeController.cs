using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DateMePlease.Data;

namespace DateMePlease.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      var ctx = new DateMePleaseContext();
      var members = ctx.Members.ToList();

      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}