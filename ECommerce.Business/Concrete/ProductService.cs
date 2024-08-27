using ECommerce.Business.Abstraction;
using ECommerce.DataAccess.Abstraction;
using ECommerce.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
	public class ProductService : IProductService
	{
		private readonly IProductDal _productDal;

		public ProductService(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public async Task AddAsync(Product product)
		{
			  await _productDal.Add(product);
		}

		public async Task DeleteAsync(int id)
		{
			var deletedItem= await _productDal.Get(c=>c.ProductId==id);
			await _productDal.Delete(deletedItem);
		}

        public async Task DeleteForCategoryId(int categoryId)
        {
            var products = await _productDal.GetList(p => p.CategoryId == categoryId);

            if (products.Any())
            {
                foreach (var product in products)
                {
                    await _productDal.Delete(product);
                } 
            }

        }

       

        public Task<List<Product>> GetAllByCategoryAsync(int categoryId)
		{
			return _productDal.GetList(p => p.CategoryId == categoryId || categoryId == 0);
		}

		public Task<List<Product>> GetAlLProductAsync()
		{
			return _productDal.GetList();
		}

		public async Task<Product> GetByIdAsync(int id)
		{
			return await _productDal.Get(p => p.ProductId == id);
		}
		 
        

        public async Task UpdateAsync(Product product)
		{
			await _productDal.Update(product);
		}
	}
}
