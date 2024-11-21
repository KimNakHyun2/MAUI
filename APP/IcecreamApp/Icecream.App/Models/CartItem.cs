using CommunityToolkit.Mvvm.ComponentModel;

namespace Icecream.App.Models;

public partial class CartItem : ObservableObject
{
    public int Id { get; set; }
    public int IcecreamId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string FlavorName { get; set; }
    public string ToppingName { get; set; }

    [ObservableProperty, NotifyPropertyChangedFor(nameof (TotalPrice))]
    public int _quantity;

    public double TotalPrice => Price * Quantity;
}
