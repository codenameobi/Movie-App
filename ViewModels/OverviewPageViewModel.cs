using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TimesNewsApp.Models;
using TimesNewsApp.Services;

namespace TimesNewsApp.ViewModels
{
    public partial class OverviewPageViewModel : BaseViewModel
    { 
        public ObservableCollection<Genre> Genre { get; } = new();

        FileService fileService;

        public Command GetGenre { get; set; }

        public OverviewPageViewModel(FileService fileService)
        {
            this.fileService = fileService;
            Title = "Homepage";
            GetGenreList();
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

