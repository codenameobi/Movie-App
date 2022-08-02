using TimesNewsApp.Views;

namespace TimesNewsApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(MovieDetailsPage),
			typeof(MovieDetailsPage));
	}
}

