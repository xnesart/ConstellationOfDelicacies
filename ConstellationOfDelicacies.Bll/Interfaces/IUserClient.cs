using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;

namespace ConstellationOfDelicacies.Bll.IManager;

public interface IUserClient
{
    public void AddUser(UsersInputModel model);
    public void RemoveUser(int id);
    public void UpdateUser(UsersInputModel model);
    public List<UsersOutputModel> GetAllUsers();
}