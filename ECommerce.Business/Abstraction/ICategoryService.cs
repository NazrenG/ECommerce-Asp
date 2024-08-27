using ECommerce.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstraction
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoryAsync();
        Task AddAsync(Category category); 
        Task DeleteAsync(int id);
    }
}
