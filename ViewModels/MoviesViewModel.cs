using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using TimesNewsApp.Models;
using TimesNewsApp.Services;

namespace TimesNewsApp.ViewModels
{
    public partial class MoviesViewModel : BaseViewModel
    {
        public ObservableCollection<Movie> Movie { get; } = new();
        NewsApiManager apiService;

        public Command GetMovieComand { get; }

        private string searchText;

        public string SearchText
        {
            get => searchText;
            set => SetProperty(ref searchText, value);
        }

    public MoviesViewModel(NewsApiManager apiService)
        {
            Title = "Search Movie";
            this.apiService = apiService;
            GetMovieComand = new Command(async () => await GetMovieAsync(SearchText));
        }



        async Task GetMovieAsync(String SearchText)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var movie = await apiService.GetMovie(SearchText);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get movie: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

