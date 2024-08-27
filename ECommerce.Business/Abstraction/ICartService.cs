using ECommerce.Entity.Concretes;
using ECommerce.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstraction
{
    public interface ICartService
    {
        public void AddList(Product product,Cart cart);
        public void DeleteList(Product product,Cart cart);
        public List<CartLine> GetList(Cart cart);
    }
}
