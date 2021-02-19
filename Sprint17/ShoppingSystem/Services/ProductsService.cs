using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Data;
using ShoppingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingSystem.Services
{
	public class ProductsService : IProducts
	{
        private readonly ShoppingContext _dbContext;

        public ProductsService(ShoppingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Product model)
        {
            Product products = new Product() { Name = model.Name, Price = model.Price };
            await _dbContext.Products.AddAsync(products);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (!(_dbContext.Products.Any(p => p.Id == id)))
            {
                throw new Exception("Nothing found");
            }
            _dbContext.Products.Remove(new Product { Id = id });
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Product model)
        {
            if (!(_dbContext.Products.Any(p => p.Id == model.Id)))
            {
                throw new Exception("Nothind found");
            }
            _dbContext.Products.FirstOrDefault(p => p.Id == model.Id).Name = model.Name;
            _dbContext.Products.FirstOrDefault(p => p.Id == model.Id).Price = model.Price;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int Id)
        {
            var result = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == Id);
            if (result == null)
            {
                throw new Exception("Nothing found");
            }
            return result;
        }
    }
}
