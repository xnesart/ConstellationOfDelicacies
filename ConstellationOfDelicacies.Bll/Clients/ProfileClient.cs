using AutoMapper;
using ConstellationOfDelicacies.Bll.Interfaces;
using ConstellationOfDelicacies.Bll.Mapping;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Dal;
using ConstellationOfDelicacies.Dal.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ConstellationOfDelicacies.Bll.Clients;

public class ProfileClient:IProfileClient
{
    private readonly SingletoneStorage _storage;
    private readonly IMapper _mapper;
    
    public ProfileClient()
    {
        _storage = SingletoneStorage.GetStorage();
        IConfigurationProvider config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
        _mapper = new Mapper(config);
    }

    public List<ProfilesOutputModel> GetProfiles()
    {
        var profiles = _storage.Storage.Profiles.Include(p => p.Specialization).ToList();
        var result = _mapper.Map<List<ProfilesOutputModel>>(profiles);
        
        return result;
    }
}