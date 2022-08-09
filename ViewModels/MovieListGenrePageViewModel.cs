using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using TimesNewsApp.Models;
using TimesNewsApp.Services;

namespace TimesNewsApp.ViewModels
{
    [QueryProperty(nameof(SelectedGenre), nameof(SelectedGenre))]
    public partial class MovieListGenrePageViewModel : BaseViewModel
    {
        public ObservableCollection<Result> Movie { get;} = new();

        [ObservableProperty]
        private Genre selectedGenre;

        int genreId;

        NewsApiManager apiService;

        public Command GetMovieComand { get; }

        public MovieListGenrePageViewModel(NewsApiManager apiService)
        {
            this.apiService = apiService;
        }

        internal async Task InitializeAsync()
        {
            
            await GetMovies();
        }

        internal void Close()
        {
            SelectedGenre = new();
        }

        async Task GetMovies()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                Movie movies = await apiService.GetMovieByGenre(SelectedGenre.Id);
                if (Movie.Count != 0)
                    return;
                foreach (var item in movies.results)
                    Movie.Add(item);
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

