using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Data;
using ShoppingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingSystem.Services
{
	public class OrderDetailsService : IOrderDetails
	{
        private readonly ShoppingContext _dbContext;

        public OrderDetailsService(ShoppingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(OrderDetails model)
        {
            OrderDetails orders = new OrderDetails();
            await _dbContext.OrdersDetails.AddAsync(orders);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (!(_dbContext.OrdersDetails.Any(s => s.Id == id)))
            {
                throw new Exception("On this Id nothing found");
            }
            _dbContext.OrdersDetails.Remove(new OrderDetails { Id = id });
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(OrderDetails model)
        {
            if (!(_dbContext.Supermarkets.Any(s => s.Id == model.Id)))
            {
                throw new Exception("On this Id nothing found");
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<OrderDetails>> GetAllAsync()
        {
            return await _dbContext.OrdersDetails.Include(o => o.Product).Include(o => o.Order).ToListAsync();
        }

        public async Task<OrderDetails> GetByOrderIdAsync(int Id)
        {
            var list = _dbContext.OrdersDetails.Include(o => o.Product).Include(o => o.Order);
            OrderDetails result = await list.FirstOrDefaultAsync(o => o.Order.Id == Id);
            if (result == null)
            {
                throw new Exception("On this Id nothing found");
            }
            return result;
        }
    }
}
