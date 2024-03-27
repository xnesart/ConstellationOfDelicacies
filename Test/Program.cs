using ConstellationOfDelicacies.Bll;
using ConstellationOfDelicacies.Bll.Clients;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;
using ConstellationOfDelicacies.Dal;
using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.Repositories;
using System.Linq;

Context context = SingletoneStorage.GetStorage().Storage;

TaskClient taskClient = new TaskClient();
OrderClient orderClient = new OrderClient();
UserClient userClient = new UserClient();

//OrderInputModel o = new OrderInputModel()
//{
//    OrderDate = DateTime.Now,
//    Comment = "kvkhb",
//    Address = "cvbnm,",
//    NumberOfPersons = 1,
//};

//orderClient.AddUserOrder(o);


//TasksInputModel a = new TasksInputModel()
//{
//    Order = new OrderInputModel() { Id = 1 },
//    Title = "Пользователь",
//    Users = [new UsersInputModel { Id = 2 }],
//    Status = new TaskStatusesInputModel() { Id = 1 }
//};

//taskClient.AddOrderTask(a);

UsersInputModel usersDto2 = new UsersInputModel()
{
    Profiles = [ new ProfilesInputModel() { Id = 2 },
        new ProfilesInputModel() { Id = 4 }],
    Role = new RolesInputModel() { Title = "Сотрудник" },
    FirstName = "Артем",
    LastName = "Артемович",
    Mail = "artem@cod.g",
    Password = "1111"
};

userClient.AddUser(usersDto2);

Console.WriteLine();
