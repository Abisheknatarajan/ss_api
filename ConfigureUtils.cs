using Repository;
using UseCaseInterfaces;
using UseCases;
using Services;
using ServiceInterfaces;

namespace DependencyInjection;

public static class ConfigureUtils
{
    public static void SetDI(IServiceCollection service)
    {
        SetUseCase(service);
        SetService(service);
        SetRepository(service);
    }

    private static void SetUseCase(IServiceCollection services)
    {
        services.AddScoped<IHomeUseCase, HomeUseCase>();
        services.AddScoped<ILoginAuthenticationUseCase, LoginAuthenticationUseCase>();
        services.AddScoped<IRemoteRegisterUseCase, RemoteRegisterUseCase>();
    }

    private static void SetService(IServiceCollection services)
    {
        services.AddScoped<IHomeService, HomeService>();
        services.AddScoped<ILoginAuthenticationService, LoginAuthenticationService>();
        services.AddScoped<IRemoteRegisterService, RemoteRegisterService>();

    }

    private static void SetRepository(IServiceCollection services)
    {
        services.AddScoped<IHomeRepository, HomeRepository>();
        services.AddScoped<ILoginAuthenticationRepository, LoginAuthenticationRepository>();
        services.AddScoped<IRemoteRegisterRepository, RemoteRegisterRepository>();

    }
}