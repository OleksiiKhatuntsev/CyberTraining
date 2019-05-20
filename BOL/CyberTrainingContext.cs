using BOL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOL
{
    public class CyberTrainingContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Condition> Conditions { get; set; }

        public DbSet<Kill> Kills { get; set; }

        public DbSet<ParentsControl> ParentsControls { get; set; }

        public CyberTrainingContext(DbContextOptions<CyberTrainingContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
