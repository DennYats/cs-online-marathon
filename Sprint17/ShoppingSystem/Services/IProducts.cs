using ShoppingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingSystem.Services
{
	public interface IProducts
	{
		Task<IList<Product>> GetAllAsync();
		Task<Product> GetByIdAsync(int Id);
		Task EditAsync(Product model);
		Task AddAsync(Product model);
		Task DeleteAsync(int id);
	}
}
