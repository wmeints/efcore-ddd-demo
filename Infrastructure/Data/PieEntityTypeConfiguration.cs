
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
            var portionsConfiguration = builder
                .OwnsOne(x => x.Portions)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
            
            // This configuration is needed to make it so that EF Core 
            // uses the parameterized constructor and tracks the fields
            // of the portions class.
            portionsConfiguration.Property(x=>x.Minimum).HasField("_min");
            portionsConfiguration.Property(x=>x.Maximum).HasField("_max");

            // Make sure EF Core knows about the backing field for the owned entity.
            builder.Navigation(x => x.Portions).Metadata.SetField("_portions");
        }
    }
}