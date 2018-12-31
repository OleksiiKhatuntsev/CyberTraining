using System;
using System.Collections.Generic;
using System.Text;
using BOL.Models;

namespace DAL.Abstract
{
    public interface IConditionRepository
    {
        void Insert(Condition condition);
        IEnumerable<Condition> GetAll();
        Condition GetById(int id);
        void Delete(int id);
        void Update(Condition condition);
    }
}
