using ConstellationOfDelicacies.Dal.Dtos;

namespace ConstellationOfDelicacies.Dal.IRepositories;

public interface IUserRepository
{
    public List<UsersDto> GetAllUsers();

    public void AddUser(UsersDto user);

}