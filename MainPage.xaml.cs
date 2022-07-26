using TimesNewsApp.ViewModels;

namespace TimesNewsApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage(NewsPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}


