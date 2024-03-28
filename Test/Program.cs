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

OrderRepository orderRepository = new OrderRepository();

var a = orderClient.GetFreeOrders();

var b = a[0].Tasks.Where(t => t.Title == "Пользователь").Single().Users.First();

string clientName = $"{b.FirstName} {b.LastName}";

Console.WriteLine();

//OrderInputModel o = new OrderInputModel()
//{
//    OrderDate = DateTime.Now,
//    UserId = 16,
//    Comment = "111",
//    Address = "222",
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

//UsersInputModel usersDto2 = new UsersInputModel()
//{
//    Role = new RolesInputModel() { Title = "Пользователь" },
//    FirstName = "BBB",
//    LastName = "bbb",
//    Mail = "bbb@cod.g",
//    Phone = "89992223344",
//    Password = "1111"
//};

//userClient.AddUser(usersDto2);

