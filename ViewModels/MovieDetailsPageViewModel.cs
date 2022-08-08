using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using TimesNewsApp.Models;
using TimesNewsApp.Services;

namespace TimesNewsApp.ViewModels
{
    [QueryProperty(nameof(SelectedMovie), nameof(SelectedMovie))]
    public partial class MovieDetailsPageViewModel : BaseViewModel
    {

        [ObservableProperty]
        Result _selectedMovie;

        public Movie Movie;

        NewsApiManager apiService;

        public MovieDetailsPageViewModel(NewsApiManager apiService)
        {
            this.apiService = apiService;

        }



        async Task GetMovie(Result SelectedMovieItem)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                string movieId = SelectedMovieItem.id.ToString();
                Movie movies = await apiService.SelectedMovie(movieId);
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

