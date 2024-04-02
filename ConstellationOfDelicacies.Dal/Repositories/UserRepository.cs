using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.IRepositories;
using ConstellationOfDelicacies.Dal.Enums;
using Microsoft.EntityFrameworkCore;

namespace ConstellationOfDelicacies.Dal.Repositories;

public class UserRepository : IUserRepository
{
    private readonly Context _storage;
    private readonly IProfileRepository _profileRepository;
    private readonly IRoleRepository _roleRepository;

    public UserRepository()
    {
        _storage = SingletoneStorage.GetStorage().Storage;
        _profileRepository = new ProfileRepository();
        _roleRepository = new RoleRepository();
    }

    public void SetUserDto(UsersDto user)
    {
        user.Role = _roleRepository.GetRoleById(user.Role.Id);
        if (user.Profile != null)
        {
            user.Profile = _profileRepository.GetProfileById(user.Profile.Id);
        }
    }

    public UsersDto GetUserById(int id)
    {
        var user = _storage.Users.Where(u => u.Id == id).Include(u => u.Profile).Single();
        return user;
    }

    public void AddUser(UsersDto user)
    {
        SetUserDto(user); 

        _storage.Users.Add(user);
        _storage.SaveChanges();
    }

    public void UpdateUser(UsersDto user)
    {
        var storageUser = GetUserById(user.Id);

        if (storageUser != null)
        {
            storageUser.FirstName = user.FirstName;
            storageUser.LastName = user.LastName;
            storageUser.MiddleName = user.MiddleName;
            storageUser.Phone = user.Phone;
            
            _storage.Users.Update(storageUser);
            _storage.SaveChanges();
        }        
    }

    public void UpdateUserPassword(UsersDto user)
    {
        var storageUser = GetUserById(user.Id);

        if (storageUser != null)
        {
            storageUser.Password = user.Password;
            _storage.Users.Update(storageUser);
            _storage.SaveChanges();
        }
    }

    public void DeleteUser(int id)
    {
        var userToRemove = GetUserById(id);
        if (userToRemove != null)
        {
            userToRemove.IsDeleted = true;
            _storage.Users.Update(userToRemove);
            _storage.SaveChanges();
        }
    }

    public List<UsersDto> GetAllUsers()
    {
      var users = _storage.Users.Include(r => r.Role).ToList();

      foreach (var user in users)
      {
         Console.WriteLine(user.FirstName, user.Role.Title);
      }

      return users;
    }
    
    public List<UsersDto> GetUsersBySpecialization(int spId)
    {
        var users = _storage.Users
            .Where(u => u.Profile!.Specialization.Id == spId && u.IsDeleted == false)
            .ToList();
        return users;
    }

    public List<UsersDto> GetUsersByProfile(int prId)
    {
        List<UsersDto> users;
        if (_storage.Users != null)
        {
             users = _storage.Users.Where(u => u.Profile!.Id == prId)
                .Where(u => u.IsDeleted == false).ToList();
        }
        else
        {
             users = new List<UsersDto>();
        }

        return users;
    }

    public UsersDto GetUserByMail(string mail)
    {
        UsersDto user;
        if (_storage.Users != null)
        {
            user = _storage.Users.Where(u => u.Mail == mail && u.IsDeleted == false).SingleOrDefault();
        }
        else user = new UsersDto();

        return user;
    }

    public UsersDto GetOrderUser(int orderId)
    {
        var user = _storage.Users
            .Where(u => u.Tasks.Any(t => t.Title == Roles.User.ToString() && t.Order.Id == orderId)).Single();
        return user;
    }

    public UsersDto GetOrderManager(int orderId)
    {
        var user = _storage.Users
            .Where(u => u.Tasks.Any(t => t.Title == Roles.Manager.ToString() && t.Order.Id == orderId)).SingleOrDefault();

        return user;
    }
}