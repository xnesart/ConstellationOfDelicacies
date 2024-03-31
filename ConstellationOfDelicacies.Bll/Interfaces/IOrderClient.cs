using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;


namespace ConstellationOfDelicacies.Bll.Clients;

public interface IOrderClient
{
    public void AddUserOrder(OrderInputModel order);

    public void AddManagerToOrder(OrderInputModel order);

    public OrdersOutputModel GetOrderById(int orderId);

    public void UpdateUserOrder(OrderInputModel order);

    public void DeleteUserOrder(int orderId);

    public List<OrdersOutputModel> GetFreeOrders();

    public List<OrdersOutputModel> GetManagerOrders(int managerId);

    public List<OrdersOutputModel> GetUsersOrders(int userId);

    public void UpdateOrderPrice(int orderId);
}

