using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ConstellationOfDelicacies.Dal.Repositories;

public class UserRepository:IUserRepository
{
    private readonly Context _storage;

    public UserRepository()
    {
        _storage = SingletoneStorage.GetStorage().Storage;
    }

    public UsersDto SetUserDto(UsersDto user)
    {
        user.Role = _storage.Roles.Where(r => r.Title == user.Role.Title).Single();
        if (user.Profiles != null)
        {
            foreach (var pr in user.Profiles.ToList())
            {
                user.Profiles.Add(_storage.Profiles.Where(p => p.Id == pr.Id).Single());
                user.Profiles.Remove(pr);
            }
        }

        return user;
    }

    public void AddUser(UsersDto user)
    {
        user = SetUserDto(user); 

        _storage.Users.Add(user);
        _storage.SaveChanges();
    }

    public void UpdateUser(UsersDto user)
    {
        user = SetUserDto(user);

        var storageUser = _storage.Users.Where(u => u.Id == user.Id).Include(u => u.Profiles).Single();

        if (storageUser != null)
        {
            storageUser.FirstName = user.FirstName;
            storageUser.LastName = user.LastName;
            storageUser.MiddleName = user.MiddleName;
            storageUser.Phone = user.Phone;
            storageUser.Mail = user.Mail;

            storageUser.Profiles.Clear();
            foreach (var p in user.Profiles)
            {
                storageUser.Profiles.Add(p);
            }

            _storage.Users.Update(storageUser);
            _storage.SaveChanges();
        }        
    }

    public void UpdateUserPassword(UsersDto user)
    {
        var storageUser = _storage.Users.Where(u => u.Id == user.Id).Single();

        if (storageUser != null)
        {
            storageUser.Password = user.Password;
            _storage.Users.Update(storageUser);
            _storage.SaveChanges();
        }
    }

    public void DeleteUser(int id)
    {
        var userToRemove = _storage.Users.FirstOrDefault(u => u.Id == id);
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