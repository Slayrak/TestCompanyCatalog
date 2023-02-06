using Microsoft.AspNetCore.Mvc;

namespace CompanyCatalogue.Controllers
{
    public class TreeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
