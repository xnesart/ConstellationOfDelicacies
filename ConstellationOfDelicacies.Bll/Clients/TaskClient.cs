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

        public async Task<List<TasksOutputModel>> GetOrderTasks(int orderId)
        {
            List<TasksDto> tasks = await _repository.GetOrderTasks(orderId);
            var result = _mapper.Map<List<TasksOutputModel>>(tasks);

            return result;
        }

        public void AddOrderTask(TasksInputModel model)
        {
            model.Status = new TaskStatusesInputModel() { Id = (int)TaskStatuses.Created };
            var tasksDto = _mapper.Map<TasksDto>(model);
            _repository.AddOrderTask(tasksDto);
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
    }
}
