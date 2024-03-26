using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.IRepositories;

namespace ConstellationOfDelicacies.Dal.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly Context _storage;

        public TaskRepository()
        {
            _storage = SingletoneStorage.GetStorage().Storage;
        }

        public TasksDto SetTaskDto(TasksDto taskDto)
        {
            taskDto.Order = _storage.Orders.Where(o => o.Id == taskDto.Order.Id).Single();
            if (taskDto.Profiles != null) 
            {
                foreach (var pr in taskDto.Profiles.ToList())
                {
                    taskDto.Profiles.Add(_storage.Profiles.Where(p => p.Id == pr.Id).Single());
                    taskDto.Profiles.Remove(pr);
                }
            }
            if (taskDto.Users != null)
            {
                foreach (var u in taskDto.Users.ToList())
                {
                    taskDto.Users.Add(_storage.Users.Where(us => us.Id == u.Id).Single());
                    taskDto.Users.Remove(u);
                }
            }

            return taskDto;
        }

        public void AddOrderTask(TasksDto orderTask)
        {
            orderTask = SetTaskDto(orderTask);

            _storage.Tasks.Add(orderTask);
            _storage.SaveChanges();
        }

        public void DeleteOrderTask(int taskId)
        {
            var storageTask = _storage.Tasks.Where(t => t.Id == taskId).Single();

            if (storageTask != null)
            {
                storageTask.IsDeleted = true;

                _storage.Tasks.Update(storageTask);
                _storage.SaveChanges();
            }
        }

        public void UpdateOrderTask(TasksDto orderTask)
        {
            orderTask = SetTaskDto(orderTask);

            var storageTask = _storage.Tasks.Where(t => t.Id == orderTask.Id).Single();

            if (storageTask != null)
            {
                storageTask.Title = orderTask.Title;

                storageTask.Profiles.Clear();
                foreach (var p in orderTask.Profiles)
                {
                    storageTask.Profiles.Add(p);
                }

                if (storageTask.Users != null) storageTask.Users.Clear();
                else storageTask.Users = new List<UsersDto>();
                
                if (orderTask.Users != null)
                {
                    foreach (var u in orderTask.Users)
                    {
                        storageTask.Users.Add(u);
                    }
                }

                _storage.Tasks.Update(storageTask);
                _storage.SaveChanges();
            }
        }
    }
}
