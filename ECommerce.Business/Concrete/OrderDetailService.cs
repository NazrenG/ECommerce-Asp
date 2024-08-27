using ECommerce.Business.Abstraction;
using ECommerce.DataAccess.Abstraction;
using ECommerce.DataAccess.Concrete.EFEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailDal orderDetailDal;

        public OrderDetailService(IOrderDetailDal orderDetailDal)
        {
            this.orderDetailDal = orderDetailDal;
        }

         

        public async Task DeleteForProductId(int id)
        {
            var orderDetails = await orderDetailDal.GetList(od => od.ProductId == id);
            foreach (var orderDetail in orderDetails)
            {
                await orderDetailDal.Delete(orderDetail);
            }
        }
    }
}
