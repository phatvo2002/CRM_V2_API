using Microsoft.Extensions.DependencyInjection;
using MediatR;
using CRM.Application.Features.V1.SystemManagements.Role.Mapper;
using AutoMapper;

namespace CRM.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddAutoMapper(
         typeof(Role_MapperProfile).Assembly);
        return services;
    }
}