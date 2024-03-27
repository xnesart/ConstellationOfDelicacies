using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;

namespace ConstellationOfDelicacies.Bll.Interfaces;

public interface IRoleClient
{
    public void AddRole(string title);
    public void RemoveRole();
    public List<RolesOutputModel> GetAllRoles();
    public RolesOutputModel GetRoleByEmail(string mail);
}