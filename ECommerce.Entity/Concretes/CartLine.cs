using ECommerce.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Concretes
{
    public class CartLine
    {
        public Product? Product { get; set; }
        public int Quantity  { get; set; }
    }
}
