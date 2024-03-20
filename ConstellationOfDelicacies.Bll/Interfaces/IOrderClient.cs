using ConstellationOfDelicacies.Bll.Models.InputModels;


namespace ConstellationOfDelicacies.Bll.IOrderClient;

public interface IOrderClient
{
    public void AddUserOrder(OrderInputModel order);
}

