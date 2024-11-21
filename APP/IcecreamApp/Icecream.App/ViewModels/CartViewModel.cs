using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Icecream.App.Models;
using Icecream.App.Pages;
using Icecream.App.Services;
using Icecream.Shared.Dtos;
using Refit;
using System.Collections.ObjectModel;

namespace Icecream.App.ViewModels;

public partial class CartViewModel : BaseViewModel
{
    private readonly DatabaseService _databaseService;
    private readonly IOrderApi _orderApi;
    private readonly AuthService _authService;
    public CartViewModel(DatabaseService databaseService, IOrderApi orderApi, AuthService authService)
    {
        _databaseService = databaseService;
        _orderApi = orderApi;
        _authService = authService;
    }

    public ObservableCollection<CartItem> CartItems { get; set; } = [];

    public static int TotalCartCount { get; set; }
    public static event EventHandler<int>? TotalCartCountChanged;

    public async void AddItemToCart(IcecreamDto icecream, int quantity, string flavor, string topping)
    {
        var existingItem = CartItems.FirstOrDefault(ci => ci.IcecreamId == icecream.Id);
        if ((existingItem is not null))
        {
            var dbCartItem = await _databaseService.GetCartItemAsync(existingItem.Id);
            if (quantity <= 0)
            {
                await _databaseService.DeleteCartItem(dbCartItem);

                CartItems.Remove(existingItem);
                await ShowToastAsync("Icecream removed from the cart");
            }
            else
            {
                
                dbCartItem.Quantity = quantity;
                await _databaseService.UpdateCartItem(dbCartItem);

                existingItem.Quantity = quantity;
                await ShowToastAsync("Quantity updated in the cart");
            }
        }
        else
        {
            var cartItem = new CartItem
            {   
                IcecreamId = icecream.Id,
                Id = icecream.Id,
                Name = icecream.Name,
                Price = icecream.Price,
                Quantity = quantity,
                FlavorName = flavor,
                ToppingName = topping,
            };

            
            // sqlite 에 기록
            var entity = new Data.CartItemEntity(cartItem);
            await _databaseService.AddCartItem(entity);

            // sqlite id를 저장.
            cartItem.Id = entity.Id;

            CartItems.Add(cartItem);
            await ShowToastAsync("Icecream added to cart");
        }

        NotifyCartCountChange();
    }

    private void NotifyCartCountChange()
    {
        TotalCartCount = CartItems.Sum(i => i.Quantity);
        TotalCartCountChanged?.Invoke(null, TotalCartCount);
    }
    public int GetItemCartCount(int icecreamId)
    {
        var existingItem = CartItems.FirstOrDefault(i => i.IcecreamId == icecreamId);
        return existingItem?.Quantity?? 0;
    }

    public async Task InitializeCartAsync()
    {
        var dbItems = await _databaseService.GetAllCartItemAsync();
        foreach (var dbItem in dbItems)
        {
            CartItems.Add(dbItem.ToCartItemModel());
        }
        NotifyCartCountChange();
    }

    [RelayCommand]
    private async Task ClearCartAsync()
    {
        await ClearCartInternalAsync(fromPlaceOrder:false);
    }

    private async Task ClearCartInternalAsync(bool fromPlaceOrder)
    {
        if (!fromPlaceOrder && CartItems.Count == 0)
        {
            await ShowAlertAsync("Empty Cart", "There's no items in the cart");
            return;
        }

        if (fromPlaceOrder 
            || await ConfirmAsync("Clear Cart?", "Do you really want to clear all the items from the cart"))
        {
            await _databaseService.ClearCartAsync();
            CartItems.Clear();

            if(!fromPlaceOrder)
                await ShowToastAsync("Cart cleared");

            NotifyCartCountChange();
        }
    }

    [RelayCommand]
    private async Task RemoveCartItemAsync(int cartItemId)
    {

        if (await ConfirmAsync("Remove item from  Cart?", "Do you really want to delete this item items from the cart"))
        {
            var existingItem = CartItems.FirstOrDefault(i => i.Id == cartItemId);
            if ((existingItem is null))
            {
                return;
            }

            CartItems.Remove(existingItem);

            var dbCartItem = await _databaseService.GetCartItemAsync(existingItem.Id);
            if ((dbCartItem is null))
            {
                return;
            }
            await _databaseService.DeleteCartItem(dbCartItem);

            await ShowToastAsync("Icecream removed from cart");
            NotifyCartCountChange();
        }
    }

    [RelayCommand]
    private async Task PlaceOrderAsync()
    {
        if(CartItems.Count == 0)
        {
            await ShowAlertAsync("Empty Cart", "Please, Add some items to cart");
            return;
        }

        IsBusy = true;
        try
        {
            var order = new OrderDto(0, DateTime.Now, CartItems.Sum(i => i.TotalPrice));
            var orderItems = CartItems.Select(i => new OrderItemDto(0, i.IcecreamId,i.Name, i.Quantity, i.Price, i.FlavorName, i.ToppingName)).ToArray();
            var orderPlaceDto = new OrderPlaceDto(order, orderItems);
            var result = await _orderApi.PlaceOrderAsync(orderPlaceDto);

            if (!result.IsSuccess)
            {
                await ShowErrorAlertAsync(result.ErrorMessage!);
                return;
            }

            // 성공이라면
            // 카드 지우기
            // 성공 메시지 보여주기.
            await ShowToastAsync("Order placed successful!!");
            await ClearCartInternalAsync(fromPlaceOrder: true);
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
