using Icecream.App.ViewModels;

namespace Icecream.App.Pages;

public partial class SigninPage : ContentPage
{
	public SigninPage(AuthViewModel authViewModel)
	{
		InitializeComponent();
		BindingContext = authViewModel;
	}

    private async void Signup_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignupPage));
    }

}