using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My_IKS.Data.Domain;

namespace My_IKS.Persistance.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(skill => skill.SkillId);
            builder.Property(skill => skill.Title).HasMaxLength(50).IsRequired();
        }
    }
}
