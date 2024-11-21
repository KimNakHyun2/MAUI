using CommunityToolkit.Mvvm.ComponentModel;
using Icecream.App.ViewModels;

namespace Icecream.App.Models;

public partial class IcecreamOption : BaseViewModel
{
    public string Flavor { get; set; }
    public string Topping { get; set; }

    [ObservableProperty]
    private bool _isSelected;
}
