using TimesNewsApp.ViewModels;

namespace TimesNewsApp.Views;

public partial class OverviewPage : ContentPage
{
	public OverviewPage(OverviewPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
