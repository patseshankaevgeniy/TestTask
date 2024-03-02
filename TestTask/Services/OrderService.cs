using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext dbContext;

        public OrderService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<Order> GetOrder()
        {
            var order = this.dbContext.Orders.OrderByDescending(o=> o.Price).First();
            return Task.FromResult(order);
        }

        public Task<List<Order>> GetOrders()
        {
            var orders = this.dbContext.Orders.Where(o => o.Quantity > 10).ToList();
            return Task.FromResult(orders);
        }
    }
}
