using ECommerce.Core.DataAccess.EntityFramework;
using ECommerce.DataAccess.Abstraction;
using ECommerce.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.EFEntityFramework
{
    public class EFOrderDetailDal : EFEntityRepositoryBase<OrderDetail, NorthwindContext>, IOrderDetailDal
    {
        public EFOrderDetailDal(NorthwindContext context) : base(context)
        {
        }
    }
}
