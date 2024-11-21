using Icecream.App.Services;

namespace Icecream.App.Pages;

public partial class OnboardingPage : ContentPage
{
    private readonly AuthService _authService;
	public OnboardingPage(AuthService authService)
	{
		InitializeComponent();
        _authService = authService;

    }

    protected async override void OnAppearing()
    {
        // 이미 로그인 되어 있다면....
        if(_authService.User is not null 
            && _authService.User.Id != default
             && !string.IsNullOrWhiteSpace(_authService.Token))
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }

    private async void Signin_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SigninPage));
    }

    private async void Signup_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignupPage));
    }
}