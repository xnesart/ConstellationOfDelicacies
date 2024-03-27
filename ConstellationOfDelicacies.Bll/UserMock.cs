﻿using ConstellationOfDelicacies.Bll.Clients;
using ConstellationOfDelicacies.Bll.Models.InputModels;

namespace ConstellationOfDelicacies.Bll
{
    public class UserMock
    {
        private List<OrderInputModel> _orders; 

        public UserMock()
        {
            _orders = new List<OrderInputModel>()
            {
                new OrderInputModel()
                {
                    UserId = 1,
                    OrderDate = DateTime.Now,
                    Comment = "qqq",
                    Address = "www",
                    NumberOfPersons = 3
                },
                new OrderInputModel()
                {
                    UserId = 47,
                    OrderDate = DateTime.Now,
                    Comment = "123",
                    Address = "456",
                    NumberOfPersons = 1
                }
            };
        }   

        public void AddUserOrder(OrderInputModel order)
        {
            _orders.Add(order);
        }

        public void DeleteUserOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserOrder(OrderInputModel order)
        {
            throw new NotImplementedException();
        }
    }
}
