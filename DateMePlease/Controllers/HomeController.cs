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
    private IDateMePleaseRepository _repository;
    public HomeController(IDateMePleaseRepository repository)
    {
      _repository = repository;
    }

    public ActionResult Index()
    {
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

    public ActionResult Acknowledgements()
    {
      return View();
    }
  }
}