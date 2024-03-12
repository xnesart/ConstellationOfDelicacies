using ConstellationOfDelicacies.Bll.Models;

namespace ConstellationOfDelicacies.Bll.IManager;

public interface IManager
{
    public WorkerOutputModel AddChief(int id);
    public List<WorkerOutputModel> GetAllChiefs();
    public WorkerOutputModel GetChiefById(int id);
    public void UpdateChiefById(int id, WorkerOutputModel model);
    public void RemoveChief(int id);
    public List<WorkerOutputModel> GetAllWaiters();
}