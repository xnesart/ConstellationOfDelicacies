using ConstellationOfDelicacies.Bll;
using ConstellationOfDelicacies.Bll.Clients;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;
using ConstellationOfDelicacies.Dal;
using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.Repositories;
using System.Linq;

Context context = SingletoneStorage.GetStorage().Storage;

UserRepository user = new UserRepository();

UsersDto a = new UsersDto()
{
    Id = 2,
    Role = new RolesDto() { Title = "Worker" },
    FirstName = "Артем",
    LastName = "Иванов",
    Phone = "89991112233",
    Mail = "artem@cod.g",
    Profiles = new List<ProfilesDto>() { new ProfilesDto() { Id = 2 }, new ProfilesDto() { Id = 4 },
        new ProfilesDto() { Id = 3 } }
};

user.UpdateUser(a);

Console.WriteLine();
