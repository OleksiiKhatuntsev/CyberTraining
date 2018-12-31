using System;
using System.Collections.Generic;
using System.Text;
using BOL;
using BOL.Models;
using DAL.Abstract;
using DAL.Implementation;

namespace BLL.Db
{
    public class ConditionDb
    {
        private readonly IConditionRepository db;

        public ConditionDb(CyberTrainingContext context)
        {
            db = new ConditionRepository(context);
        }

        public void Insert(Condition condition)
        {
            db.Insert(condition);
        }

        public Condition GetById(int id)
        {
            return db.GetById(id);
        }

        public IEnumerable<Condition> GetAll()
        {
            return db.GetAll();
        }

        public void Delete(int id)
        {
            db.Delete(id);
        }

        public void Update(Condition condition)
        {
            db.Update(condition);
        }
    }
}
