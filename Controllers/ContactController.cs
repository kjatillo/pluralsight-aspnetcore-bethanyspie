using Microsoft.AspNetCore.Mvc;

namespace Pluralsight.AspNetCore.BethanysPie.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
