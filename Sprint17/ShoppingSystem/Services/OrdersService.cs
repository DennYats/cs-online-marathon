using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Data;
using ShoppingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingSystem.Services
{
	public class OrdersService : IOrders
	{
        private readonly ShoppingContext _dbContext;
        private readonly ISupermarkets _superMarkets;
        private readonly ICustomers _customers;

        public OrdersService(ShoppingContext dbContext, ISupermarkets superMarkets, ICustomers customers)
        {
            _dbContext = dbContext;
            _superMarkets = superMarkets;
            _customers = customers;
        }

        public async Task AddAsync(Order model)
        {
            Order orders = new Order()
            {
                Customer = await _customers.GetByIdAsync(model.CustomerId),
                Supermarket = await _superMarkets.GetByIdAsync(model.SupermarketId),
                OrderDate = model.OrderDate
            };
            await _dbContext.Orders.AddAsync(orders);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (!(_dbContext.Orders.Any(s => s.Id == id)))
            {
                throw new Exception("On this Id nothing found");
            }
            _dbContext.Orders.Remove(new Order { Id = id });
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Order model)
        {
            if (!(_dbContext.Supermarkets.Any(s => s.Id == model.Id)))
            {
                throw new Exception("On this Id nothing found");
            }
            _dbContext.Orders.FirstOrDefault(s => s.Id == model.Id).CustomerId = model.CustomerId;
            _dbContext.Orders.FirstOrDefault(s => s.Id == model.Id).SupermarketId = model.SupermarketId;
            _dbContext.Orders.FirstOrDefault(s => s.Id == model.Id).OrderDate = model.OrderDate;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<Order>> GetAllAsync()
        {
            return await _dbContext.Orders.Include(o => o.Supermarket).Include(o => o.Customer).ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int Id)
        {
            var result = await _dbContext.Orders.Include(o => o.Supermarket).Include(o => o.Customer).FirstOrDefaultAsync(s => s.Id == Id);
            if (result == null)
            {
                throw new Exception("On this Id nothing found");
            }
            return result;
        }

    }
}
