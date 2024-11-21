using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Icecream.App.Pages;
using Icecream.App.Services;
using Icecream.Shared.Dtos;
using Refit;

namespace Icecream.App.ViewModels;

public partial class OrderViewModel : BaseViewModel
{
    private readonly AuthService _authService;
    private readonly IOrderApi _orderApi;

    public OrderViewModel(AuthService authService, IOrderApi orderApi)
    {
        _authService = authService;
        _orderApi = orderApi;
    }

    [ObservableProperty]
    private OrderDto[] _orders = [];

    public async Task InitialzeAsync() => await LoadOrderAsync();

    [RelayCommand]
    private async Task LoadOrderAsync()
    {
        IsBusy = true;

        try
        {
            Orders = await _orderApi.GetMyOrdersAsync();
            if (Orders.Length == 0)
            {
                await ShowToastAsync("No orders found");
            }
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

    [RelayCommand]
    private async Task GoToOrderDetailsPageAsync(long orderId)
    {
        var parameter = new Dictionary<string, object>
        {
            [nameof(OrderDetailViewModel.OrderId)] = orderId,
        };

        await GotoAsync(nameof(OrderDetailPage), animate: true, parameter);
    }
}
