using BOL;
using BOL.Models;
using DAL.Abstract;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Implementation
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(CyberTrainingContext context) : base(context)
        { }
        public void Insert(User user)
        {
            db.Entry(user).State = EntityState.Added;
            db.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users
                .Include(role => role.Role)
                .Include(team => team.Team)
                .ToList();
        }

        public User GetById(int id)
        {
            return db.Users.FirstOrDefault(x=>x.UserId == id);
        }

        public void Delete(int id)
        {
            User user = GetById(id);
            db.Entry(user).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
