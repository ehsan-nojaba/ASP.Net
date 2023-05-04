using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Security.DomainModel.Model.Configuration
{
    public class ProjectControllerConfiguration:IEntityTypeConfiguration<ProjectController>
    {
        public void Configure(EntityTypeBuilder<ProjectController> builder)
        {
            builder.HasKey(x => x.ProjectControllerId);
            builder.Property(x => x.ProjectControllerName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PersianTitle).IsRequired().HasMaxLength(20);
            builder.HasMany(x => x.ProjectActions).WithOne(x => x.ProjectController)
                .HasForeignKey(x => x.ProjectControllerId).OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
