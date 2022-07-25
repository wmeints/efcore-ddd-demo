
namespace Bakery.Infrastructure.Data
{
    using Bakery.Domain.Aggregates.CategoryAggregate;
    using Bakery.Domain.Aggregates.PieAggregate;
    using Microsoft.EntityFrameworkCore;

    public class PieEntityTypeConfiguration : IEntityTypeConfiguration<Pie>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Pie> builder)
        {
            // Mark the portions property as an owned entity.
            // And set a backing field for it.
            builder.OwnsOne(x => x.Portions);

            // Mark the ingredients as an owned collection.
            // And set a backing field for it.
            var ingredientsConfiguration = builder.OwnsMany(x => x.Ingredients);
            builder.Navigation(x => x.Ingredients).Metadata.SetField("_ingredients");

            // You can configure the rules for owned entities using the returned configuration builder instance.
            ingredientsConfiguration.Property(x => x.Name).HasMaxLength(250).IsRequired();

            builder.HasOne<Category>().WithMany().HasForeignKey(x => x.CategoryId);
        }
    }
}