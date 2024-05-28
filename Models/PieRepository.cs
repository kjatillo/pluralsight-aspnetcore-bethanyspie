using Microsoft.EntityFrameworkCore;

namespace Pluralsight.AspNetCore.BethanysPie.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly BethanysPieDbContext _bethanysPieDbContext;

        public PieRepository(BethanysPieDbContext bethanysPieDbContext)
        {
            _bethanysPieDbContext = bethanysPieDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _bethanysPieDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _bethanysPieDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieId)
        {
            return _bethanysPieDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
