using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TimesNewsApp.Models;
using TimesNewsApp.Services;

namespace TimesNewsApp.ViewModels
{
	public class NewsPageViewModel : BaseViewModel
	{
        public ObservableCollection<NewsModel> News { get; } = new();
		NewsApiManager apiService;

        public Command GetNewsComand { get; }

        public NewsPageViewModel(NewsApiManager apiService)
		{
            Title = "Top News";
            this.apiService = apiService;
            GetNewsComand = new Command(async () => await GetNewsAsync());
        }

        async Task GetNewsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var news = await apiService.GetTopNews();

                if (News.Count != 0)
                    News.Clear();

                foreach (var item in news)
                    News.Add(item);
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

