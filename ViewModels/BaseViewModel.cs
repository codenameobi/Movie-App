﻿using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TimesNewsApp.ViewModels
{
	public partial class BaseViewModel : ObservableObject
	{
        [ObservableProperty]
        [AlsoNotifyChangeFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;
    }
}

