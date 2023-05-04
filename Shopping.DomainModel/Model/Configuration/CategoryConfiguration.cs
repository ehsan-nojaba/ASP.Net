using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping.DomainModel.Model.Configuration
{
    public class CategoryConfiguration:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryId);
            builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.MenuIcon).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(400);
            builder.HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}