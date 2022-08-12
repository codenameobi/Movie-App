using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using TimesNewsApp.Models;
using TimesNewsApp.Services;
using TimesNewsApp.Views;

namespace TimesNewsApp.ViewModels
{
    public partial class OverviewPageViewModel : BaseViewModel
    { 
        public ObservableCollection<Genre> Genre { get; } = new();

        [ObservableProperty]
        Genre selectedGenre;

        FileService fileService;

        public Command SelectionCommand { get; }

        public OverviewPageViewModel(FileService fileService)
        {
            this.fileService = fileService;
            Title = "Movie Genres";
            GetGenreList();
            SelectionCommand = new Command(SelectGenre);
        }

        async void SelectGenre()
        {
            if (SelectedGenre == null)
                return;
            Console.WriteLine(SelectedGenre.Name);

            var route = $"{nameof(MovieListGenrePage)}";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    { "SelectedGenre", SelectedGenre }
                };
            await Shell.Current.GoToAsync(route, true,
                parameters
                );
        }

        async Task GetGenreList()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                List<Genre> genres = await fileService.GetGenreAsync();

                if (Genre.Count != 0)
                    Genre.Clear();

                foreach (var item in genres)
                    Genre.Add(item);
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

