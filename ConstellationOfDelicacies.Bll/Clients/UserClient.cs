using AutoMapper;
using ConstellationOfDelicacies.Bll.Enums;
using ConstellationOfDelicacies.Bll.Interfaces;
using ConstellationOfDelicacies.Bll.Mapping;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;
using ConstellationOfDelicacies.Bll.Models.OutputModels;
using ConstellationOfDelicacies.Dal;
using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ConstellationOfDelicacies.Bll.Clients;

public class UserClient : IUserClient
{
    private readonly IMapper _mapper;
    private UserRepository _repository;

    public UserClient()
    {
        _repository = new UserRepository();
        IConfigurationProvider config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
        _mapper = new Mapper(config);
    }

    public void AddUser(UsersInputModel model)
    {
        var usersDTo = _mapper.Map<UsersDto>(model);
        
        _repository.AddUser(usersDTo);
    }

    public void RemoveUser(int id)
    {
        _repository.DeleteUser(id);
    }

    public void UpdateUser(UsersInputModel model)
    {
        var usersDto = _mapper.Map<UsersDto>(model);

        _repository.UpdateUser(usersDto);
    }
    public void UpdateUserWithEmail(UsersInputModel model)
    {
        var usersDto = _mapper.Map<UsersDto>(model);

        _repository.UpdateUserWithEmail(usersDto);
    }

    public void UpdateUserPassword(UsersInputModel model)
    {
        var usersDto = _mapper.Map<UsersDto>(model);

        _repository.UpdateUserPassword(usersDto);
    }

    public List<UsersOutputModel> GetAllUsers()
    {
        var users = SingletoneStorage.GetStorage().Storage.Users.Include(u => u.Role).ToList();
        var res = _mapper.Map<List<UsersOutputModel>>(users);
        return res;
    }

    public List<UsersOutputModel> GetAllChiefs()
    {
        List<UsersDto> chiefs = _repository.GetUsersBySpecialization((int)Specializations.Chief);
        var result = _mapper.Map<List<UsersOutputModel>>(chiefs);

        return result;
    }

    public List<UsersOutputModel> GetAllWaiters()
    {
        List<UsersDto> waiters = _repository.GetUsersBySpecialization((int)Specializations.Waiter);
        var result = _mapper.Map<List<UsersOutputModel>>(waiters);

        return result;
    }

    public UsersOutputModel GetUserByEmail(string mail)
    {
        List<UsersDto> users = _repository.GetAllUsers();
        UsersDto user = new UsersDto();
        UsersOutputModel usersOutputModel = new UsersOutputModel();
        user = users.FirstOrDefault(u => u.Mail == mail);
        if (user != null)
        {
            usersOutputModel = _mapper.Map<UsersOutputModel>(user);
        }
        return usersOutputModel;
    }

    public List<UsersOutputModel> GetUsersByProfile(int prId)
    {
        List<UsersDto> users = _repository.GetUsersByProfile(prId);
        var result = _mapper.Map<List<UsersOutputModel>>(users);

        return result;
    }

    public bool CheckLoginRights(LoginInputModel model)
    {
        bool result = false;
        var user = GetUserByMail(model.Email);
        if (user != null && model.Password == user.Password)
        {
            result = true;
        }

        return result;
    }

    public LoginOutputModel GetUserByMail(string mail)
    {
        var user = _repository.GetUserByMail(mail);
        var result = _mapper.Map<LoginOutputModel>(user);

        return result;
    }

    public UsersOutputModel GetOrderUser(int orderId)
    {
        var user = _repository.GetOrderUser(orderId);
        var result = _mapper.Map<UsersOutputModel>(user);

        return result;
    }

    public UsersOutputModel GetOrderManager(int orderId)
    {
        var user = _repository.GetOrderManager(orderId);
        if (user == null) 
        {
            user = new UsersDto();
        }
        var result = _mapper.Map<UsersOutputModel>(user);

        return result;
    }
}