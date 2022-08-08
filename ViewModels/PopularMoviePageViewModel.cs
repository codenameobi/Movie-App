using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using TimesNewsApp.Models;
using TimesNewsApp.Services;
using TimesNewsApp.Views;

namespace TimesNewsApp.ViewModels
{
	public partial class PopularMoviePageViewModel : BaseViewModel
	{
        public ObservableCollection<Result> Movie { get; } = new();

        [ObservableProperty]
        Result _selectedMovieItem;
        

        NewsApiManager apiService;

        public Command GetMoviesComand { get; }
        public Command SelectionChangedCommand { get; }


        public PopularMoviePageViewModel(NewsApiManager apiService)
		{

             
            Title = "Popluar Movies";
            this.apiService = apiService;
            GetMovieAsync();
            SelectionChangedCommand = new Command(SelectedMovie);
        }

        async void SelectedMovie()
        {
            if (SelectedMovieItem == null)
                return;
            Console.WriteLine(SelectedMovieItem);

            var route = $"{nameof(MovieDetailsPage)}";
            await Shell.Current.GoToAsync(route,true,
                new Dictionary<string, object>()
                {
                    { "SelectedMovie", SelectedMovieItem }
                }
                
                );
        }

        async Task GetMovieAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                Movie movies = await apiService.GetPopularMovie();

                if (Movie.Count != 0)
                    Movie.Clear();

                foreach (var item in movies.results)
                    Movie.Add(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

