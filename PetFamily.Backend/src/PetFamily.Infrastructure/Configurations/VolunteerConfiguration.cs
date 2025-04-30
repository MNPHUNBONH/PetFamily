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
            .HasConversion(
                id => id.Value,
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
        });

        builder.ComplexProperty(b => b.Email, eb =>
        {
            eb.Property(e => e.Value)
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
        
        builder.ComplexProperty(b => b.Experience, eb =>
        {
            eb.Property(e => e.Value)
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
        
        builder.OwnsOne(v => v.TransferSocialNetworkList, tb =>
        {
            tb.ToJson("transfer_social_network_list");
                
            tb.OwnsMany(t => t.SocialNetworks, sb =>
            {
                sb.Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(VolunteerSocialNetwork.MAX_NAME_LENGTH)
                    .HasColumnName("network_name");
                        
                sb.Property(s => s.Link)
                    .IsRequired()
                    .HasMaxLength(VolunteerSocialNetwork.MAX_LINK_LENGTH)
                    .HasColumnName("network_address");
            });
        });
        
        builder.OwnsOne(v => v.TransferPaymentDetailsList, tb =>
        {
            tb.ToJson("transfer_payment_details");
                
            tb.OwnsMany(t => t.RequisitesForPaymentDetails, rb =>
            {
                rb.Property(r => r.Name)
                    .IsRequired()
                    .HasMaxLength(VolunteerPaymentDetails.MAX_NAME_LENGTH)
                    .HasColumnName("name_payment_details");
                        
                rb.Property(r => r.Description)
                    .IsRequired()
                    .HasMaxLength(VolunteerPaymentDetails.MAX_DESCRIPTION_LENGTH)
                    .HasColumnName("description_spayment_details");
            });
        });
    }
}