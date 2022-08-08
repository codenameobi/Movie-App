using TimesNewsApp.ViewModels;

namespace TimesNewsApp.Views;

public partial class MovieGenreListPage : ContentPage
{
	public MovieGenreListPage(MovieGenreListPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
