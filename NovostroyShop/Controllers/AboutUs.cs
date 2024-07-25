using Microsoft.AspNetCore.Mvc;

namespace NovostroyShop.Controllers
{
    public class AboutUs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
