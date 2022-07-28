using TimesNewsApp.ViewModels;

namespace TimesNewsApp.Views;

public partial class MovieSearchPage : ContentPage
{
	public MovieSearchPage(MoviesViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
