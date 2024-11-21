using Icecream.App.ViewModels;

namespace Icecream.App.Pages;

public partial class OrderDetailPage : ContentPage
{
	private readonly OrderDetailViewModel _orderDetailViewModel;
    public OrderDetailPage(OrderDetailViewModel orderDetailViewModel)
	{
		InitializeComponent();
		BindingContext = _orderDetailViewModel = orderDetailViewModel;

    }
}