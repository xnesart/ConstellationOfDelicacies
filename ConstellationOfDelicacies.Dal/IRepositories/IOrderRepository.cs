using ConstellationOfDelicacies.Dal.Dtos;

namespace ConstellationOfDelicacies.Dal.IRepositories
{
    public interface IOrderRepository
    {
        public OrdersDto GetOrderById(int orderId);

        public void AddOrder(OrdersDto order);

        public void UpdateOrder(OrdersDto order);

        public void DeleteOrder(int orderId);

        public List<OrdersDto> GetFreeOrders();

        public List<OrdersDto> GetAllManagerOrders(int managerId);

        public List<OrdersDto> GetAllUsersOrders(int userId);
    }
}
