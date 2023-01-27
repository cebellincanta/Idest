using IdestAltoGiroApp.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdestAltoGiroApp.Infra.Mappins;

public class PersonMapping : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("person");
        builder.Property(p => p.Id).HasColumnName("id").IsRequired();
        builder.Property(p => p.Name).HasColumnName("name").IsRequired().HasMaxLength(255);
        builder.Property(p => p.Document).HasColumnName("document").IsRequired().HasMaxLength(50);
        builder.Property(p => p.Type).HasColumnName("type").IsRequired().HasMaxLength(20);
    }
}