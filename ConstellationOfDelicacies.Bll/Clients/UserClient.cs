using AutoMapper;
using ConstellationOfDelicacies.Bll.IManager;
using ConstellationOfDelicacies.Bll.Mapping;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;
using ConstellationOfDelicacies.Dal;
using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.IRepositories;
using ConstellationOfDelicacies.Dal.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ConstellationOfDelicacies.Bll.Clients;

public class UserClient : IUserClient
{
    private readonly Context _storage;
    private readonly IMapper _mapper;
    private UserRepository _userRepository;

    public UserClient()
    {
        _userRepository = new UserRepository();
        _storage = SingletoneStorage.GetStorage().Storage;
        IConfigurationProvider config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
        _mapper = new Mapper(config);
    }

    public void AddUser(UsersInputModel model)
    {
        UsersDto userModel = _mapper.Map<UsersDto>(model);
        userModel.IsDeleted = false;
        foreach (ProfilesDto pr in userModel.Profiles.ToList())
        {
            userModel.Profiles.Add(_storage.Profiles.Where(p => p.Id == pr.Id).Single());
            userModel.Profiles.Remove(pr);
        }
        _userRepository.AddUser(userModel);

        //using (var context = new Context())
        //{
        //    //var role = context.Roles.Where(r => r.Title == model.Role.Title).Single();
        //    var dto = _mapper.Map<UsersDto>(model);
        //    //dto.Role = role;
        //    context.Users.Add(dto);
        //    context.SaveChanges();
        //}
    }

    public void RemoveUser(int id)
    {
        //var users = GetAllUsers();
        //тест
        UserRepository repository = new UserRepository();
        repository.GetAllUsers();

        var userToRemove = _storage.Users.FirstOrDefault(u => u.Id == id);
        if (userToRemove != null)
        {
            _storage.Users.Remove(userToRemove);
            _storage.SaveChanges();
        }
    }

    public void UpdateUser(UsersInputModel model)
    {
        throw new NotImplementedException();
    }

    public List<UsersOutputModel> GetAllUsers()
    {
        var users = _storage.Users.ToList();
        var usersOutput = _mapper.Map<List<UsersOutputModel>>(users);

        return usersOutput;
    }

    public List<UsersOutputModel> GetAllChiefs()
    {
        List<UsersOutputModel> result = new List<UsersOutputModel>();
        var users = _storage.Users.Include(u => u.Role).ToList();
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

    public List<UsersOutputModel> GetAllChiefsByProfiles()
    {
        // List<UsersOutputModel> result = new List<UsersOutputModel>();
        // var r = _storage.Storage.Users.Include(u => u.Profiles).ToList();

        var users = _storage.Users
            .Include(u => u.Profiles)
            .Where(u => u.Profiles.Any(p => p.Specialization.Id == 1))
            .ToList();
        List<UsersOutputModel> usersModels = _mapper.Map<List<UsersOutputModel>>(users);

        // List<ProfilesDto> profiles = _storage.Storage.Profiles.Where(p=>p.Id == 1).Include(u => u.Users).ToList();
        // List<ProfilesDto> profiles = _storage.Storage.Profiles.Include(u => u.Users).ToList();
        // foreach (var profile in profiles)
        // {
        //     var user = profile.Users.SingleOrDefault();
        //     var tmp =_mapper.Map<UsersOutputModel>(user);
        //     result.Add(tmp);
        // }


        return usersModels;
    }

    public UsersOutputModel GetUserByEmail(string mail)
    {
        var users = _storage.Users.ToList();
        var usersOutput = _mapper.Map<List<UsersOutputModel>>(users).ToList();
        var user = usersOutput.Where(u => u.Mail == mail).Single();

        return user;
    }
}