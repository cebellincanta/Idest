using IdestAltoGiroApp.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdestAltoGiroApp.Infra.Mappins;

public class EmailMapping : IEntityTypeConfiguration<Email>
{
    public void Configure(EntityTypeBuilder<Email> builder)
    {
        builder.ToTable("email");
        builder.Property(p => p.Id).HasColumnName("id").IsRequired();
        builder.Property(p => p.EmailName).HasColumnName("email").IsRequired().HasMaxLength(14);
        builder.Property(p => p.IsMain).HasColumnName("ismain").IsRequired().HasColumnType("boolean");
        builder.Property(p => p.PersonId).HasColumnName("personid").IsRequired();
        builder.HasOne(p => p.Person).WithMany(x => x.Emails).HasForeignKey(f => f.PersonId);
    }
}