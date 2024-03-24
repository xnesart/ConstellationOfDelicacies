using AutoMapper;
using ConstellationOfDelicacies.Bll.Interfaces;
using ConstellationOfDelicacies.Bll.Mapping;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Dal;

namespace ConstellationOfDelicacies.Bll.Clients;

public class SpecializationClient:ISpecializationClient
{
    private readonly SingletoneStorage _storage;
    private readonly IMapper _mapper;
    public SpecializationClient()
    {
        _storage = SingletoneStorage.GetStorage();
        IConfigurationProvider config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
        _mapper = new Mapper(config);
    }

    public List<SpecializationsOutputModel> GetAllSpecializations()
    {
        var specializationsDtos = _storage.Storage.Specializations.ToList();
        var result = _mapper.Map<List<SpecializationsOutputModel>>(specializationsDtos);
        return result;
    }
}