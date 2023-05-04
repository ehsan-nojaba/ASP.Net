using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Security.DomainModel.Model.Configuration
{
    public class ProjectActionConfiguration:IEntityTypeConfiguration<ProjectAction>
    {
        public void Configure(EntityTypeBuilder<ProjectAction> builder)
        {
            builder.HasKey(x => x.ProjectActionId);
            builder.Property(x => x.ProjectActionName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PersianTitle).IsRequired().HasMaxLength(100);
            builder.HasMany(x => x.RoleActions).WithOne(x => x.ProjectAction).HasForeignKey(x => x.ProjectActionId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}