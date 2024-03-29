using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;

namespace ConstellationOfDelicacies.Bll.Interfaces;

public interface IUserClient
{
    public void AddUser(UsersInputModel model);

    public void RemoveUser(int id);

    public void UpdateUser(UsersInputModel model);

    public void UpdateUserPassword(UsersInputModel model);

    public List<UsersOutputModel> GetAllUsers();

    public List<UsersOutputModel> GetAllChiefs();

    public List<UsersOutputModel> GetAllWaiters();

    public List<UsersOutputModel> GetUsersByProfile(int prId);

    public bool CheckLoginRights(LoginInputModel Model);

    public UsersOutputModel GetUserByMail(string mail);
}