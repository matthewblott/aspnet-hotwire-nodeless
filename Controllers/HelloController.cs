namespace aspnet_hotwire_nodeless.Controllers;

using Microsoft.AspNetCore.Mvc;

public class HelloController : Controller
{
  public IActionResult Index()
  {
    return View();
  }
}
