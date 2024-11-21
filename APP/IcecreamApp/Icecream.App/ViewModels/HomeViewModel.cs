using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Icecream.App.Pages;
using Icecream.App.Services;
using Icecream.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icecream.App.ViewModels;

public partial class HomeViewModel(IIcecreamApi icecreamApi, AuthService authService) : BaseViewModel
{
    private readonly IIcecreamApi _icecreamApi = icecreamApi;
    private readonly AuthService _authService = authService;

    [ObservableProperty]
    private IcecreamDto[] _icecreams = [];

    [ObservableProperty]
    private string _userName = string.Empty;

    private bool _isInitialized;
    public async Task InitializeAsync()
    {
        UserName = _authService.User.Name;

        if (_isInitialized)
            return;

        IsBusy = true;
        try
        {
            _isInitialized = true;

            // Make Api Call to fetch Icecreams
            Icecreams = await _icecreamApi.GetIcecreamsAsync();
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
    private async Task GoToDetailsPageAsync(IcecreamDto icecream)
    {
        var parameter = new Dictionary<string, object> 
        {
            [nameof(DetailsViewModel.Icecream)] = icecream,
        };
        //await Shell.Current.GoToAsync(nameof(DetailsPage), animate: true, parameter);
        await GotoAsync(nameof(DetailsPage), animate: true, parameter);
    }
}
