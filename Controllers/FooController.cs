namespace aspnet_hotwire_nodeless.Controllers;

using Microsoft.AspNetCore.Mvc;

public class FooController : Controller
{
  public IActionResult Index()
  {
    return View();
  }
}
