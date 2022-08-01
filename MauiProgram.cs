using TimesNewsApp.Services;
using TimesNewsApp.ViewModels;
using TimesNewsApp.Views;

namespace TimesNewsApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<NewsApiManager>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<PopularMoviePageViewModel>();
        builder.Services.AddTransient<MovieReviewPage>();
        builder.Services.AddTransient<MovieSearchPage>();
        builder.Services.AddTransient<MoviesViewModel>();

        return builder.Build();
	}
}

