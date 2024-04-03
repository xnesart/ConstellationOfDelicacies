using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;
using ConstellationOfDelicacies.Bll.Models.OutputModels;

namespace ConstellationOfDelicacies.Bll.Interfaces;

public interface IUserClient
{
    public void AddUser(UsersInputModel model);

    public void RemoveUser(int id);

    public void UpdateUser(UsersInputModel model);
    public void UpdateUserWithEmail(UsersInputModel model);

    public void UpdateUserPassword(UsersInputModel model);

    public List<UsersOutputModel> GetAllUsers();

    public List<UsersOutputModel> GetAllChiefs();

    public List<UsersOutputModel> GetAllWaiters();

    public List<UsersOutputModel> GetUsersByProfile(int prId);

    public bool CheckLoginRights(LoginInputModel model);

    public LoginOutputModel GetUserByMail(string mail);

    public UsersOutputModel GetOrderUser(int orderId);

    public UsersOutputModel GetOrderManager(int orderId);

}