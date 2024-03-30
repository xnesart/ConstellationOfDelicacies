using ConstellationOfDelicacies.Dal.Dtos;

namespace ConstellationOfDelicacies.Dal.IRepositories
{
    public interface ISpecializationRepository
    {
        public SpecializationsDto GetSpTitleById(int spId);

        public SpecializationsDto GetSpByProfile(int prId);

        public List<SpecializationsDto> GetAllSpecializations();
    }
}
