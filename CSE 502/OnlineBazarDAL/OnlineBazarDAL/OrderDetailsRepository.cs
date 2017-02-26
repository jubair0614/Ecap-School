using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBazarDAL
{
    class OrderDetailsRepository
    {
        OnlineBazarEntities onlineBazarEntities = null;

        public OrderDetailsRepository()
        {
            onlineBazarEntities = new OnlineBazarEntities();
        }

        public bool AddOrderDetails(OrderDetail orderDetail)
        {
            onlineBazarEntities.OrderDetails.Add(orderDetail);
            return onlineBazarEntities.SaveChanges() > 0;
        }

        public bool EditOrderDetails(OrderDetail orderDetail)
        {
            onlineBazarEntities.OrderDetails.Attach(orderDetail);
            onlineBazarEntities.Entry(orderDetail).State = System.Data.Entity.EntityState.Modified;
            return onlineBazarEntities.SaveChanges() > 0;
        }

        public bool DeleteOrderDetails(OrderDetail orderDetail)
        {
            onlineBazarEntities.OrderDetails.Attach(orderDetail);
            onlineBazarEntities.Entry(orderDetail).State = System.Data.Entity.EntityState.Deleted;
            return onlineBazarEntities.SaveChanges() > 0;
        }

        public List<OrderDetail> GetOrderDetail()
        {
            return onlineBazarEntities.OrderDetails.ToList();
        }

        public OrderDetail GetOrderDetail(int orderDetailId)
        {
            return onlineBazarEntities.OrderDetails.FirstOrDefault(o => o.Id == orderDetailId);
        }
    }
}
