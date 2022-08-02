using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TimesNewsApp.Models;
using TimesNewsApp.Services;

namespace TimesNewsApp.ViewModels
{
    [QueryProperty(nameof(MovieId), nameof(MovieId))]
    public class MovieDetailsPageViewModel : BaseViewModel
    {
        public string MovieId { get; set; }

        public Movie Movie;

        NewsApiManager apiService;

        public MovieDetailsPageViewModel(NewsApiManager apiService)
        {
            this.apiService = apiService;

        }

        async Task GetMovieAsync(String MovieId)
        {
            //if (IsBusy)
            //    return;

            try
            {
                IsBusy = true;

                Movie movies = await apiService.SelectedMovie(MovieId);

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

