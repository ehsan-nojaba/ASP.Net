using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Security.DomainModel.Model.Configuration
{
    public class RoleActionConfiguration:IEntityTypeConfiguration<RoleAction>
    {
        public void Configure(EntityTypeBuilder<RoleAction> builder)
        {
            builder.HasKey(x => x.RoleActionId);
            builder.Property(x => x.HasPermission).IsRequired();
        }
    }
}
