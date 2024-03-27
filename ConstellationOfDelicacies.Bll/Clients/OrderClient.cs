using AutoMapper;
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
        private readonly IMapper _mapper;

        public OrderClient()
        {
            _repository = new OrderRepository();
            IConfigurationProvider config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            _mapper = new Mapper(config);
        }

        public void AddUserOrder(OrderInputModel order)
        {
            var ordersDto = _mapper.Map<OrdersDto>(order);
            _repository.AddOrder(ordersDto);
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
