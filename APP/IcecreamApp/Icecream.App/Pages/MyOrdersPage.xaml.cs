using Icecream.App.ViewModels;

namespace Icecream.App.Pages;

public partial class MyOrdersPage : ContentPage
{
    private readonly OrderViewModel _orderViewModel;

    public MyOrdersPage(OrderViewModel orderViewModel)
	{
		InitializeComponent();
		BindingContext = _orderViewModel = orderViewModel;

    }

    protected override async void OnAppearing()
    {
        await _orderViewModel.InitialzeAsync();
    }
}