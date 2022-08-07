using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using TimesNewsApp.Models;
using TimesNewsApp.Services;
using TimesNewsApp.Views;

namespace TimesNewsApp.ViewModels
{
    public partial class MoviesViewModel : BaseViewModel
    {
        public ObservableCollection<Result> Movie { get; } = new();
        NewsApiManager apiService;

        [ObservableProperty]
        Result _selectedMovieItem;

        public Command GetMovieComand { get; }
        public Command SelectionChangedCommand { get; }

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


        async Task GetMovieAsync(String SearchText)
        {
            //if (IsBusy)
            //    return;

            try
            {
                IsBusy = true;

                Movie movies = await apiService.GetMovie(SearchText);

                if (Movie.Count != 0)
                    Movie.Clear();

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

