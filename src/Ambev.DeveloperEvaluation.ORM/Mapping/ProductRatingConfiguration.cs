using Ambev.DeveloperEvaluation.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductRatingConfiguration : IEntityTypeConfiguration<ProductRating>
{
    public void Configure(EntityTypeBuilder<ProductRating> builder)
    {
        builder.HasKey(pr => pr.Id);
        builder.ToTable("ProductRatings");

        builder.Property(pr => pr.Rate)
            .IsRequired()
            .HasPrecision(3, 1);

        builder.Property(pr => pr.Count)
            .IsRequired();

        builder.Property(pr => pr.ProductId)
            .IsRequired();

        builder.HasOne(pr => pr.Product)
            .WithOne(p => p.Rating)
            .HasForeignKey<ProductRating>(pr => pr.ProductId);
    }
}
