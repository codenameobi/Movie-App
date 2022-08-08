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
		builder.Services.AddSingleton<FileService>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<PopularMoviePageViewModel>();
        builder.Services.AddTransient<MovieReviewPage>();
        builder.Services.AddTransient<MovieSearchPage>();
        builder.Services.AddTransient<MoviesViewModel>();
        builder.Services.AddTransient<MovieDetailsPage>();
        builder.Services.AddTransient<MovieDetailsPageViewModel>();
		builder.Services.AddTransient<OverviewPage>();
		builder.Services.AddTransient<OverviewPageViewModel>();
        builder.Services.AddTransient<MovieGenreListPage>();
        builder.Services.AddTransient<MovieGenreListPageViewModel>();

        return builder.Build();
	}
}

