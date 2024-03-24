using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Dal.Dtos;

namespace ConstellationOfDelicacies.Bll.Interfaces;

public interface IProfileClient
{
    public List<ProfilesOutputModel> GetProfiles();
}