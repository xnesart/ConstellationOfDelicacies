using ConstellationOfDelicacies.Bll;
using ConstellationOfDelicacies.Bll.Clients;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;
using ConstellationOfDelicacies.Dal;
using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.Repositories;
using System.Linq;

Context context = SingletoneStorage.GetStorage().Storage;

UserRepository userRepository = new UserRepository();
UserClient userClient = new UserClient();

List<UsersOutputModel> chiefs = userClient.GetAllChiefs();
List<UsersOutputModel> chiefs1 = userClient.GetUsersByProfile(3);

Console.WriteLine();

//UsersDto usersDto = new UsersDto()
//{
//    Profiles = [context.Profiles.Where(pr => pr.Id == 1).Single()],
//    Role = context.Roles.Where(r => r.Id == 2).Single(),
//    FirstName = "Павел",
//    LastName = "Браун",
//    Mail = "brown@hdh.fg",
//    Password = "1111"
//};

//userRepository.AddUser(usersDto);


//UsersInputModel usersInputModel = new UsersInputModel()
//{
//    Profiles = [new ProfilesInputModel() { Id = 5 }],
//    Role = new RolesInputModel() { Title = "Worker" },
//    FirstName = "QQQ",
//    LastName = "WWW",
//    Mail = "qqq@gf.f",
//    Password = "qqqwww"
//};
//userClient.AddUser(usersInputModel);

//context.SaveChanges();

//context.Roles.Add(new RolesDto() { Title = "Manager" } );
//context.Roles.Add(new RolesDto() { Title = "Worker" });
//context.Roles.Add(new RolesDto() { Title = "User" });

//context.Specializations.Add(new SpecializationsDto() { Title = "Повар" });
//context.Specializations.Add(new SpecializationsDto() { Title = "Официант" });

//context.Profiles.Add(new ProfilesDto()
//{
//    Specialization = context.Specializations.Where(sp => sp.Id == 1).Single(),
//    Title = "Повар кондитер"
//});

//context.Profiles.Add(new ProfilesDto()
//{
//    Specialization = context.Specializations.Where(sp => sp.Id == 1).Single(),
//    Title = "Повар холодного цеха"
//});

//context.Profiles.Add(new ProfilesDto()
//{
//    Specialization = context.Specializations.Where(sp => sp.Id == 1).Single(),
//    Title = "Повар горячего цеха"
//});

//context.Profiles.Add(new ProfilesDto()
//{
//    Specialization = context.Specializations.Where(sp => sp.Id == 1).Single(),
//    Title = "Повар сушист"
//});

//context.Profiles.Add(new ProfilesDto()
//{
//    Specialization = context.Specializations.Where(sp => sp.Id == 2).Single(),
//    Title = "Официант стажер"
//});

//context.Profiles.Add(new ProfilesDto()
//{
//    Specialization = context.Specializations.Where(sp => sp.Id == 2).Single(),
//    Title = "Официант 2-ого разряда"
//});

//context.Profiles.Add(new ProfilesDto()
//{
//    Specialization = context.Specializations.Where(sp => sp.Id == 2).Single(),
//    Title = "Официант 3-ого разряда"
//});

//context.Profiles.Add(new ProfilesDto()
//{
//    Specialization = context.Specializations.Where(sp => sp.Id == 2).Single(),
//    Title = "Официант 4-ого разряда"
//});

//context.Profiles.Add(new ProfilesDto()
//{
//    Specialization = context.Specializations.Where(sp => sp.Id == 2).Single(),
//    Title = "Официант 5-ого разряда"
//});

//context.SaveChanges();