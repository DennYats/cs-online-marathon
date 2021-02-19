using ShoppingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingSystem.Services
{
	public interface ISupermarkets
	{
		Task<IList<Supermarket>> GetAllAsync();

		Task<Supermarket> GetByIdAsync(int Id);

		Task EditAsync(Supermarket model);

		Task AddAsync(Supermarket model);

		Task DeleteAsync(int id);

	}
}
