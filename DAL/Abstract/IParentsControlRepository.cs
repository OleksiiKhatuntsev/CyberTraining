using System;
using System.Collections.Generic;
using System.Text;
using BOL.Models;

namespace DAL.Abstract
{
    public interface IParentsControlRepository
    {
        void Insert(ParentsControl parentsControl);
        IEnumerable<ParentsControl> GetAll();
        ParentsControl GetById(int id);
        void Delete(int id);
        void Update(ParentsControl parentsControl);
    }
}
