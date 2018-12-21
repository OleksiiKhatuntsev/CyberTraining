using BOL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Abstract
{
    public interface IRoleRepository
    {
        void Insert(Role role);
        IEnumerable<Role> GetAll();
        User GetById(int id);
        void Delete(int id);
        void Update(Role role);
    }
}
