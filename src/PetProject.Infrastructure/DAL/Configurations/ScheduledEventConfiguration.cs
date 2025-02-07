using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetProject.Core.Entities;
using PetProject.Core.ValueObjects;

namespace PetProject.Infrastructure.DAL.Configurations;

internal sealed class ScheduledEventConfiguration : IEntityTypeConfiguration<ScheduledEvent>
{
    public void Configure(EntityTypeBuilder<ScheduledEvent> builder)
    {
        builder.HasKey(x => x.EventId);
        builder.Property(x => x.EventId)
            .HasConversion(x => x.Value, x => new EventId(x));
        builder.Property(x => x.EventName)
            .HasConversion(x => x.Value, x => new EventName(x));
        builder.Property(x => x.EventDescription)
            .HasConversion(x => x.Value, x => new EventDescription(x));
        builder.Property(x => x.From)
            .HasConversion(x => x.Value, x => new From(x));
        builder.Property(x => x.To)
            .HasConversion(x => x.Value, x => new To(x));
        builder.Property(x => x.OwnerId)
            .HasConversion(x => x.Value, x => new UserId(x));
    }
}