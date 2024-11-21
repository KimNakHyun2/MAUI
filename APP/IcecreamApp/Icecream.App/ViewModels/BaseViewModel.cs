
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using Icecream.App.Pages;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icecream.App.ViewModels;
public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isBusy;

    protected async Task GotoAsync(string url, bool animate)
    {
        await Shell.Current.GoToAsync(url, animate);
    }

    protected async Task GotoAsync(string url, bool animate, IDictionary<string, object> parameters)
    {
        await Shell.Current.GoToAsync(url, animate, parameters);
    }

    protected async Task ShowErrorAlertAsync(string errorMessage)
    {
        await Shell.Current.DisplayAlert("Error", errorMessage, "Ok");
    }

    protected async Task ShowAlertAsync(string message)
    {
        await Shell.Current.DisplayAlert("Alert", message, "Ok");
    }

    protected async Task ShowAlertAsync(string title, string message)
    {
        await Shell.Current.DisplayAlert(title, message, "Ok");
    }

    protected async Task ShowToastAsync(string message)
    {
        await Toast.Make(message).Show();
    }

    protected async Task<bool> ConfirmAsync(string title, string message)
    {
        return await Shell.Current.DisplayAlert(title, message, "Yes", "No");
    }

    protected async Task HandleApiExceptionAsync(ApiException ex, Action? signout)
    {
        if (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            // User is not logged in
            await ShowErrorAlertAsync("Session Expired");
            //_authService.Signout();
            signout?.Invoke();

            await GotoAsync($"//{nameof(OnboardingPage)}", animate: false);
            return;
        }

        await ShowErrorAlertAsync(ex.Message);
    }

}
