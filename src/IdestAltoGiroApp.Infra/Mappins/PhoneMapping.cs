using IdestAltoGiroApp.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdestAltoGiroApp.Infra.Mappins;

public class PhoneMapping : IEntityTypeConfiguration<Phone>
{
    public void Configure(EntityTypeBuilder<Phone> builder)
    {
        builder.ToTable("phone");
        builder.Property(p => p.Id).HasColumnName("id").IsRequired();
        builder.Property(p => p.PhoneNumber).HasColumnName("phone").IsRequired().HasMaxLength(14);
        builder.Property(p => p.IsMain).HasColumnName("ismain").IsRequired().HasColumnType("boolean");
        builder.Property(p => p.PersonId).HasColumnName("personid").IsRequired();
        builder.HasOne(p => p.Person).WithMany(x => x.Phones).HasForeignKey(f => f.PersonId);
    }
}