namespace Pluralsight.AspNetCore.BethanysPie.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
