using BOL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Abstract
{
    public interface ITeamRepository
    {
        void Insert(Team team);
        IEnumerable<Team> GetAll();
        Team GetById(int id);
        void Delete(int id);
        void Update(Team team);
    }
}
