using FilmDb.Adapter.Out.Persistence;
using FilmDb.Application;
using FilmDb.Application.Port.In;
using FilmDb.Application.Port.Out;
using Microsoft.Extensions.DependencyInjection;

namespace FilmDb;

public static class Module
{
    public static void AddFilmDb(this IServiceCollection services)
    {
        services.AddSingleton<StaticFilmRepository>();
        services.AddSingleton<IFilmRepository, StaticFilmRepository>();
        services.AddSingleton<IGetFilmUseCase, FilmService>();
        services.AddSingleton<IAllFilmsUseCase, FilmService>();
        services.AddSingleton<ISaveFilmUseCase, FilmService>();
    }
}