using ConstellationOfDelicacies.Bll.Models;


namespace ConstellationOfDelicacies.Bll.IUser;

public interface IUser
{
    public void AddUserOrder(OrderInputModel order);
}

