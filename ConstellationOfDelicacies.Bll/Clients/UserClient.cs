using AutoMapper;
using ConstellationOfDelicacies.Bll.IManager;
using ConstellationOfDelicacies.Bll.Mapping;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;
using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.Repositories;

namespace ConstellationOfDelicacies.Bll.Clients;

public class UserClient : IUserClient
{
    private readonly IMapper _mapper;
    private UserRepository _repository;

    private int _spChief = 1;
    private int _spWaiter = 2;

    public UserClient()
    {
        _repository = new UserRepository();
        IConfigurationProvider config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
        _mapper = new Mapper(config);
    }

    public void AddUser(UsersInputModel model)
    {
        UsersDto userModel = _mapper.Map<UsersDto>(model);
        
        _repository.AddUser(userModel);
    }

    public void RemoveUser(int id)
    {
        _repository.DeleteUser(id);
    }

    public void UpdateUser(UsersInputModel model)
    {
        UsersDto userModel = _mapper.Map<UsersDto>(model);

        _repository.UpdateUser(userModel);
    }

    public void UpdateUserPassword(UsersInputModel model)
    {
        UsersDto userModel = _mapper.Map<UsersDto>(model);

        _repository.UpdateUserPassword(userModel);
    }

    public List<UsersOutputModel> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public List<UsersOutputModel> GetAllChiefs()
    {
        List<UsersDto> chiefs = _repository.GetUsersBySpecialization(_spChief);
        var result = _mapper.Map<List<UsersOutputModel>>(chiefs);

        return result;
    }

    public List<UsersOutputModel> GetAllWaiters()
    {
        List<UsersDto> waiters = _repository.GetUsersBySpecialization(_spWaiter);
        var result = _mapper.Map<List<UsersOutputModel>>(waiters);

        return result;
    }

    public UsersOutputModel GetUserByEmail(string mail)
    {
        throw new NotImplementedException();
    }

    public List<UsersOutputModel> GetUsersByProfile(int prId)
    {
        List<UsersDto> users = _repository.GetUsersByProfile(prId);
        var result = _mapper.Map<List<UsersOutputModel>>(users);

        return result;
    }
}