using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using TimesNewsApp.Models;
using TimesNewsApp.Services;

namespace TimesNewsApp.ViewModels
{
    [QueryProperty(nameof(SelectedGenre), nameof(SelectedGenre))]
    public partial class MovieGenreListPageViewModel : BaseViewModel
    {
        public ObservableCollection<Result> Movie { get; set; } = new();

        [ObservableProperty]
        public Genre selectedGenre;
        NewsApiManager apiService;

        public MovieGenreListPageViewModel(NewsApiManager apiService)
        {
            this.apiService = apiService;
            GetMovies(SelectedGenre);

        }

        async Task GetMovies(Genre SelectedGenre)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                string genreId = SelectedGenre.Id.ToString();
                Movie movies = await apiService.GetMovieByGenre(genreId);
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

