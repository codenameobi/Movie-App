using TimesNewsApp.ViewModels;

namespace TimesNewsApp.Views;

public partial class MovieListGenrePage : ContentPage
{
    private MovieListGenrePageViewModel viewModel => BindingContext as MovieListGenrePageViewModel;

	public MovieListGenrePage(MovieListGenrePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.InitializeAsync();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        viewModel.Close();
    }
}
