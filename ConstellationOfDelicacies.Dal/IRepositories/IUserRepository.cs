using ConstellationOfDelicacies.Dal.Dtos;

namespace ConstellationOfDelicacies.Dal.IRepositories;

public interface IUserRepository
{
    public List<UsersDto> GetAllUsers();

    public void AddUser(UsersDto user);

    public void DeleteUser(int id);

    public List<UsersDto> GetUsersBySpecialization(int spId);

    public List<UsersDto> GetUsersByProfile(int prId);

}