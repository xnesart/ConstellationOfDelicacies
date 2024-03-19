using ConstellationOfDelicacies.Bll.IManager;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Dal;

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
                Mail = "vasya432224@ya.ru",
                Phone = "895334365453434"
            },
            new WorkerOutputModel()
            {
                Id = 2,
                Name = "Олег Иванович Пушкин",
                RoleId = 2,
                SubRoleId = 3,
                Mail = "oleg434@ya.ru",
                Phone = "895324353434"
            },
            new WorkerOutputModel()
            {
                Id = 3,
                Name = "Максим Иванович Харитонов",
                RoleId = 2,
                SubRoleId = 3,
                Mail = "maksPower@gmail.com",
                Phone = "895324995434"
            },
            new WorkerOutputModel()
            {
                Id = 4,
                Name = "Андрей Новиков",
                RoleId = 2,
                SubRoleId = 1,
                Mail = "andre@rter@gmail.com",
                Phone = "895324995434"
            },
            new WorkerOutputModel()
            {
                Id = 7,
                Name = "Елена Ковалева",
                RoleId = 2,
                SubRoleId = 3,
                Mail = "elena.kovaleva@example.com",
                Phone = "89871234567"
            },
            new WorkerOutputModel()
            {
                Id = 12,
                Name = "Иван Петров",
                RoleId = 2,
                SubRoleId = 2,
                Mail = "ivan.petrov@example.com",
                Phone = "89654321098"
            },
            new WorkerOutputModel()
            {
                Id = 18,
                Name = "Мария Сидорова",
                RoleId = 2,
                SubRoleId = 1,
                Mail = "maria.sidorova@example.com",
                Phone = "89456781234"
            },
            new WorkerOutputModel()
            {
                Id = 22,
                Name = "Дмитрий Иванов",
                RoleId = 2,
                SubRoleId = 3,
                Mail = "dmitry.ivanov@example.com",
                Phone = "89321234567"
            },
            new WorkerOutputModel()
            {
                Id = 30,
                Name = "Анна Смирнова",
                RoleId = 2,
                SubRoleId = 2,
                Mail = "anna.smirnova@example.com",
                Phone = "89109876543"
            },
            new WorkerOutputModel()
            {
                Id = 41,
                Name = "Сергей Козлов",
                RoleId = 2,
                SubRoleId = 1,
                Mail = "sergey.kozlov@example.com",
                Phone = "89213456789"
            },
            new WorkerOutputModel()
            {
                Id = 63,
                Name = "Павел Соколов",
                RoleId = 2,
                SubRoleId = 2,
                Mail = "pavel.sokolov@example.com",
                Phone = "89987654321"
            }
            
        };
        _waiters = new List<WorkerOutputModel>()
        {
            new WorkerOutputModel()
            {
                Id = 1,
                Name = "Иваська Белый",
                RoleId = 3,
                Mail = "234324@ya.ru",
                Phone = "8954354353434"
            },
            new WorkerOutputModel()
            {
                Id = 2,
                Name = "Геральт из Ривии",
                RoleId = 3,
                Mail = "geralt232442324@gmail.com",
                Phone = "895435433244"
            }
        };
    }
    public WorkerOutputModel AddChiefById(int id)
    {
        return new WorkerOutputModel
        {
            Id = 3,
            Name = "Игорь Петров",
            RoleId = 2,
            SubRoleId = 1,
        };
    }  
    public void AddChief(WorkerOutputModel model)
    {
        _chiefs.Add(model);
    }

    public int GetChiefsLastId()
    {
        int result = 0;
        foreach (var chief in _chiefs)
        {
            if (chief.Id > result)
            {
                result = chief.Id;
            }
        }

        return result;
    }
    public List<WorkerOutputModel> GetAllChiefs()
    {
        return _chiefs;
    }

    public List<WorkerOutputModel> GetAllWaiters()
    {
        return _waiters;
    }
    
    public WorkerOutputModel GetChiefById(int id)
    {
        WorkerOutputModel model = new WorkerOutputModel();
        foreach (var chief in _chiefs)
        {
            if (chief.Id == id)
            {
                return chief;
            }
        }

        return model;
    }  
    public WorkerOutputModel GetWaiterById(int id)
    {
        WorkerOutputModel model = new WorkerOutputModel();
        foreach (var waiter in _waiters)
        {
            if (waiter.Id == id)
            {
                return waiter;
            }
        }

        return model;
    }

    public void UpdateChiefById(int id, WorkerOutputModel model)
    {
        foreach (var chief in _chiefs)
        {
            if (chief.Id == id)
            {
                chief.Name = model.Name;
                chief.Phone = model.Phone;
                chief.Mail = model.Mail;
                break;
            }
        }
    }   
    public void UpdateWaiterById(int id, WorkerOutputModel model)
    {
        foreach (var waiter in _waiters)
        {
            if (waiter.Id == id)
            {
                waiter.Name = model.Name;
                waiter.Phone = model.Phone;
                waiter.Mail = model.Mail;
                break;
            }
        }
    }

    public void RemoveChief(int id)
    {
        foreach (var chief in _chiefs)
        {
            if (chief.Id == id)
            {
                _chiefs.Remove(chief);
                break;
            }
        }
    }

    public void RemoveWaiter(int id)
    {
        foreach (var waiter in _waiters)
        {
            if (waiter.Id == id)
            {
                _waiters.Remove(waiter);
                break;
            }
        }
    }

    public void GetDatabase()
    {
        Context context = new Context();
    }
}