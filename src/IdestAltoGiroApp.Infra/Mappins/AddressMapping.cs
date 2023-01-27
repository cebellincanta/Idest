using IdestAltoGiroApp.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdestAltoGiroApp.Infra.Mappins;

public class AddressMapping : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("address");
        builder.Property(p => p.Id).HasColumnName("id").IsRequired();
        builder.Property(p => p.PublicPlace).HasColumnName("public_place").IsRequired().HasMaxLength(50);
        builder.Property(p => p.AddressName).HasColumnName("address").IsRequired().HasMaxLength(255);
        builder.Property(p => p.Number).HasColumnName("number").IsRequired().HasMaxLength(6);
        builder.Property(p => p.Neighborhood).HasColumnName("neighborhood").IsRequired().HasMaxLength(50);
        builder.Property(p => p.Cep).HasColumnName("cep").IsRequired().HasMaxLength(9);
        builder.Property(p => p.City).HasColumnName("city").IsRequired().HasMaxLength(100);
        builder.Property(p => p.State).HasColumnName("state").IsRequired().HasMaxLength(30);
        builder.Property(p => p.Country).HasColumnName("country").IsRequired().HasMaxLength(50);
        builder.Property(p => p.Complement).HasColumnName("complement").HasMaxLength(50);
        builder.Property(p => p.PersonId).HasColumnName("personid").IsRequired();
        builder.HasOne(p => p.Person).WithMany(x => x.Address).HasForeignKey(f => f.PersonId);
    }
}