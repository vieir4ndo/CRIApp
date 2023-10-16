using CRIApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRIApp.Infrastructure.Mappings;

public class AdminMapping :  IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.BirthDate)
            .IsRequired();

        builder.Property(x => x.Sex)
            .IsRequired();

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);;

        builder.Property(x => x.Password)
            .IsRequired();
        
        builder.Property(x => x.Active)
            .IsRequired();
        
        builder.Property(x => x.NumberOfChildren)
            .IsRequired(false);
        
        builder.Property(x => x.FamilyType)
            .IsRequired(false);
        
        builder.Property(x => x.EducationalLevel)
            .IsRequired(false);
    }
}