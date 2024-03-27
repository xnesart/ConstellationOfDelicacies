using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ConstellationOfDelicacies.Dal.Repositories;

public class UserRepository:IUserRepository
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

    public UsersDto SetUserDto(UsersDto user)
    {
        user.Role = _roleRepository.GetRoleByTitle(user.Role.Title);
        if (user.Profiles != null)
        {
            foreach (var pr in user.Profiles.ToList())
            {
                user.Profiles.Add(_profileRepository.GetProfileById(pr.Id));
                user.Profiles.Remove(pr);
            }
        }

        return user;
    }

    public UsersDto GetUserById(int id)
    {
        var user = _storage.Users.Where(u => u.Id == id).Include(u => u.Profiles).Single();
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

        var storageUser = GetUserById(user.Id);

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
            .Where(u => u.Profiles.Any(p => p.Specialization.Id == spId) && u.IsDeleted == false)
            .ToList();
        return users;
    }

    public List<UsersDto> GetUsersByProfile(int prId)
    {
        List<UsersDto> users;
        if (_storage.Users != null)
        {
             users = _storage.Users.Where(u => u.Profiles.Any(p => p.Id == prId))
                .Where(u => u.IsDeleted == false).ToList();
        }
        else
        {
             users = new List<UsersDto>();
        }
        return users;
    }
}