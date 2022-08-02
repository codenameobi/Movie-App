using TimesNewsApp.ViewModels;

namespace TimesNewsApp.Views;

public partial class MovieDetailsPage : ContentPage
{
	public MovieDetailsPage(MovieDetailsPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
