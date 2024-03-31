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
    public class TaskClient : ITaskClient
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public TaskClient()
        {
            _repository = new TaskRepository();
            IConfigurationProvider config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            _mapper = new Mapper(config);
        }

        public TasksOutputModel GetOrderTask(int taskId)
        {
            TasksDto orderTask = _repository.GetOrderTask(taskId);
            var result = _mapper.Map<TasksOutputModel>(orderTask);

            return result;
        }

        public List<TasksOutputModel> GetAllOrderTasks(int orderId)
        {
            List<TasksDto> tasks = _repository.GetAllOrderTasks(orderId);
            var result = _mapper.Map<List<TasksOutputModel>>(tasks);

            return result;
        }

        public void AddOrderTask(TasksInputModel model)
        {
            model.Status = new TaskStatusesInputModel() { Id = (int)TaskStatuses.Created };
            var tasksDto = _mapper.Map<TasksDto>(model);
            _repository.AddOrderTask(tasksDto);
        }

        public List<TasksOutputModel> GetAllWorkerTasks(int userId)
        {
            List<TasksDto> tasks = _repository.GetAllWorkerTasks(userId);
            var result = _mapper.Map<List<TasksOutputModel>>(tasks);
            
            return result;
        }

        public void UpdateTaskStatus(int id, int taskId)
        {
            TaskRepository taskRepository = new TaskRepository();
            taskRepository.UpdateTaskStatus(id,taskId);
        }

        public void AddTaskWorker(TasksInputModel model)
        {
            var taskDto = _mapper.Map<TasksDto>(model);
            _repository.AddTaskUser(taskDto);
        }

        public void DeleteTaskWorker(TasksInputModel model)
        {
            var taskDto = _mapper.Map<TasksDto>(model);
            _repository.DeleteTaskUser(taskDto);
        }

        public void DeleteOrderTask(int taskId)
        {
            _repository.DeleteOrderTask(taskId);
        }

        public void UpdateOrderTask(TasksInputModel model)
        {
            var tasksDto = _mapper.Map<TasksDto>(model);
            _repository.UpdateOrderTask(tasksDto);
        }

        public decimal GetOrderTaskPrice(TasksOutputModel model)
        {           
            decimal price = 0;

            foreach (var u in model.Users)
            {
                price += u.Profile!.Cost;
            }

            return price;
        }
    }
}
