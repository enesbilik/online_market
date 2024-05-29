using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .HasColumnName("Name").IsRequired();

        builder.Property(c => c.Description)
            .HasColumnName("Description").IsRequired();

        builder.Property(c => c.ImageUrl)
            .HasColumnName("ImageUrl").IsRequired();

        builder.Property(c => c.IsDeleted)
            .HasColumnName("IsDeleted").IsRequired();

        builder.Property(c => c.CreatedDate)
            .HasColumnName("CreatedDate").IsRequired();

        builder.Property(c => c.UpdatedDate)
            .HasColumnName("UpdatedDate");
        
        builder.HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasQueryFilter(c => !c.IsDeleted);
        
        
        
        
    }
}