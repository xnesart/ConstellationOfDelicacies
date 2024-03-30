using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ConstellationOfDelicacies.Dal.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly Context _storage;

        public TaskRepository()
        {
            _storage = SingletoneStorage.GetStorage().Storage;
        }

        public void SetTaskDto(TasksDto taskDto)
        {
            if (taskDto.Order != null)
            {
                taskDto.Order = _storage.Orders.Where(o => o.Id == taskDto.Order.Id).Single();
            }
            
            if (taskDto.Status != null) 
            {
                taskDto.Status = _storage.TaskStatuses.Where(s => s.Id == taskDto.Status.Id).Single();
            }            

            if (taskDto.Profiles != null) 
            {
                List<ProfilesDto> profiles = taskDto.Profiles.ToList();
                taskDto.Profiles.Clear();
                foreach (var pr in profiles)
                {
                    taskDto.Profiles.Add(_storage.Profiles.Where(p => p.Id == pr.Id).Single());
                }
            }

            if (taskDto.Users != null)
            {
                List<UsersDto> users = taskDto.Users.ToList();
                taskDto.Users.Clear();
                foreach (var u in users)
                {
                    taskDto.Users.Add(_storage.Users.Where(us => us.Id == u.Id).Single());
                }
            }
        }

        public TasksDto GetOrderTask(int taskId)
        {
            var result = _storage.Tasks.Where(t => t.Id == taskId)
                .Include(t => t.Users!).ThenInclude(u => u.Profile).Single();
            return result;
        }

        public List<TasksDto> GetAllOrderTasks(int orderId)
        {
            List<TasksDto> result = new List<TasksDto>();
            result = _storage.Tasks.Where(t => t.Order.Id == orderId && t.IsDeleted == false 
                && t.Title != "Пользователь" && t.Title != "Менеджер" )
                .Include(t => t.Status).Include(t => t.Profiles)
                .Include(t => t.Users!).ThenInclude(u => u.Profile).ToList();
                
            return result;
        }

        public void AddOrderTask(TasksDto orderTask)
        {
            SetTaskDto(orderTask);

            _storage.Tasks.Add(orderTask);
            _storage.SaveChanges();
        }

        public void DeleteTaskUser(TasksDto orderTask)
        {
            var storageTask = _storage.Tasks.FirstOrDefault(t => t.Id == orderTask.Id);
            var storageUser = _storage.Users.FirstOrDefault(u => u.Id == orderTask.Users!.First().Id);

            storageTask.Users.Remove(storageUser);
            _storage.Tasks.Update(storageTask);
            _storage.SaveChanges();
        }

        public void AddTaskUser(TasksDto orderTask)
        {
            SetTaskDto(orderTask);
            var storageTask = _storage.Tasks.Where(t => t.Id == orderTask.Id)
                              .Include(t => t.Profiles).Include(t => t.Users).Single();

            if (storageTask == null) return;
            
            if (orderTask.Profiles != null)
            {
                foreach (var p in orderTask.Profiles)
                {
                    storageTask.Profiles.Add(p);
                }
            }

            if (orderTask.Users != null)
            {
                foreach(var u in orderTask.Users)
                {
                    storageTask.Users.Add(u);
                }
            }

            _storage.Tasks.Update(storageTask);
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
            var storageTask = _storage.Tasks.Where(t => t.Id == orderTask.Id).Single();

            storageTask.Title = orderTask.Title;

            _storage.Tasks.Update(storageTask);
            _storage.SaveChanges();
        }
    }
}
