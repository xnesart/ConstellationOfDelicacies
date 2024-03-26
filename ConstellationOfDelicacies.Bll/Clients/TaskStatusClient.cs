using AutoMapper;
using ConstellationOfDelicacies.Bll.IManager;
using ConstellationOfDelicacies.Bll.Mapping;
using ConstellationOfDelicacies.Bll.Models.InputModels;
using ConstellationOfDelicacies.Dal;
using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.IRepositories;
using ConstellationOfDelicacies.Dal.Repositories;

namespace ConstellationOfDelicacies.Bll.Clients;

public class TaskStatusClient : ITaskStatusClient
{
    private readonly IMapper _mapper;
    private readonly ITaskStatusRepository _repository;
    
    public TaskStatusClient()
    {
        _repository = new TaskStatusRepository();
        IConfigurationProvider config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
        _mapper = new Mapper(config);
    }
    public void UpdateStatus(TaskStatusesInputModel statusTasks)
    {
        var taskStatusesDto = _mapper.Map<TaskStatusesDto>(statusTasks);
    }

}