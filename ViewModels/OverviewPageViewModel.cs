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
        Genre _selectedGenreItem;

        FileService fileService;

        public Command GetGenre { get;}

        public OverviewPageViewModel(FileService fileService)
        {
            this.fileService = fileService;
            Title = "Homepage";
            GetGenre = new Command(SelectGenre);
            GetGenreList();
        }

        async void SelectGenre()
        {
            if (SelectedGenreItem == null)
                return;
            Console.WriteLine(SelectedGenreItem.Name);

            var route = $"{nameof(MovieGenreListPage)}";
            await Shell.Current.GoToAsync(route, true,
                new Dictionary<string, object>()
                {
                    { "SelectedGenre", SelectedGenreItem }
                }
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

