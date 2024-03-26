using AutoMapper;
using ConstellationOfDelicacies.Bll.Interfaces;
using ConstellationOfDelicacies.Bll.Mapping;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Dal;
using ConstellationOfDelicacies.Dal.Repositories;

namespace ConstellationOfDelicacies.Bll.Clients;

public class SpecializationClient:ISpecializationClient
{
    private readonly IMapper _mapper;
    private SpecializationRepository _repository;

    public SpecializationClient()
    {
        IConfigurationProvider config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
        _mapper = new Mapper(config);
        _repository = new SpecializationRepository();
    }

    public List<SpecializationsOutputModel> GetAllSpecializations()
    {
        var specializationsDtos = _repository.GetAllSpecializations();
        var result = _mapper.Map<List<SpecializationsOutputModel>>(specializationsDtos);
        return result;
    }

    public string GetSpTitleById(int spId)
    {
        var sp = _repository.GetSpTitleById(spId);
        return sp.Title;
    }
}