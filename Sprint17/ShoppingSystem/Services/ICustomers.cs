using ShoppingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingSystem.Services
{
	public interface ICustomers
	{
		Task<IList<Customer>> GetAllAsync();
		Task<Customer> GetByIdAsync(int Id);
		Task EditAsync(Customer model);
		Task AddAsync(Customer model);
		Task DeleteAsync(int id);
	}
}
