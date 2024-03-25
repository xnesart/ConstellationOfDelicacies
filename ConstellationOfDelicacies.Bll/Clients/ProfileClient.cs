using AutoMapper;
using ConstellationOfDelicacies.Bll.Interfaces;
using ConstellationOfDelicacies.Bll.Mapping;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Dal.Repositories;

namespace ConstellationOfDelicacies.Bll.Clients;

public class ProfileClient:IProfileClient
{
    private readonly IMapper _mapper;
    private ProfileRepository _repository;
    
    public ProfileClient()
    {
        _repository = new ProfileRepository();
        IConfigurationProvider config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
        _mapper = new Mapper(config);
    }

    public List<ProfilesOutputModel> GetProfiles(int spId)
    {
        var profiles = _repository.GetProfilesBySpecialization(spId);
        var result = _mapper.Map<List<ProfilesOutputModel>>(profiles);
        
        return result;
    }
}