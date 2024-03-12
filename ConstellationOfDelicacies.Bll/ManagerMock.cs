using ConstellationOfDelicacies.Bll.IManager;
using ConstellationOfDelicacies.Bll.Models;

namespace ConstellationOfDelicacies.Bll;

public class ManagerMock:IManager.IManager
{
    private List<WorkerOutputModel> _chiefs;
    private List<WorkerOutputModel> _waiters;

    public ManagerMock()
    {
        _chiefs = new List<WorkerOutputModel>()
        {
            new WorkerOutputModel()
            {
                Id = 1,
                Name = "Вася Иванов",
                RoleId = 2,
                SubRoleId = 2,
            },
            new WorkerOutputModel()
            {
                Id = 2,
                Name = "Олег Иванович Пушкин",
                RoleId = 2,
                SubRoleId = 3
            }
        };
        _waiters = new List<WorkerOutputModel>()
        {
            new WorkerOutputModel()
            {
                Id = 1,
                Name = "Иваська Белый",
                RoleId = 3,
            },
            new WorkerOutputModel()
            {
                Id = 2,
                Name = "Геральт из Ривии",
                RoleId = 3,
            }
        };

    }
    public WorkerOutputModel AddChief(int id)
    {
        return new WorkerOutputModel
        {
            Id = 3,
            Name = "Игорь Петров",
            RoleId = 2,
            SubRoleId = 1,
        };
    }

    public List<WorkerOutputModel> GetAllChiefs()
    {
        return _chiefs;
    }

    public List<WorkerOutputModel> GetAllWaiters()
    {
        return _waiters;
    }
}