﻿using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;

namespace ConstellationOfDelicacies.Bll.Interfaces
{
    public interface ITaskClient
    {
        public List<TasksOutputModel> GetAllOrderTasks(int orderId);

        public void AddOrderTask(TasksInputModel model);

        public List<TasksOutputModel> GetAllWorkerTasks(int userId);

        public void UpdateTaskStatus(int statusId, int taskId);

        public void DeleteOrderTask(int taskId);

        public void CompleteOrderTask(int taskId);

        public void AddTaskWorker(TasksInputModel model);

        public void DeleteTaskWorker(TasksInputModel model);

        public void UpdateOrderTask(TasksInputModel model);

        public decimal GetOrderTaskPrice(TasksOutputModel model);

        public TasksOutputModel GetOrderTask(int taskId);
    }
}
