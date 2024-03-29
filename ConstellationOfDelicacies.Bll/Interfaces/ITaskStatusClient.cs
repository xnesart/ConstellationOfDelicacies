using ConstellationOfDelicacies.Bll.Models.InputModels;

namespace ConstellationOfDelicacies.Bll.Interfaces;

public interface ITaskStatusClient
{
    public void UpdateStatus(TaskStatusesInputModel statusTasks);
}