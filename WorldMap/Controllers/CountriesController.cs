using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorldMap.Models;

namespace WorldMap.Controllers
{
  public class CountriesController : Controller
  {

    [Route("/countries")]
    public ActionResult Index() 
    {
      List<Country> allCountries = Country.GetAll();
      return View(allCountries);
    }
  }
}
