using ConstellationOfDelicacies.Dal.Dtos;

namespace ConstellationOfDelicacies.Dal.IRepositories
{
    public interface ITaskRepository
    {
        public TasksDto GetOrderTask(int taskId);

        public List<TasksDto> GetAllOrderTasks(int orderId);
        public List<TasksDto> GetAllWorkerTasks(int userId);
        public void UpdateTaskStatus(int statusId, int taskId);

        public void AddOrderTask(TasksDto orderTask);

        public void AddTaskUser(TasksDto orderTask);

        public void DeleteTaskUser(TasksDto orderTask);

        public void DeleteOrderTask(int taskId);

        public void UpdateOrderTask(TasksDto orderTask);
    }
}
