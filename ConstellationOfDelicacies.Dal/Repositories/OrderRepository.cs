using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ConstellationOfDelicacies.Dal.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _storage;

        public OrderRepository()
        {
            _storage = SingletoneStorage.GetStorage().Storage;
        }

        public OrdersDto GetOrderById(int orderId)
        {
            OrdersDto order = _storage.Orders.Where(o => o.Id == orderId)
                .Include(o => o.Tasks).ThenInclude(t => t.Users).Single();
            return order;
        }

        public int AddOrder(OrdersDto order)
        {
            _storage.Orders.Add(order);
            _storage.SaveChanges();
            return order.Id;
        }

        public void DeleteOrder(int orderId)
        {
            OrdersDto order = GetOrderById(orderId);
            
            if (order != null)
            {
                order.IsDeleted = true;

                _storage.Orders.Update(order);
                _storage.SaveChanges();
            }          
        }

        public void UpdateOrder(OrdersDto order)
        {
            OrdersDto storageOrder = GetOrderById(order.Id);

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

        public List<OrdersDto> GetFreeOrders()
        {
            var orders = _storage.Orders
                .Where(o => o.Tasks.All(t => t.Title != "Менеджер") && !o.IsDeleted)
                .Include(o => o.Tasks).ThenInclude(t => t.Users).ToList();
            return orders;
        }

        public List<OrdersDto> GetAllManagerOrders(int managerId)
        {
            var orders = _storage.Orders
                .Where(o => o.Tasks!.Any(t => t.Title == "Менеджер" && t.Users!.Any(u => u.Id == managerId)))
                .Include(o => o.Tasks).ThenInclude(t => t.Users).ToList();
            return orders;
        }

        public List<OrdersDto> GetAllUsersOrders(int userId)
        {
            var orders = _storage.Orders
                .Where(o => o.Tasks!.Any(t => t.Title == "Пользователь" && t.Users!.Any(u => u.Id == userId)))
                .Include(o => o.Tasks).ThenInclude(t => t.Users).ToList();
            return orders;
        }

        public void UpdateOrderPrice(decimal price, int orderId)
        {
            var order = _storage.Orders.Where(o => o.Id == orderId).Single();
            order.TotalPrice = price;

            _storage.Orders.Update(order);
            _storage.SaveChanges();
        }
    }
}
