public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    // Other service registrations...

    // Configure AutoMapper
    AutoMapperConfig.AddAutoMapperConfiguration(services);
}
