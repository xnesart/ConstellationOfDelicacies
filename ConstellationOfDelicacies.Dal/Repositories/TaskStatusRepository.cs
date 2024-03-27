using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.IRepositories;

namespace ConstellationOfDelicacies.Dal.Repositories
{
    public class TaskStatusRepository : ITaskStatusRepository
    {
        private readonly Context _storage;

        public TaskStatusRepository()
        {
            _storage = SingletoneStorage.GetStorage().Storage;
        }

        public void UpdateStatus(TaskStatusesDto statusTasks)
        {
            foreach (var task in statusTasks.Tasks)
            {
                var storageTask = _storage.Tasks.Where(t => t.Id == task.Id).Single();
                storageTask.Status = _storage.TaskStatuses.Where(s => s.Id == statusTasks.Id).Single();

                _storage.Tasks.Update(storageTask);
                _storage.SaveChanges();
            }
        }
    }
}
