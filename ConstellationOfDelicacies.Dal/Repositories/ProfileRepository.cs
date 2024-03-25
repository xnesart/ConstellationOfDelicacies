using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.IRepositories;

namespace ConstellationOfDelicacies.Dal.Repositories
{
    public class ProfileRepository: IProfileRepository
    {
        private Context _storage;

        public ProfileRepository()
        {
            _storage = SingletoneStorage.GetStorage().Storage;
        }

        public List<ProfilesDto> GetProfilesBySpecialization(int spId)
        {
            var pr = _storage.Profiles.Where(p => p.Specialization.Id == spId).ToList();

            return pr;
        }
    }
}
