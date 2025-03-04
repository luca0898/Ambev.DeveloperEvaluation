using Ambev.DeveloperEvaluation.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.ToTable("Products");

        builder.Property(p => p.CreatedAt).IsRequired();

        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Price)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(p => p.Description)
            .HasMaxLength(1000);

        builder.Property(p => p.Image)
            .HasMaxLength(500);

        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .IsRequired();

        builder.HasOne(p => p.Rating)
           .WithOne(pr => pr.Product)
           .HasForeignKey<ProductRating>(pr => pr.ProductId)
           .OnDelete(DeleteBehavior.Cascade);
    }
}
