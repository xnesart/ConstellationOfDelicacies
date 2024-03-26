﻿using ConstellationOfDelicacies.Dal.Dtos;

namespace ConstellationOfDelicacies.Dal.IRepositories
{
    public interface IOrderRepository
    {
        public void AddOrder(OrdersDto order);

        public void UpdateOrder(OrdersDto order);

        public void DeleteOrder(int orderId);
    }
}
