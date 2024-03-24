using ConstellationOfDelicacies.Bll;
using ConstellationOfDelicacies.Bll.Clients;
using ConstellationOfDelicacies.Bll.Models.InputModels;
using ConstellationOfDelicacies.Dal;
using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.Repositories;
using System.Linq;

Context context = SingletoneStorage.GetStorage().Storage;

UserRepository userRepository = new UserRepository();
UserClient userClient = new UserClient();

//UsersDto usersDto = new UsersDto()
//{
//    Profiles = [context.Profiles.Where(pr => pr.Id == 2).Single(),
//        context.Profiles.Where(pr => pr.Id == 4).Single()],
//    Role = context.Roles.Where(r => r.Id == 2).Single(),
//    FirstName = "ARtem",
//    LastName = "Ahho",
//    Mail = "fchhd@hdh.fg"
//};

//userRepository.AddUser(usersDto);

UsersInputModel usersInputModel = new UsersInputModel()
{
    Profiles = [ new ProfilesInputModel() { Id = 5 } ],
    Role = new RolesInputModel() { Title = "Worker"},
    FirstName = "Софья",
    LastName = "Павлова",
    Mail = "df111@gf.f",
    Password = "khd1111b",
    Phone = "89991112233"
};
userClient.AddUser(usersInputModel);

context.SaveChanges();

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