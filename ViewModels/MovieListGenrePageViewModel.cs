using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using TimesNewsApp.Models;
using TimesNewsApp.Services;
using TimesNewsApp.Views;

namespace TimesNewsApp.ViewModels
{
    [QueryProperty(nameof(SelectedGenre), nameof(SelectedGenre))]
    public partial class MovieListGenrePageViewModel : BaseViewModel
    {
        public ObservableCollection<Result> Movie { get;} = new();

        [ObservableProperty]
        private Genre selectedGenre;

        [ObservableProperty]
        private Result selectedMovieItem;

        int genreId;

        NewsApiManager apiService;

        public Command GetMovieComand { get; }
        public Command SelectionChangedCommand { get; }

        public MovieListGenrePageViewModel(NewsApiManager apiService)
        {
            this.apiService = apiService;
            SelectionChangedCommand = new Command(SelectedMovie);
        }

        async void SelectedMovie()
        {
            if (SelectedMovieItem == null)
                return;
            Console.WriteLine(SelectedMovieItem);

            var route = $"{nameof(MovieDetailsPage)}";
            await Shell.Current.GoToAsync(route, true,
                new Dictionary<string, object>()
                {
                    { "SelectedMovie", SelectedMovieItem }
                }

                );
        }

        internal async Task InitializeAsync()
        {
            await GetMovies(SelectedGenre);
        }

        async Task GetMovies(Genre SelectedGenre)
        {
            if (IsBusy)
                return;
            try
            {

                IsBusy = true;

                if (Movie.Count != 0)
                    Movie.Clear();

                Movie movies = await apiService.GetMovieByGenre(SelectedGenre.Id);
                
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

