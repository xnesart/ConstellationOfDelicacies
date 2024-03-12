using ConstellationOfDelicacies.Bll.IManager;
using ConstellationOfDelicacies.Bll.Models;

namespace ConstellationOfDelicacies.Bll;

public class ManagerMock:IManager.IManager
{
    private List<ChiefOutputModel> _chiefs;

    public ManagerMock()
    {
        _chiefs = new List<ChiefOutputModel>()
        {
            new ChiefOutputModel()
            {
                Id = 1,
                Name = "Вася Иванов",
                RoleId = 2,
                SubRoleId = 2,
            },
            new ChiefOutputModel()
            {
                Id = 2,
                Name = "Олег Иванович Пушкин",
                RoleId = 2,
                SubRoleId = 3
            }
        };
        
    }
    public ChiefOutputModel AddChief(int id)
    {
        return new ChiefOutputModel
        {
            Id = 3,
            Name = "Игорь Петров",
            RoleId = 2,
            SubRoleId = 1,
        };
    }

    public List<ChiefOutputModel> GetAllChiefs()
    {
        return _chiefs;
    }
}