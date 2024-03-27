using AutoMapper;
using ConstellationOfDelicacies.Bll.Interfaces;
using ConstellationOfDelicacies.Bll.Mapping;
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

        public void AddOrderTask(TasksInputModel model)
        {
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
