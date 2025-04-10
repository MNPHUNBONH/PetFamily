using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteer;

namespace PetFamily.Infrastructure.Configurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteers");

        builder.HasKey(x => x.Id);

        builder.Property(m => m.Id)
            .HasConversion(id => id.Value,
                value => VolunteerId.Create(value));

        builder.ComplexProperty(fn => fn.FullName, n =>
        {
            n.Property(fn => fn.FirstName)
                .IsRequired()
                .HasMaxLength(VolunteerFullName.MAX_LENGTH)
                .HasColumnName("first_name");
            n.Property(ln => ln.LastName)
                .IsRequired()
                .HasMaxLength(VolunteerFullName.MAX_LENGTH)
                .HasColumnName("last_name");
            n.Property(mn => mn.MiddleName)
                .IsRequired()
                .HasMaxLength(VolunteerFullName.MAX_LENGTH)
                .HasColumnName("middle_name");
        });

        builder.ComplexProperty(b => b.Email, e =>
        {
            e.Property(e => e.Value)
                .IsRequired()
                .HasMaxLength(VolunteerEmail.MAX_LENGTH)
                .HasColumnName("email");
        });
        
        builder.ComplexProperty(b => b.Description, d =>
        {
            d.Property(des => des.Value)
                .IsRequired()
                .HasMaxLength(Description.MAX_LENGTH)
                .HasColumnName("description");
        });
        
        builder.ComplexProperty(b => b.Experience, e =>
        {
            e.Property(e => e.Value)
                .IsRequired()
                .HasColumnName("experience");
        });
        
        builder.ComplexProperty(b => b.Phone, d =>
        {
            d.Property(p => p.Value)
                .IsRequired()
                .HasMaxLength(PhoneNumber.MAX_LENGTH)
                .HasColumnName("phone");
        });
        
        builder.HasMany(p => p.Pets)
            .WithOne()
            .HasForeignKey("volunteer_id")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.OwnsOne(v => v.VolunteerDetails, vd =>
        {
            vd.ToJson();
            vd.OwnsMany(pd => pd.PaymentDetails, b =>
            {
                b.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
                b.Property(p => p.Description)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            });
            vd.OwnsMany(snb => snb.SocialNetworks, sn =>
            {
                sn.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
                sn.Property(p => p.Link)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
            });
        });
    }
}