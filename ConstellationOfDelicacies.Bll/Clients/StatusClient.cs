using AutoMapper;
using ConstellationOfDelicacies.Bll.IManager;
using ConstellationOfDelicacies.Bll.Mapping;
using ConstellationOfDelicacies.Dal;

namespace ConstellationOfDelicacies.Bll.Clients;

public class StatusClient:IStatusClient
{
    private readonly SingletoneStorage _storage;
    private readonly IMapper _mapper;
    
    public StatusClient()
    {
        _storage = SingletoneStorage.GetStorage();
        IConfigurationProvider config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
        _mapper = new Mapper(config);
    }
    public void AddStatus(string Title)
    {
        throw new NotImplementedException();
    }

    public void RemoveStatus(string Title)
    {
        throw new NotImplementedException();
    }
}