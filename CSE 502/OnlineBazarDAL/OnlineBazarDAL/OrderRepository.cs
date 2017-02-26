using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBazarDAL
{
    class OrderRepository
    {
        OnlineBazarEntities onlineBazarEntites = null;

        public OrderRepository()
        {
            onlineBazarEntites = new OnlineBazarEntities();
        }

        public bool AddOrder(Order order)
        {
            onlineBazarEntites.Orders.Add(order);
            return onlineBazarEntites.SaveChanges() > 0;
        }

        public bool EditOrder(Order order)
        {
            onlineBazarEntites.Orders.Attach(order);
            onlineBazarEntites.Entry(order).State = System.Data.Entity.EntityState.Modified;
            return onlineBazarEntites.SaveChanges() > 0;
        }

        public bool DeleteOrder(Order order)
        {
            onlineBazarEntites.Orders.Attach(order);
            onlineBazarEntites.Entry(order).State = System.Data.Entity.EntityState.Deleted;
            return onlineBazarEntites.SaveChanges() > 0;
        }

        public List<Order> GetOrderList()
        {
            return onlineBazarEntites.Orders.ToList();
        }

        public Order GetOrderById(int orderId)
        {
            return onlineBazarEntites.Orders.FirstOrDefault(o => o.Id == orderId);
        }
    }
}
