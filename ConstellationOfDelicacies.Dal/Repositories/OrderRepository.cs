using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstellationOfDelicacies.Dal.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _storage;

        public OrderRepository()
        {
            _storage = SingletoneStorage.GetStorage().Storage;
        }

        public void AddOrder(OrdersDto order)
        {
            _storage.Orders.Add(order);
            _storage.SaveChanges();
        }

        public void DeleteOrder(int orderId)
        {
            var order = _storage.Orders.Where(o => o.Id == orderId).Single();
            
            if (order != null)
            {
                order.IsDeleted = true;

                _storage.Orders.Update(order);
                _storage.SaveChanges();
            }
          
        }

        public void UpdateOrder(OrdersDto order)
        {
            var storageOrder = _storage.Orders.Where(o => o.Id == order.Id).Single();

            if (storageOrder != null)
            {
                storageOrder.Address = order.Address;
                storageOrder.OrderDate = order.OrderDate;
                storageOrder.NumberOfPersons = order.NumberOfPersons;
                storageOrder.Comment = order.Comment;
                storageOrder.TotalPrice = order.TotalPrice;

                _storage.Orders.Update(storageOrder);
                _storage.SaveChanges();
            }
        }
    }
}
