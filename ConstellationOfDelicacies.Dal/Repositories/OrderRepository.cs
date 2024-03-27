using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.IRepositories;

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
            var order = _storage.Orders.Where(o => o.Id == orderId).Single();
            return order;
        }

        public void AddOrder(OrdersDto order)
        {
            _storage.Orders.Add(order);
            _storage.SaveChanges();
        }

        public void DeleteOrder(int orderId)
        {
            var order = GetOrderById(orderId);
            
            if (order != null)
            {
                order.IsDeleted = true;

                _storage.Orders.Update(order);
                _storage.SaveChanges();
            }          
        }

        public void UpdateOrder(OrdersDto order)
        {
            var storageOrder = GetOrderById(order.Id);

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
            var orders = _storage.Orders.Where(o => o.Tasks.All(t => t.Title != "Менеджер"))
                .Where(o => o.IsDeleted == false).ToList();
            return orders;
        }

        public List<OrdersDto> GetAllManagerOrders(int managerId)
        {
            var orders = _storage.Orders
                .Where(o => o.Tasks!.Any(t => t.Title == "Менеджер" && t.Users!.Any(u => u.Id == managerId)))
                .ToList();
            return orders;
        }

        public List<OrdersDto> GetAllUsersOrders(int userId)
        {
            var orders = _storage.Orders
                .Where(o => o.Tasks!.Any(t => t.Title == "Пользователь" && t.Users!.Any(u => u.Id == userId)))
                .ToList();
            return orders;
        }
    }
}
