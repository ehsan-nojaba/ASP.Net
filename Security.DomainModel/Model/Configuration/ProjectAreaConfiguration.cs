using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Security.DomainModel.Model.Configuration
{
    public class ProjectAreaConfiguration:IEntityTypeConfiguration<ProjectArea>
    {
        public void Configure(EntityTypeBuilder<ProjectArea> builder)
        {
            builder.HasKey(x => x.ProjectAreaId);
            builder.Property(x => x.ProjectAreaName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PersianTitle).IsRequired().HasMaxLength(20);
            builder.HasMany(x => x.ProjectControllers).WithOne(x => x.ProjectArea).HasForeignKey(x => x.ProjectAreaId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}