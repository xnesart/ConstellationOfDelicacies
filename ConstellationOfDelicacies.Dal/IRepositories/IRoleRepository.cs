using ConstellationOfDelicacies.Dal.Dtos;

namespace ConstellationOfDelicacies.Dal.IRepositories
{
    public interface IRoleRepository
    {
        public RolesDto GetRoleByTitle(string title);
    }
}
