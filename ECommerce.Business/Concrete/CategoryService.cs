using ECommerce.Business.Abstraction;
using ECommerce.DataAccess.Abstraction;
using ECommerce.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDal categoryDal;

        public CategoryService(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public async Task AddAsync(Category category)
        {
           await categoryDal.Add(category);
        }

        public async Task DeleteAsync(int id)
        {
            var item=await categoryDal.Get(p=>p.CategoryId==id);
            await categoryDal.Delete(item);
        }

        public async Task<List<Category>> GetAllCategoryAsync()
        {
           return await categoryDal.GetList();
        }
    }
}
