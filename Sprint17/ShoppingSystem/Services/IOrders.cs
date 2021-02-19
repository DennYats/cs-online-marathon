using ShoppingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingSystem.Services
{
	public interface IOrders
	{
		Task<IList<Order>> GetAllAsync();

		Task<Order> GetByIdAsync(int Id);

		Task EditAsync(Order model);

		Task AddAsync(Order model);

		Task DeleteAsync(int id);
	}
}
