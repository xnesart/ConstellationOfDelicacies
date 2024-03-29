using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;

namespace ConstellationOfDelicacies.Bll.Interfaces
{
    public interface ITaskClient
    {
        public List<TasksOutputModel> GetOrderTasks(int orderId);

        public void AddOrderTask(TasksInputModel model);

        public void DeleteOrderTask(int taskId);

        public void UpdateOrderTask(TasksInputModel model);
    }
}
