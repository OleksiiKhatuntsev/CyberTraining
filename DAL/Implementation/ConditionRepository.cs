using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOL;
using BOL.Models;
using DAL.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation
{
    public class ConditionRepository : BaseRepository, IConditionRepository
    {
        public ConditionRepository(CyberTrainingContext context) : base(context)
        { }

        public void Insert(Condition condition)
        {
            db.Entry(condition).State = EntityState.Added;
            db.SaveChanges();
        }

        public IEnumerable<Condition> GetAll()
        {
            return db.Conditions
                .Include(user=>user.User)
                .ToList();
        }

        public Condition GetById(int id)
        {
            return db.Conditions.FirstOrDefault(x => x.ConditionId == id);
        }

        public void Delete(int id)
        {
            Condition condition = this.GetById(id);
            db.Entry(condition).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Update(Condition condition)
        {
            db.Entry(condition).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
