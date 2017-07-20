using Microsoft.AspNetCore.Mvc;

namespace Lightweight.NetCore.MVC.Presentation.Website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}