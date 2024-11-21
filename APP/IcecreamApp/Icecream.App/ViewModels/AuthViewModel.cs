using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Icecream.App.Pages;
using Icecream.App.Services;
using Icecream.Shared.Dtos;

namespace Icecream.App.ViewModels;

public partial class AuthViewModel(IAuthApi authApi, AuthService authService) : BaseViewModel
{
    private readonly IAuthApi _authApi = authApi;
    private readonly AuthService _authService = authService;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignup))]
    private string? _name;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignin)), NotifyPropertyChangedFor(nameof(CanSignup))]
    private string? _email;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignin)), NotifyPropertyChangedFor(nameof(CanSignup))]
    private string? _password;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignup))]
    private string? _address;

    public bool CanSignup => !string.IsNullOrEmpty(Name)
        && !string.IsNullOrEmpty(Email)
        && !string.IsNullOrEmpty(Password)
        && !string.IsNullOrEmpty(Address);

    public bool CanSignin => !string.IsNullOrEmpty(Password)
        && !string.IsNullOrEmpty(Email);

    [RelayCommand]
    private async Task SignupAsync()
    {
        IsBusy = true;
        try
        {
            var signupDto = new SignupRequestDto(Name, Email, Password, Address);
            // Make Api Call
            var result = await _authApi.SignupAsync(signupDto);

            if (result.IsSuccess)
            {
                // Navigate to HomePage
                _authService.Signin(result.Data);

             //   await ShowAlertAsync(result.Data.User.Name);
                await GotoAsync($"//{nameof(HomePage)}", animate: true);
            }
            else
            {
                // Display Error Alert
                await ShowErrorAlertAsync(result.ErrorMessage??"Unknown error in signing up");
            }
        }
        catch (Exception ex)
        {
            await ShowErrorAlertAsync(ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }


    [RelayCommand]
    private async Task SigninAsync()
    {
        IsBusy = true;
        try
        {
            var signinDto = new SigninRequestDto(Email, Password);
            // Make Api Call
            var result = await _authApi.SigninAsync(signinDto);

            if (result.IsSuccess)
            {
                // Navigate to HomePage
                _authService.Signin(result.Data);

                //await ShowAlertAsync(result.Data.User.Name);
                await GotoAsync($"//{nameof(HomePage)}", animate: true);
            }
            else
            {
                // Display Error Alert
                await ShowErrorAlertAsync(result.ErrorMessage ?? "Unknown error in signing in");
            }
        }
        catch (Exception ex)
        {
            await ShowErrorAlertAsync(ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
