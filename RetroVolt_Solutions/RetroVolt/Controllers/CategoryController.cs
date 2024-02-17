using Microsoft.AspNetCore.Mvc;

namespace RetroVolt.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
