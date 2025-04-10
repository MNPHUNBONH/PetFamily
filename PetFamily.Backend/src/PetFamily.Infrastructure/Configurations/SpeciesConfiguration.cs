using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;
using PetFamily.Domain.Volunteer.Pet;

namespace PetFamily.Infrastructure.Configurations;

public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
{
    public void Configure(EntityTypeBuilder<Species> builder)
    {
        builder.ToTable("species");

        builder.HasKey(x => x.Id);

        builder.Property(m => m.Id)
            .HasConversion(id => id.Value,
                value => SpeciesId.Create(value));
        
        builder.ComplexProperty(s => s.Title,sn =>
        {
            sn.Property(n => n.Value)
                .HasMaxLength(Title.MAX_LENGTH)
                .HasColumnName("name")
                .IsRequired();
        });

        builder.HasMany(s => s.Breeds)
            .WithOne()
            .HasForeignKey("species_id")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}