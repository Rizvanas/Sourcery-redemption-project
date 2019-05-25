using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My_IKS.Data.Domain;

namespace My_IKS.Persistance.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(user => user.LastName).HasMaxLength(50).IsRequired();
            builder.Property(user => user.JobTitle).HasMaxLength(100);
            builder.Property(user => user.Location).HasMaxLength(100);
            builder.Property(user => user.Email).IsRequired();
        }
    }
}
