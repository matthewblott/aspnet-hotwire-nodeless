namespace aspnet_hotwire_nodeless.Controllers;

using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
	public IActionResult Index()
	{
		return View();
	}

  public IActionResult About()
  {
    return View();
  }

  public IActionResult FirstFrame()
  {
    return View();
  }

  public IActionResult SecondFrame()
  {
    return View();
  }

  public IActionResult TopFrame()
  {
    return View();
  }
}
