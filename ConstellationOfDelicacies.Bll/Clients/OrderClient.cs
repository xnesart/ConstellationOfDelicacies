using AutoMapper;
using ConstellationOfDelicacies.Bll.Enums;
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
                Title = Roles.User.ToString(),
                Users = [new UsersInputModel() { Id = order.UserId}]
            };
            _taskClient.AddOrderTask(userTask);
        }

        public void AddManagerToOrder(OrderInputModel order)
        {
            var managerTask = new TasksInputModel()
            {
                Order = new OrderInputModel() { Id = order.Id },
                Title = Roles.Manager.ToString(),
                Users = [new UsersInputModel() { Id = order.UserId }]
            };

            _taskClient.AddOrderTask(managerTask);
        }

        public OrdersOutputModel GetOrderById(int orderId)
        {
            OrdersDto order = _repository.GetOrderById(orderId);

            if (order == null)
            {
                order = new OrdersDto();
            }
            var result = _mapper.Map<OrdersOutputModel>(order);
            GetOrderStatus(result);

            return result;
        }

        public void DeleteUserOrder(int orderId)
        {
            _repository.DeleteOrder(orderId);
            var orderTasks = _taskClient.GetAllOrderTasks(orderId);

            foreach (var t in orderTasks)
            {
                _taskClient.DeleteOrderTask(t.Id);
            }
        }

        public void CompleteUserOrder(int orderId)
        {
            _repository.CompleteOrder(orderId);
            var orderTasks = _taskClient.GetAllOrderTasks(orderId);

            foreach(var t in orderTasks)
            {
                _taskClient.CompleteOrderTask(t.Id);
            }
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

            foreach (var r in result)
            {
                GetOrderStatus(r);
            }

            return result;
        }

        public List<OrdersOutputModel> GetUsersOrders(int userId)
        {
            var orders = _repository.GetAllUsersOrders(userId);
            var result = _mapper.Map<List<OrdersOutputModel>>(orders);

            foreach (var r in result)
            {
                GetOrderStatus(r);
            }

            return result;
        }

        private void GetOrderStatus(OrdersOutputModel model)
        {
            if (model.IsDeleted)
            {
                model.Status = OrderStatuses.Deleted;
            }
            else if (model.IsCompleted)
            {
                model.Status = OrderStatuses.Completed;
            }
            else if (model.Tasks.Any(t => t.Title == Roles.Manager.ToString()))
            {
                model.Status = OrderStatuses.InProgress;
            }
            else
            {
                model.Status = OrderStatuses.Created;
            }
        }

        public void UpdateUserOrder(OrderInputModel order)
        {
            var ordersDto = _mapper.Map<OrdersDto>(order);
            _repository.UpdateOrder(ordersDto);
        }

        public void UpdateOrderPrice(int orderId)
        {
            ITaskClient taskClient = new TaskClient();
            List<TasksOutputModel> orderTasks = taskClient.GetAllOrderTasks(orderId);

            decimal price = 0;

            foreach(var t in orderTasks)
            {
                price += taskClient.GetOrderTaskPrice(t);
            }

            _repository.UpdateOrderPrice(price, orderId);
        }
    }
}
