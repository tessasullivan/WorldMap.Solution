using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorldMap.Models;

namespace WorldMap.Controllers
{
  public class HomeController : Controller
  {

    [Route("/")]
    public ActionResult Index() 
    {
      return View();
    }
  }
}
