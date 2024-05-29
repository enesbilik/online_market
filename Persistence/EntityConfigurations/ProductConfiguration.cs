using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasColumnName("Name").IsRequired();

        builder.Property(p => p.Price)
            .HasColumnName("Price").IsRequired();

        builder.Property(p => p.Description)
            .HasColumnName("Description").IsRequired();

        builder.Property(p => p.ImageUrl)
            .HasColumnName("ImageUrl").IsRequired();

        builder.Property(p => p.CategoryId)
            .HasColumnName("CategoryId").IsRequired();

        builder.Property(p => p.Stock)
            .HasColumnName("Stock").IsRequired();

        builder.Property(p => p.IsFeatured)
            .HasColumnName("IsFeatured").IsRequired();

        builder.Property(p => p.IsNew)
            .HasColumnName("IsNew").IsRequired();

        builder.Property(p => p.IsSale)
            .HasColumnName("IsSale").IsRequired();

        builder.Property(p => p.IsDeleted)
            .HasColumnName("IsDeleted").IsRequired();

        builder.Property(p => p.CreatedDate)
            .HasColumnName("CreatedDate").IsRequired();

        builder.Property(p => p.UpdatedDate)
            .HasColumnName("UpdatedDate");

        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(p => !p.IsDeleted);
        
        
    }
}