using TimesNewsApp.Services;
using TimesNewsApp.ViewModels;

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
        builder.Services.AddTransient<NewsPageViewModel>();
        builder.Services.AddTransient<MovieReviewPage>();

        return builder.Build();
	}
}

