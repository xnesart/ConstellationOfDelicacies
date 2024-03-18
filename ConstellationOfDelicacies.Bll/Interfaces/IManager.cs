using ConstellationOfDelicacies.Bll.Models;

namespace ConstellationOfDelicacies.Bll.IManager;

public interface IManager
{
    public WorkerOutputModel AddChiefById(int id);
    public void AddChief(WorkerOutputModel model);
    public void AddWaiter(WorkerOutputModel model);
    public List<WorkerOutputModel> GetAllChiefs();
    public int GetChiefsLastId();
    public int GetWaitersLastId();
    public List<WorkerOutputModel> GetAllWaiters();
    public WorkerOutputModel GetChiefById(int id);
    public WorkerOutputModel GetWaiterById(int id);
    public void UpdateChiefById(int id, WorkerOutputModel model);
    public void UpdateWaiterById(int id, WorkerOutputModel model);
    public void RemoveChief(int id);
    public void RemoveWaiter(int id);
}