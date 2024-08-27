using ECommerce.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstraction
{
	public interface IProductService
	{
		Task<List<Product>> GetAlLProductAsync();
		Task<List<Product>> GetAllByCategoryAsync(int categoryId);
		Task AddAsync(Product product);
		Task UpdateAsync(Product product);
		Task DeleteAsync(int id);
		Task DeleteForCategoryId(int categoryId); 
		Task<Product> GetByIdAsync(int id);
		 
	}
}
