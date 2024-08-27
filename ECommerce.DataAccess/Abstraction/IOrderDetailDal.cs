using ECommerce.Core.DataAccess;
using ECommerce.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstraction
{
    public interface IOrderDetailDal:IEntityRepository<OrderDetail>
    {
    }
}
