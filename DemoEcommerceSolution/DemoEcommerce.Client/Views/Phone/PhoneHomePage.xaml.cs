using DemoEcommerce.Client.ViewModels;

namespace DemoEcommerce.Client.Views.Phone;

public partial class PhoneHomePage : ContentPage
{
	public PhoneHomePage(PhoneHomePageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}