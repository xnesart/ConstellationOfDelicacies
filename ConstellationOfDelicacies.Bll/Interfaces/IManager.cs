using ConstellationOfDelicacies.Bll.Models;

namespace ConstellationOfDelicacies.Bll.IManager;

public interface IManager
{
    public ChiefOutputModel AddChief(int id);
    public List<ChiefOutputModel> GetAllChiefs();
}