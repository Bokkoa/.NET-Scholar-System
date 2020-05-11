using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scholarSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace scholarSystem.DAL
{
    public class ScholarSystemContext:DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public ScholarSystemContext(DbContextOptions options)
        :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GroupConfig());

            modelBuilder.ApplyConfiguration(new StudentConfig());
        }
    }
}
