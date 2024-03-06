using Microsoft.EntityFrameworkCore;
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
            var order = this.dbContext.Orders.Include(o=>o.User).OrderByDescending(o => o.Price).First();
            var user = order.User;
            return Task.FromResult(order);
        }

        public Task<List<Order>> GetOrders()
        {
            var orders = this.dbContext.Orders.Where(o => o.Quantity > 10).Include(o => o.User).ToList();
            return Task.FromResult(orders);
        }
    }
}
