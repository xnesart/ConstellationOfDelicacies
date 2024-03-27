using ConstellationOfDelicacies.Bll.Models.InputModels;

namespace ConstellationOfDelicacies.Bll.IManager;

public interface ITaskStatusClient
{
    public void UpdateStatus(TaskStatusesInputModel statusTasks);
}