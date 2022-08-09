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
        private Result _selectedMovie;

        public Movie Movie;

        NewsApiManager apiService;

        public MovieDetailsPageViewModel(NewsApiManager apiService)
        {
            this.apiService = apiService;    
        }
    }
}

