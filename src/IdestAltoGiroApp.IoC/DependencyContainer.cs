using IdestAlgotGiroApp.Application.Interface;
using IdestAlgotGiroApp.Application.Notification;
using IdestAlgotGiroApp.Application.Service;
using IdestAltoGiroApp.Domain.Interface;
using IdestAltoGiroApp.Domain.Interface.Base;
using IdestAltoGiroApp.Infra.Repository;
using IdestAltoGiroApp.Infra.Repository.Base;
using IdestAltoGiroApp.IoC.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdestAltoGiroApp.IoC;

public static class DependencyContainer
{
    public static void Register(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterContext(services, configuration);
        Configure(services);
        RegisterRepository(services);
    }

    public static void RegisterContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDBContextConfiguration(configuration);
    }

    public static void Configure(IServiceCollection services)
    {
        services.AddTransient<IPersonService, PersonService>();
        services.AddScoped<INotificationService, NotificationService>();
    }
    public static void RegisterRepository(IServiceCollection services)
    {
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IEmailRepository, EmailRepository>();
        services.AddScoped<IPhoneRepository, PhoneRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}