using Icecream.Shared.Dtos;
using Refit;

namespace Icecream.App.Services;

public interface IIcecreamApi
{
    [Get("/api/icecreams")]
    Task<IcecreamDto[]> GetIcecreamsAsync();
}