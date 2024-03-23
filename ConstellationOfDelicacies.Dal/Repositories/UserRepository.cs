using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.IRepositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ConstellationOfDelicacies.Dal.Repositories;

public class UserRepository:IUserRepository
{
   public List<UsersDto> GetAllUsers()
   {
      var users = SingletoneStorage.GetStorage().Storage.Users.Include(r => r.Role).ToList();

      foreach (var user in users)
      {
         Console.WriteLine(user.FirstName, user.Role.Title);

      }

      return users;
   }
}