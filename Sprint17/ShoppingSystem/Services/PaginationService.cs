using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShoppingSystem.Services
{
	public class PaginationService<T> : List<T>
	{
		public int PageIndex { get; private set; }
		public int TotalPages { get; private set; }

        public PaginationService(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage { get => (PageIndex > 1); }

        public bool HasNextPage { get => (PageIndex < TotalPages); }

        public static async Task<PaginationService<T>> CreateAsync(IList<T> source, int pageIndex, int pageSize)
        {
            var count = await source.AsQueryable().CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).AsQueryable().ToListAsync();
            return new PaginationService<T>(items, count, pageIndex, pageSize);
        }
    }
}
