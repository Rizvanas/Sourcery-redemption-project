using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using My_IKS.Data.Domain;
using My_IKS.Persistance.Configurations;

namespace My_IKS.Persistance
{
    public class IKSContext : DbContext
    {
        public IKSContext(DbContextOptions<IKSContext> options)
            : base(options)
        { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Goal> Goals { get; set; }
        public virtual DbSet<UserSkill> UserSkills { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SkillConfiguration());
            modelBuilder.ApplyConfiguration(new GoalConfiguration());
            modelBuilder.ApplyConfiguration(new UserSkillConfiguration());
        }
    }
}
