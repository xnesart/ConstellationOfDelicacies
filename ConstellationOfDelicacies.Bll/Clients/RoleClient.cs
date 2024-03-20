using AutoMapper;
using ConstellationOfDelicacies.Bll.Interfaces;
using ConstellationOfDelicacies.Bll.Mapping;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Dal;
using ConstellationOfDelicacies.Dal.Dtos;

namespace ConstellationOfDelicacies.Bll.Clients;

public class RoleClient:IRoleClient
{
    private readonly SingletoneStorage _storage;
    private readonly IMapper _mapper;
    
    public RoleClient()
    {
        _storage = SingletoneStorage.GetStorage();
        IConfigurationProvider config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
        _mapper = new Mapper(config);
    }

    public void AddRole()
    {
        throw new NotImplementedException();
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
}