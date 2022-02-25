using FluentValidation;
using KOS.Core.Repositories;
using KOS.DAL;
using KOS.DAL.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KOS.Business;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("connectionStr"),
                sqlOptions =>
                {
                    sqlOptions
                        .EnableRetryOnFailure(
                            1,
                            TimeSpan.FromSeconds(10),
                            null);
                });
        }, ServiceLifetime.Transient, ServiceLifetime.Singleton);
    }

    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        return services.AddTransient<IBookRepository, BookRepository>()
            .AddTransient<IUserRepository, UserRepository>()
            .AddTransient<IRoleRepository, RoleRepository>()
            .AddTransient<IUserRoleRepository, UserRoleRepository>();
    }

    public static void AddBusinessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly())
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}