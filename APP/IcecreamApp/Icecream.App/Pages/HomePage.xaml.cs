using Icecream.App.ViewModels;

namespace Icecream.App.Pages;

public partial class HomePage : ContentPage
{
	private readonly HomeViewModel _homeViewModel;

    public HomePage(HomeViewModel homeViewModel)
	{
		InitializeComponent();
		BindingContext = _homeViewModel = homeViewModel;

    }

    protected async override void OnAppearing()
    {
        await _homeViewModel.InitializeAsync();
    }
}