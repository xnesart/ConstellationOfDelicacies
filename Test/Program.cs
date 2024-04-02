using ConstellationOfDelicacies.Bll;
using ConstellationOfDelicacies.Bll.Clients;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;
using ConstellationOfDelicacies.Dal;
using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.Repositories;
using ConstellationOfDelicacies.Bll.Enums;
using System.Linq;

OrderClient client = new OrderClient();

var a = client.GetManagerOrders(19);

Console.WriteLine();

//UsersDto userDto = new UsersDto()
//{
//    Role = new RolesDto() { Id = 1 },
//    FirstName = "Менеджер",
//    MiddleName = "Очень",
//    LastName = "Новичок",
//    Phone = "85555555511",
//    Mail = "manager2@cod.com",
//    Password = "qqq"
//};

//userRepository.AddUser(userDto);

//TasksInputModel model = new TasksInputModel()
//{
//    Id = 7, 
//    Profiles = [new ProfilesInputModel() { Id = 2}],
//    Users = [new UsersInputModel() { Id = 12} ]
//};

//taskClient.AddTaskWorker(model);

//Console.WriteLine();

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

