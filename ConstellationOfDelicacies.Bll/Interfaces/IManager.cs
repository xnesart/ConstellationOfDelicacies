using ConstellationOfDelicacies.Bll.Models;

namespace ConstellationOfDelicacies.Bll.IManager;

public interface IManager
{
    public WorkerOutputModel AddChief(int id);
    public List<WorkerOutputModel> GetAllChiefs();
    public List<WorkerOutputModel> GetAllWaiters();
    public WorkerOutputModel GetChiefById(int id);
    public WorkerOutputModel GetWaiterById(int id);
    public void UpdateChiefById(int id, WorkerOutputModel model);
    public void UpdateWaiterById(int id, WorkerOutputModel model);
    public void RemoveChief(int id);
    public void RemoveWaiter(int id);
}