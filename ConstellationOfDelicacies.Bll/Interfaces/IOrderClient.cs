using ConstellationOfDelicacies.Bll.Models.InputModels;


namespace ConstellationOfDelicacies.Bll.Clients;

public interface IOrderClient
{
    public void AddUserOrder(OrderInputModel order);

    public void UpdateUserOrder(OrderInputModel order);

    public void DeleteUserOrder(int orderId);
}

