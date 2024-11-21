using Icecream.App.ViewModels;

namespace Icecream.App.Pages;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(DetailsViewModel detailViewModel)
	{
		InitializeComponent();
		BindingContext = detailViewModel;
	}
}