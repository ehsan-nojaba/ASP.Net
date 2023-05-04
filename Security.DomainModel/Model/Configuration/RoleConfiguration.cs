using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Security.DomainModel.Model.Configuration
{
    public class RoleConfiguration:IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.RoleId);
            builder.Property(x => x.RoleName).IsRequired().HasMaxLength(50);
            builder.HasMany(x => x.RoleActions).WithOne(x => x.Role).HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasMany(x => x.Users).WithOne(x => x.Role).HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
