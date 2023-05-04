using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping.DomainModel.Model.Configuration
{
    public class SupplierConfiguration:IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.SupplierId);
            builder.Property(x => x.SupplierName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Tel).IsRequired().HasMaxLength(20);
            builder.HasMany(x => x.Products).WithOne(x => x.Supplier).HasForeignKey(x => x.SupplierId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
