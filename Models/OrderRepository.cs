﻿namespace Pluralsight.AspNetCore.BethanysPie.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BethanysPieDbContext _bethanysPieDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(BethanysPieDbContext bethanysPieDbContext, IShoppingCart shoppingCart)
        {
            _bethanysPieDbContext = bethanysPieDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _bethanysPieDbContext.Orders.Add(order);
            _bethanysPieDbContext.SaveChanges();
        }
    }
}
