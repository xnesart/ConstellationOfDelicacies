using ConstellationOfDelicacies.Dal.Dtos;

namespace ConstellationOfDelicacies.Dal.IRepositories
{
    public interface ITaskRepository
    {
        public TasksDto GetOrderTask(int taskId);

        public List<TasksDto> GetAllOrderTasks(int orderId);

        public void AddOrderTask(TasksDto orderTask);

        public void AddTaskUser(TasksDto orderTask);

        public void DeleteTaskUser(TasksDto orderTask);

        public void DeleteOrderTask(int taskId);

        public void UpdateOrderTask(TasksDto orderTask);
    }
}
