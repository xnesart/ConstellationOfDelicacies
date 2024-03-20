using AutoMapper;
using ConstellationOfDelicacies.Bll.IManager;
using ConstellationOfDelicacies.Bll.Mapping;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;
using ConstellationOfDelicacies.Dal;
using ConstellationOfDelicacies.Dal.Dtos;
using Microsoft.EntityFrameworkCore;

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
        using (var context = new Context())
        {
            var dto = _mapper.Map<UsersDto>(model);
            context.Users.Add(dto);
            context.SaveChanges();
        }
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

    public List<UsersOutputModel> GetAllChiefs()
    {
        List<UsersOutputModel> result = new List<UsersOutputModel>();
        var users = _storage.Storage.Users.Include(u=>u.Role).ToList();
        List<UsersOutputModel> usersModels = _mapper.Map<List<UsersOutputModel>>(users);
        if (usersModels != null)
        {
            foreach (var user in usersModels)
            {
                if (user.Role != null && (user.Role.Title == "Повар" || user.Role.Title == "Повар кондитер" ||
                                          user.Role.Title == "Повар холодного цеха" ||
                                          user.Role.Title == "Повар горячего цеха" ||
                                          user.Role.Title == "Су-шеф" || user.Role.Title == "Шеф повар"))
                {
                    result.Add(user);
                }
            }
        }


        return result;
    }
}