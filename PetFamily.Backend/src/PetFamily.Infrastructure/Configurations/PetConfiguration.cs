using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteer.Pet;

namespace PetFamily.Infrastructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");

        builder.HasKey(x => x.Id);

        builder.Property(m => m.Id)
            .HasConversion(id => id.Value,
                value => PetId.Create(value));
        
        builder.ComplexProperty(p => p.Title,np =>
        {
            np.Property(n => n.Value)
                .HasMaxLength(Title.MAX_LENGTH)
                .HasColumnName("name")
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.SpeciesId,si =>
        {
            si.Property(n => n.Value)
                .IsRequired()
                .HasColumnName("species_id");
        });
        
        builder.ComplexProperty(p => p.Description,dp =>
        {
            dp.Property(d => d.Value)
                .HasMaxLength(Description.MAX_LENGTH)
                .HasColumnName("description")
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.PetGender,gp =>
        {
            gp.Property(g => g.Value)
                .HasColumnName("gender")
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.BreedId,bi =>
        {
            bi.Property(n => n.Value)
                .IsRequired()
                .HasColumnName("breed_id");
        });
        
        builder.ComplexProperty(p => p.Address,ap =>
        {
            ap.Property(c => c.City)
                .HasMaxLength(PetAddress.MAX_LENGTH)
                .HasColumnName("city")
                .IsRequired();
            
            ap.Property(s => s.Street)
                .HasMaxLength(PetAddress.MAX_LENGTH)
                .HasColumnName("street")
                .IsRequired();
            
            ap.Property(hn => hn.HouseNumber)
                .HasMaxLength(PetAddress.MAX_LENGTH)
                .HasColumnName("house_number")
                .IsRequired();
            
        });
        
        builder.ComplexProperty(p => p.Color,cp =>
        {
            cp.Property(c => c.Value)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("color")
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.HealthInformation,hi =>
        {
            hi.Property(i => i.Value)
                .HasMaxLength(Description.MAX_LENGTH)
                .HasColumnName("health_information")
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.PetSize,sp =>
        {
            sp.Property(h => h.Height)
                .HasColumnName("height")
                .IsRequired();
            
            sp.Property(w => w.Weight)
                .HasColumnName("weight")
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.PhoneVolunteer, pv =>
        {
            pv.Property(p => p.Value)
                .IsRequired()
                .HasMaxLength(PhoneNumber.MAX_LENGTH)
                .HasColumnName("phone_volunteer");
        });

        builder.Property(p => p.IsNeutered)
            .IsRequired()
            .HasColumnName("is_neutered");
        
        builder.Property(p => p.IsVaccinated)
            .IsRequired()
            .HasColumnName("is_vaccinated");

        builder.ComplexProperty(p => p.PetAge, pa =>
            {
                pa.Property(y => y.Year)
                    .HasColumnName("year")
                    .IsRequired();
                
                pa.Property(m => m.Months)
                    .HasColumnName("months")
                    .IsRequired();
            }
        );

        builder.ComplexProperty(p => p.HelpStatus, hs =>
        {
            hs.Property(s => s.Value)
                .HasColumnName("help_status")
                .IsRequired();
        });

        builder.ComplexProperty(p => p.PaymentDetails, pd =>
        {
            pd.Property(d => d.Name)
                .IsRequired()
                .HasColumnName("name_paymentdetail")
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            
            pd.Property(d => d.Description)
                .IsRequired()
                .HasColumnName("description_paymentdetail")
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        });
        
        builder.Property(p => p.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();


    }
}