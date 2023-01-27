using IdestAltoGiroApp.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdestAltoGiroApp.IoC.Configuration;
public static class DbConfiguration
{
    public static string GetConnectString(IConfiguration configuration)
    {
        var connetionString = configuration.GetConnectionString("IdestAltoGiroAppContext");

        if(!string.IsNullOrEmpty(connetionString))
            return connetionString;

        return string.Empty;
    }

    public static void  AddDBContextConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdestAltoGiroContext>(
            options =>
            {
                var connectionString = GetConnectString(configuration);
                options.UseNpgsql(connectionString);
            }
        );
    }
}