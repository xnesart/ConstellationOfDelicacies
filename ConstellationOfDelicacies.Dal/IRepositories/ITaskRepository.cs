using ConstellationOfDelicacies.Dal.Dtos;

namespace ConstellationOfDelicacies.Dal.IRepositories
{
    public interface ITaskRepository
    {
        public Task<List<TasksDto>> GetOrderTasks(int orderId);

        public void AddOrderTask(TasksDto orderTask);

        public void DeleteOrderTask(int taskId);

        public void UpdateOrderTask(TasksDto orderTask);
    }
}
