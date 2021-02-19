using ShoppingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingSystem.Services
{
	public interface IOrderDetails
	{
		Task<IList<OrderDetails>> GetAllAsync();

		Task<OrderDetails> GetByOrderIdAsync(int Id);

		Task EditAsync(OrderDetails model);

		Task AddAsync(OrderDetails model);

		Task DeleteAsync(int id);
	}
}
