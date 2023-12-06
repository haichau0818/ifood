
using FoodManage.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManage.BUS
{
    public class UserBUS
    {
        protected MyDBContext _dbContext = new MyDBContext();


        private static UserBUS instance;


        public static UserBUS Instance
        {
            get
            {
                if (instance == null) instance = new UserBUS();
                return instance;
            }
            private set => instance = value;
        }

        private UserBUS() { }

        public User Login(string email, string password )
        {
            User user = _dbContext.Set<User>().ToList().FirstOrDefault(p => p.Email == email && p.Password == password);
            if (user!=null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public bool Insert(User user) {
            
            return true;
        }

    }
}
