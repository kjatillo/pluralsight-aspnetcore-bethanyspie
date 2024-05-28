using Pluralsight.AspNetCore.BethanysPie.Models;

namespace Pluralsight.AspNetCore.BethanysPie.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; }

        public HomeViewModel(IEnumerable<Pie> piesOfTheWeek) 
        {
            PiesOfTheWeek = piesOfTheWeek;
        }
    }
}
