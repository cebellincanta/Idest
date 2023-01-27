using IdestAltoGiroApp.Infra.Mappins;
using Microsoft.EntityFrameworkCore;

namespace IdestAltoGiroApp.Infra.Context;

public class IdestAltoGiroContext : DbContext
{
    public IdestAltoGiroContext(DbContextOptions<IdestAltoGiroContext>options ) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new PersonMapping());
        modelBuilder.ApplyConfiguration(new AddressMapping());
        modelBuilder.ApplyConfiguration(new EmailMapping());
        modelBuilder.ApplyConfiguration(new PhoneMapping());
    }
}