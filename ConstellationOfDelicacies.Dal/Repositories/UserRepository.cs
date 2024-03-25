using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ConstellationOfDelicacies.Dal.Repositories;

public class UserRepository:IUserRepository
{
    private Context _storage;

    public UserRepository()
    {
        _storage = SingletoneStorage.GetStorage().Storage;
    }

    public void AddUser(UsersDto user)
    {
        user.Role = _storage.Roles.Where(r => r.Title == user.Role.Title).Single();
        if (user.Profiles is not null)
        {
            foreach (ProfilesDto pr in user.Profiles.ToList())
            {
                user.Profiles.Add(_storage.Profiles.Where(p => p.Id == pr.Id).Single());
                user.Profiles.Remove(pr);
            }
        }

        _storage.Users.Add(user);
        _storage.SaveChanges();
    }

    public void DeleteUser(int id)
    {
        var userToRemove = _storage.Users.FirstOrDefault(u => u.Id == id);
        if (userToRemove != null)
        {
            userToRemove.IsDeleted = true;
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
        var users = _storage.Users.Where(u => u.Profiles.Any(p => p.Specialization.Id == spId)).ToList();
        return users;
    }

    public List<UsersDto> GetUsersByProfile(int prId)
    {
        List<UsersDto> users;
        if (_storage.Users != null)
        {
             users = _storage.Users.Where(u => u.Profiles.Any(p => p.Id == prId)).ToList();
        }
        else
        {
             users = new List<UsersDto>();
        }
        return users;
    }
}