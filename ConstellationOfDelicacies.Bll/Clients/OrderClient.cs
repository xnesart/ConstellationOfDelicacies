using AutoMapper;
using ConstellationOfDelicacies.Bll.Interfaces;
using ConstellationOfDelicacies.Bll.Mapping;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;
using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.IRepositories;
using ConstellationOfDelicacies.Dal.Repositories;

namespace ConstellationOfDelicacies.Bll.Clients
{
    public class OrderClient : IOrderClient
    {
        private readonly IOrderRepository _repository;
        private readonly ITaskClient _taskClient;
        private readonly IMapper _mapper;

        public OrderClient()
        {
            _repository = new OrderRepository();
            _taskClient = new TaskClient();
            IConfigurationProvider config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            _mapper = new Mapper(config);
        }

        public void AddUserOrder(OrderInputModel order)
        {
            var ordersDto = _mapper.Map<OrdersDto>(order);
            int orderId = _repository.AddOrder(ordersDto);

            var userTask = new TasksInputModel() 
            {
                Order = new OrderInputModel() { Id = orderId },
                Title = "Пользователь",
                Users = [new UsersInputModel() { Id = order.UserId}]
            };
            _taskClient.AddOrderTask(userTask);
        }

        public OrdersOutputModel GetOrderById(int orderId)
        {
            var order = _repository.GetOrderById(orderId);
            var result = _mapper.Map<OrdersOutputModel>(order);

            return result;
        }

        public void DeleteUserOrder(int orderId)
        {
            _repository.DeleteOrder(orderId);
        }

        public List<OrdersOutputModel> GetFreeOrders()
        {
            var orders = _repository.GetFreeOrders();
            var result = _mapper.Map<List<OrdersOutputModel>>(orders);
            return result;
        }

        public List<OrdersOutputModel> GetManagerOrders(int managerId)
        {
            var orders = _repository.GetAllManagerOrders(managerId);
            var result = _mapper.Map<List<OrdersOutputModel>>(orders);
            return result;
        }

        public List<OrdersOutputModel> GetUsersOrders(int userId)
        {
            var orders = _repository.GetAllUsersOrders(userId);
            var result = _mapper.Map<List<OrdersOutputModel>>(orders);
            return result;
        }

        public void UpdateUserOrder(OrderInputModel order)
        {
            var ordersDto = _mapper.Map<OrdersDto>(order);
            _repository.UpdateOrder(ordersDto);
        }
    }
}
