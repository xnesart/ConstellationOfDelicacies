using ConstellationOfDelicacies.Dal.Dtos;

namespace ConstellationOfDelicacies.Dal.IRepositories
{
    public interface IRoleRepository
    {
        public RolesDto GetRoleById(int roleId);
    }
}
