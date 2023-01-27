using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using IdestAltoGiroApp.IoC;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using Serilog;

namespace IdestAltoGiroApp.Api;
[ExcludeFromCodeCoverage]
public class Application
{
    public static void Init(string[] args)
    {
        var builder = WebApplication.CreateBuilder();

        builder.Host.UseSerilog();
        builder.Configuration.AddEnvironmentVariables();
        builder.Services.Register(builder.Configuration);

        builder.Services.AddControllers()          
        .AddJsonOptions(
            options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            }
        );
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddHealthChecks();

        builder.Services.Configure<JsonOptions>(
            options =>
            {
                options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.SerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                options.SerializerOptions.PropertyNameCaseInsensitive = true;
                options.SerializerOptions.WriteIndented = true;
                options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
            }
        );

        builder.Services.AddApiVersioning(
            options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            }
        );

        builder.Services.AddSwaggerGen(
        s =>
        {
            s.CustomSchemaIds(type => type.ToString());
            s.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Teste Back-End Idest/GiroAlto",
                        Description = "Api Crud Teste",
                        Version = "v1"

                    }
                );
        });

         var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI(
            options =>
            {
                options.SwaggerEndpoint($"/swagger/v1/swagger.json", $"v1");
            }
        );


        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }

}
