using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Newtonsoft.Json;
using TimesNewsApp.Models;
using TimesNewsApp.Services;

namespace TimesNewsApp.ViewModels
{
	public class PopularMoviePageViewModel : BaseViewModel
	{
        public ObservableCollection<Result> Movie { get; } = new();
		NewsApiManager apiService;

        public Command GetNewsComand { get; }

        public PopularMoviePageViewModel(NewsApiManager apiService)
		{

             
            Title = "Popluar Movies";
            this.apiService = apiService;
            GetNewsComand = new Command(async () => await GetMovieAsync());
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

