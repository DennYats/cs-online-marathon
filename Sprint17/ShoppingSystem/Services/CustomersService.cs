using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Data;
using ShoppingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingSystem.Services
{
	public class CustomersService : ICustomers
	{
        private readonly ShoppingContext _dbContext;

        public CustomersService(ShoppingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Customer model)
        {
            Customer customer = new Customer() { FirstName = model.FirstName, LastName = model.LastName, Address = model.Address, Discount = model.Discount };
            await _dbContext.Customers.AddAsync(customer);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (!(_dbContext.Customers.Any(s => s.Id == id)))
            {
                throw new Exception("On this Id nothing found");
            }
            _dbContext.Customers.Remove(new Customer { Id = id });
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Customer model)
        {
            if (!(_dbContext.Customers.Any(s => s.Id == model.Id)))
            {
                throw new Exception("On this Id nothing found");
            }
            _dbContext.Customers.FirstOrDefault(s => s.Id == model.Id).FirstName = model.FirstName;
            _dbContext.Customers.FirstOrDefault(s => s.Id == model.Id).LastName = model.LastName;
            _dbContext.Customers.FirstOrDefault(s => s.Id == model.Id).Address = model.Address;
            _dbContext.Customers.FirstOrDefault(s => s.Id == model.Id).Discount = model.Discount;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<Customer>> GetAllAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int Id)
        {
            var result = await _dbContext.Customers.FirstOrDefaultAsync(s => s.Id == Id);
            if (result == null)
            {
                throw new Exception("On this Id nothing found");
            }
            return result;
        }
    }
}
