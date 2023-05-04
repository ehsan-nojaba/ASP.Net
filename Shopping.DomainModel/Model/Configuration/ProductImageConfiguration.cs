using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping.DomainModel.Model.Configuration
{
    public class ProductImageConfiguration:IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasKey(x => x.ProductImageId);
            builder.Property(x => x.Picture).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Alt).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(150);
            builder.Property(x => x.isDefault).IsRequired();
        }
    }
}
