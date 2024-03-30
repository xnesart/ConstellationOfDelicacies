using AutoMapper;
using ConstellationOfDelicacies.Bll.Interfaces;
using ConstellationOfDelicacies.Bll.Mapping;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;
using ConstellationOfDelicacies.Dal;
using ConstellationOfDelicacies.Dal.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ConstellationOfDelicacies.Bll.Clients;

public class RoleClient : IRoleClient
{
    private readonly SingletoneStorage _storage;
    private readonly IMapper _mapper;
    
    public RoleClient()
    {
        _storage = SingletoneStorage.GetStorage();
        IConfigurationProvider config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
        _mapper = new Mapper(config);
    }

    public void AddRole(string title)
    {
        RolesInputModel model = new RolesInputModel()
        {
            Title = title
        };
        
        RolesDto dto=_mapper.Map<RolesDto>(model);
        
        _storage.Storage.Roles.Add(dto);
    }

    public void RemoveRole()
    {
        throw new NotImplementedException();
    }

    public List<RolesOutputModel> GetAllRoles()
    {
        var roles =_storage.Storage.Roles.ToList();
        var rolesOutput = _mapper.Map<List<RolesOutputModel>>(roles);
        return rolesOutput;
    }

    public RolesOutputModel GetRoleByEmail(string mail)
    {
        IUserClient userClient = new UserClient();
        var usersDto = _storage.Storage.Users.Include(u => u.Role).ToList();
        var users = _mapper.Map<List<UsersOutputModel>>(usersDto);

        RolesOutputModel role = new RolesOutputModel();
        foreach (var user in users)
        {
            if (user.Mail == mail)
            {
                 role = user.Role;
                 break;
            }
        }

        return role;

    }
}