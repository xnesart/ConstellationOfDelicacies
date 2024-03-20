using AutoMapper;
using ConstellationOfDelicacies.Bll.Interfaces;
using ConstellationOfDelicacies.Bll.Mapping;
using ConstellationOfDelicacies.Dal;

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
}