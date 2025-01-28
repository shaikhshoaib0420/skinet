using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Id).IsRequired();
        builder.Property("Name").IsRequired().HasMaxLength(100);
        builder.Property("Description").IsRequired().HasMaxLength(200);
        builder.Property("PictureUrl").IsRequired();
        builder.Property("Price").HasColumnType("decimal(18,2)");
        builder.HasOne("ProductType").WithMany()
        .HasForeignKey("ProductTypeId");
        builder.HasOne("ProductBrand").WithMany()
        .HasForeignKey("ProductBrandId");
    }
}