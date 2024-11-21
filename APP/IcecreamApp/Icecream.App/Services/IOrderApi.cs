using Icecream.Shared.Dtos;
using Refit;

namespace Icecream.App.Services;

[Headers("Authorization Bearer")]
public interface IOrderApi
{
    [Post("/api/order/place-order")]
    Task<ResultDto> PlaceOrderAsync(OrderPlaceDto dto);

    [Get("/api/orders")]
    Task<OrderDto[]> GetMyOrdersAsync();

    [Get("/api/orders/{orderId}/items")]
    Task<OrderItemDto[]> GetUserOrderItemsAsync(long orderId);
}
