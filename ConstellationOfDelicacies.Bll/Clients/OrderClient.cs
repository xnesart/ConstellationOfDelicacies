using AutoMapper;
using ConstellationOfDelicacies.Bll.Mapping;
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
            OrdersDto ordersDto = _mapper.Map<OrdersDto>(order);
            _repository.AddOrder(ordersDto);
        }

        public void DeleteUserOrder(int orderId)
        {
            _repository.DeleteOrder(orderId);
        }

        public void UpdateUserOrder(OrderInputModel order)
        {
            OrdersDto ordersDto = _mapper.Map<OrdersDto>(order);
            _repository.UpdateOrder(ordersDto);
        }
    }
}
