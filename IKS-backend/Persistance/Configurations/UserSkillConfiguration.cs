using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My_IKS.Data.Domain;

namespace My_IKS.Persistance.Configurations
{
    public class UserSkillConfiguration : IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            builder.HasKey(us => new { us.UserId, us.SkillId });
            builder.HasOne(us => us.User).WithMany(u => u.UserSkills).HasForeignKey(u => u.UserId);
            builder.HasOne(us => us.Skill).WithMany(s => s.UserSkills).HasForeignKey(s => s.SkillId);
            builder.Property(skill => skill.SkillLevel).IsRequired();
        }
    }
}
