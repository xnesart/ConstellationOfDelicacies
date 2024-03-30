using ConstellationOfDelicacies.Bll.Models;

namespace ConstellationOfDelicacies.Bll.Interfaces;

public interface ISpecializationClient
{
    public string GetSpTitleById(int spId);

    public SpecializationsOutputModel GetSpByProfileId(int prId);

    public List<SpecializationsOutputModel> GetAllSpecializations();

}