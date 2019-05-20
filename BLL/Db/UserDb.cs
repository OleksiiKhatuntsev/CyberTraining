using System;
using System.Collections.Generic;
using System.Text;
using BOL;
using BOL.Models;
using DAL.Abstract;
using DAL.Implementation;

namespace BLL.Db
{
    public class UserDb
    {
        private readonly IUserRepository db;
        
        public UserDb(CyberTrainingContext context)
        {
            db = new UserRepository(context);
        }

        public void Insert(User user)
        {
            db.Insert(user);
        }

        public User GetById(int id)
        {
            return db.GetById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.GetAll();
        }

        public void Delete(int id)
        {
            db.Delete(id);
        }

        public void Update(User user)
        {
            db.Update(user);
        }

        public void InsertAdmin()
        {
            db.Insert(new User{Email = "admin@admin.com", Password = "admin", RoleId = 1, UserName = "Administrator", TeamId = 1 });
        }

        public void InsertFewUsers()
        {
            db.Insert(new User { Email = "first@admin.com", Password = "admin", RoleId = 1, UserName = "Administrator", TeamId = 1 });
            db.Insert(new User { Email = "second@admin.com", Password = "admin", RoleId = 3, UserName = "User1", TeamId = 1 });
            db.Insert(new User { Email = "third@admin.com", Password = "admin", RoleId = 3, UserName = "User2", TeamId = 1 });
            db.Insert(new User { Email = "fourth@admin.com", Password = "admin", RoleId = 3, UserName = "User3", TeamId = 1 });
            db.Insert(new User { Email = "fifth@admin.com", Password = "train", RoleId = 2, UserName = "Trainer", TeamId = 1 });
            db.Insert(new User { Email = "parent@parent.com", Password = "parent", RoleId = 5, UserName = "Parent", TeamId = 1 });
        }
    }
}
