using TimesNewsApp.ViewModels;

namespace TimesNewsApp;

public partial class MainPage : ContentPage
{
	public MainPage(PopularMoviePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}


