using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Icecream.App.Controls;
using Icecream.App.Pages;
using Icecream.App.Services;

namespace Icecream.App.ViewModels;

public partial class ProfileViewModel : BaseViewModel
{
    private readonly AuthService _authService;
    private readonly ChangePasswordViewModel _changePasswordViewModel;

    public ProfileViewModel(AuthService authService, ChangePasswordViewModel changePasswordViewModel)
    {
        _authService = authService;
        this._changePasswordViewModel = changePasswordViewModel;
    }

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Initials))]
    private string _name = "";

    public string Initials
    {
        get
        {
            var parts = Name.Split(' ', StringSplitOptions.TrimEntries |  StringSplitOptions.RemoveEmptyEntries);
            if(parts.Length > 1)
            {
                return $"{parts[0][0]}{parts[1][0]}".ToUpper() ;
            }
            return Name.Length > 1 ? Name[..1]:Name.ToUpper() ;
        }
    }

    public void Initialize()
    {
        Name = _authService.User.Name;
    }

    [RelayCommand]
    private async Task SignoutAsync()
    {
        _authService.Signout();
        await GotoAsync($"//{nameof(OnboardingPage)}", animate:false);
    }

    [RelayCommand]
    private async Task GotoMyOrdersAsync() =>
        await GotoAsync(nameof(MyOrdersPage), animate:true);

    [RelayCommand]
    private async Task ChangePasswordAsync()
    {
        await Shell.Current.CurrentPage.ShowPopupAsync(new ChangePasswordControl(_changePasswordViewModel));
    }
        //await GotoAsync($"//{nameof()}")
}
