using ConstellationOfDelicacies.Dal.Dtos;

namespace ConstellationOfDelicacies.Dal.IRepositories;

public interface IUserRepository
{
    public List<UsersDto> GetAllUsers();

    public UsersDto GetUserById(int id);


    public void AddUser(UsersDto user);

    public void UpdateUser(UsersDto user);

    public void UpdateUserPassword(UsersDto user);

    public void DeleteUser(int id);

    public List<UsersDto> GetUsersBySpecialization(int spId);

    public List<UsersDto> GetUsersByProfile(int prId);

    public UsersDto GetUserByMail(string mail);

}