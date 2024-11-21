using Icecream.App.ViewModels;

namespace Icecream.App.Pages;

public partial class CartPage : ContentPage
{
	public CartPage(CartViewModel cartViewModel)
	{
		InitializeComponent();
		BindingContext = cartViewModel;
	}
}