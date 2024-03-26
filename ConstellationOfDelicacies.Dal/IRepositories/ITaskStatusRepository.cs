using ConstellationOfDelicacies.Dal.Dtos;

namespace ConstellationOfDelicacies.Dal.IRepositories
{
    public interface ITaskStatusRepository
    {
        public void UpdateStatus(TaskStatusesDto statusTasks);
    }
}
