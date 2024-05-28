using Microsoft.AspNetCore.Mvc;
using Pluralsight.AspNetCore.BethanysPie.Models;
using Pluralsight.AspNetCore.BethanysPie.ViewModels;

namespace Pluralsight.AspNetCore.BethanysPie.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var piesOfTheWeek = _pieRepository.PiesOfTheWeek;
            var homeViewModel = new HomeViewModel(piesOfTheWeek);
            return View(homeViewModel);
        }
    }
}
