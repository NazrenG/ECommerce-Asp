using ECommerce.Core.DataAccess.EntityFramework;
using ECommerce.DataAccess.Abstraction;
using ECommerce.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.EFEntityFramework
{
	public class EFProductDal : EFEntityRepositoryBase<Product, NorthwindContext>, IProductDal
	{
        private readonly NorthwindContext _northwindContext;
		public EFProductDal(NorthwindContext context) : base(context)
		{
            _northwindContext = context;
		}

       
    }
}
