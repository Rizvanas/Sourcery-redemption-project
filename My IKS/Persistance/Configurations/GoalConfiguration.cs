using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My_IKS.Data.Domain;

namespace My_IKS.Persistance.Configurations
{
    public class GoalConfiguration : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.HasKey(goal => goal.GoalId);
            builder.Property(goal => goal.Title).HasMaxLength(50).IsRequired();
            builder.Property(goal => goal.Description).HasMaxLength(240);
            builder.HasOne(goal => goal.User).WithMany(user => user.Goals).IsRequired();
        }
    }
}
