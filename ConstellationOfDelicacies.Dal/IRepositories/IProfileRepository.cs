using ConstellationOfDelicacies.Dal.Dtos;

namespace ConstellationOfDelicacies.Dal.IRepositories;

public interface IProfileRepository
{
    public List<ProfilesDto> GetProfilesBySpecialization(int spId);
}

