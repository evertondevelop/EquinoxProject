using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

public static class AutoMapperConfig
{
    public static void AddAutoMapperConfiguration(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapperConfig));
    }
}

public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    // Other service registrations...

    // Configure AutoMapper
    AutoMapperConfig.AddAutoMapperConfiguration(services);
}
