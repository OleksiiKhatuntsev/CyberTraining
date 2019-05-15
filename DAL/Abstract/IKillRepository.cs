using System;
using System.Collections.Generic;
using System.Text;
using BOL.Models;

namespace DAL.Abstract
{
    public interface IKillRepository
    {
        void Insert(Kill kill);
        IEnumerable<Kill> GetAll();
        Kill GetById(int id);
        void Delete(int id);
        void Update(Kill kill);
    }
}
