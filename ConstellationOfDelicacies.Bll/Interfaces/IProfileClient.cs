using ConstellationOfDelicacies.Bll.Models;

namespace ConstellationOfDelicacies.Bll.Interfaces;

public interface IProfileClient
{
    public List<ProfilesOutputModel> GetProfiles(int spId);

    public decimal GetChiefsAverageCost();
}