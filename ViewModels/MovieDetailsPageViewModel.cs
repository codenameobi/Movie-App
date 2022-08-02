using System;
using System.Collections.ObjectModel;
using TimesNewsApp.Models;

namespace TimesNewsApp.ViewModels
{
    [QueryProperty(nameof(Movie), nameof(Movie))]
    public class MovieDetailsPageViewModel : BaseViewModel
    {
        public ObservableCollection<Result> Movie { get; }

        public MovieDetailsPageViewModel()
        {
        }
    }
}

