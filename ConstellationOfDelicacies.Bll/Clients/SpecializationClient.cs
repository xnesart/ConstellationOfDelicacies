using AutoMapper;
using ConstellationOfDelicacies.Bll.Interfaces;
using ConstellationOfDelicacies.Bll.Mapping;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Dal;
using ConstellationOfDelicacies.Dal.Repositories;

namespace ConstellationOfDelicacies.Bll.Clients;

public class SpecializationClient : ISpecializationClient
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
        string title = "Название не найдено";
        var sp = _repository.GetSpTitleById(spId);
        if (sp != null)
        {
            title = sp.Title;
        }

        return title;
    }

    public SpecializationsOutputModel GetSpByProfileId(int prId)
    {
        var sp = _repository.GetSpByProfile(prId);
        var result = _mapper.Map<SpecializationsOutputModel>(sp);

        return result;
    }
}