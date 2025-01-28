using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetProject.Core.Entities;
using PetProject.Core.ValueObjects;

namespace PetProject.Infrastructure.DAL.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.UserId);
        builder.Property(x => x.UserId)
            .HasConversion(x => x.Value, x => new UserId(x));
        builder.Property(x => x.Email)
            .HasConversion(x => x.Value, x => new Email(x));
        builder.Property(x => x.Password)
            .HasConversion(x => x.Value, x => new Password(x));
        builder.Property(x => x.Username)
            .HasConversion(x => x.Value, x => new Username(x));
    }
}