using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Data;
using ShoppingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingSystem.Services
{
	public class SupermarketsService : ISupermarkets
	{
        private readonly ShoppingContext _dbContext;

        public SupermarketsService(ShoppingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Supermarket model)
        {
            Supermarket supermarket = new Supermarket() { Address = model.Address, Name = model.Name };
            await _dbContext.Supermarkets.AddAsync(supermarket);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (!(_dbContext.Supermarkets.Any(s => s.Id == id)))
            {
                throw new Exception("On this Id nothing found");
            }
            _dbContext.Supermarkets.Remove(new Supermarket { Id = id });
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Supermarket model)
        {
            if (!(_dbContext.Supermarkets.Any(s => s.Id == model.Id)))
            {
                throw new Exception("On this Id nothing found");
            }
            _dbContext.Supermarkets.FirstOrDefault(s => s.Id == model.Id).Name = model.Name;
            _dbContext.Supermarkets.FirstOrDefault(s => s.Id == model.Id).Address = model.Address;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<Supermarket>> GetAllAsync()
        {
            return await _dbContext.Supermarkets.ToListAsync();
        }

        public async Task<Supermarket> GetByIdAsync(int Id)
        {
            var result = await _dbContext.Supermarkets.FirstOrDefaultAsync(s => s.Id == Id);
            if (result == null)
            {
                throw new Exception("On this Id nothing found");
            }
            return result;
        }
    }
}
