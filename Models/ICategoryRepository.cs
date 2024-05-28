namespace Pluralsight.AspNetCore.BethanysPie.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
