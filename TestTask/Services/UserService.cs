using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<User> GetUser()
        {
            var user = this.dbContext.Users.Include(u => u.Orders).OrderByDescending(u => u.Orders.Count).First();
            return Task.FromResult(user);
        }

        public Task<List<User>> GetUsers()
        {
            var users = this.dbContext.Users.Where(u => u.Status == Enums.UserStatus.Inactive).Include(u => u.Orders).ToList();
            return Task.FromResult(users);
        }
    }
}
