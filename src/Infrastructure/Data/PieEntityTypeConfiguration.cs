
namespace Bakery.Infrastructure.Data
{
    using Bakery.Domain.Aggregates.PieAggregate;
    using Microsoft.EntityFrameworkCore;

    public class PieEntityTypeConfiguration : IEntityTypeConfiguration<Pie>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Pie> builder)
        {
            // Use a backing field for the Id property.
            builder
                .Property(x => x.Id)
                .HasField("_id")
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            // Use a backing field for the description property.
            builder
                .Property(x => x.Name)
                .HasField("_name")
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            // Use a backing field for the description property.
            builder
                .Property(x => x.Description)
                .HasField("_description")
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            // Mark the portions property as an owned entity.
            // And set a backing field for it.
            builder.OwnsOne(x => x.Portions);
            builder.Navigation(x => x.Portions).Metadata.SetField("_portions");

            // Mark the ingredients as an owned collection.
            // And set a backing field for it.
            var ingredientsConfiguration = builder.OwnsMany(x => x.Ingredients);
            builder.Navigation(x => x.Ingredients).Metadata.SetField("_ingredients");

            // You can configure the rules for owned entities using the returned configuration builder instance.
            ingredientsConfiguration.Property(x => x.Name).HasMaxLength(250).IsRequired();
        }
    }
}