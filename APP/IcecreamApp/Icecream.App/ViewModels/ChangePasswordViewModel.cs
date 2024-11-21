using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Icecream.App.Services;
using Icecream.Shared.Dtos;
using Refit;

namespace Icecream.App.ViewModels;

public partial class ChangePasswordViewModel : BaseViewModel
{
    private readonly AuthService _authService;
    private readonly IAuthApi _authApi;

    public ChangePasswordViewModel(AuthService authService, IAuthApi authApi)
    {
        this._authService = authService;
        this._authApi = authApi;
    }

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CanChangePassword))]
    private string? _oldPassword;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CanChangePassword))]
    private string? _newPassword;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CanChangePassword))]
    private string? _confirmNewPassword;

    public bool CanChangePassword => !string.IsNullOrWhiteSpace(OldPassword)
        && !string.IsNullOrWhiteSpace(NewPassword)
        && !string.IsNullOrWhiteSpace(ConfirmNewPassword);

    [RelayCommand]
    private async Task ChangePasswordAsync()
    {
        if (NewPassword != ConfirmNewPassword)
        {
            await ShowErrorAlertAsync("New password and confirm new password do not match");
            return;
        }

        IsBusy = true;
        try
        {
            var dto = new ChangePasswordDto(OldPassword!, NewPassword!);
            var result = await _authApi.ChangePasswordAsync(dto);
            if (!result.IsSuccess)
            {
                await ShowErrorAlertAsync(result.ErrorMessage!);
                return;
            }

            await ShowAlertAsync("Success", "Password changed successfully");
            OldPassword = NewPassword = ConfirmNewPassword = null;
        }
        catch (ApiException ex)
        {
            await HandleApiExceptionAsync(ex, () => _authService.Signout());
        }
        finally
        {
            IsBusy = false;
        }
    }

}
