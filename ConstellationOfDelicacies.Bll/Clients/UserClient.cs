using AutoMapper;
using ConstellationOfDelicacies.Bll.IManager;
using ConstellationOfDelicacies.Bll.Mapping;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;
using ConstellationOfDelicacies.Dal;
using ConstellationOfDelicacies.Dal.Dtos;

namespace ConstellationOfDelicacies.Bll.Clients;

public class UserClient : IUserClient
{
    private readonly SingletoneStorage _storage;
    private readonly IMapper _mapper;

    public UserClient()
    {
        _storage = SingletoneStorage.GetStorage();
        IConfigurationProvider config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
        _mapper = new Mapper(config);
    }

    public void AddUser(UsersInputModel model)
    {
        var dto = _mapper.Map<UsersDto>(model);
        _storage.Storage.Users.Add(dto);
        _storage.Storage.SaveChanges();
    }

    public void RemoveUser(int id)
    {
        //var users = GetAllUsers();
        var userToRemove = _storage.Storage.Users.FirstOrDefault(u => u.Id == id);
        if (userToRemove != null)
        {
            _storage.Storage.Users.Remove(userToRemove);
            _storage.Storage.SaveChanges();
        }
    }

    public void UpdateUser(UsersInputModel model)
    {
        throw new NotImplementedException();
    }

    public List<UsersOutputModel> GetAllUsers()
    {
        var users = _storage.Storage.Users.ToList();
        var usersOutput = _mapper.Map<List<UsersOutputModel>>(users);

        return usersOutput;
    }
}