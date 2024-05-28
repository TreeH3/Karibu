using Microsoft.AspNetCore.Mvc;

namespace Karibu.Controllers
{
    public class Dashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
