using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;
using PetFamily.Domain.Volunteer.Pet;

namespace PetFamily.Infrastructure.Configurations;

public class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.ToTable("breeds");

        builder.HasKey(x => x.Id);

        builder.Property(b => b.Id)
            .HasConversion(id => id.Value,
                value => BreedId.Create(value));
        
        builder.ComplexProperty(b => b.Title,bt =>
        {
            bt.Property(n => n.Value)
                .HasMaxLength(Title.MAX_LENGTH)
                .HasColumnName("name")
                .IsRequired();
        });
    }
}