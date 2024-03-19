using ConstellationOfDelicacies.Bll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstellationOfDelicacies.Bll
{
    public class UserMock: IUser.IUser
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
    }
}
