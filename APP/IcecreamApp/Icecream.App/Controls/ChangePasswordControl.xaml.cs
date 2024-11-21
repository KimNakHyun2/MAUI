using CommunityToolkit.Maui.Views;
using Icecream.App.ViewModels;

namespace Icecream.App.Controls;

public partial class ChangePasswordControl : Popup
{
    private readonly ChangePasswordViewModel _changePasswordViewModel;

    public ChangePasswordControl(ChangePasswordViewModel changePasswordViewModel)
	{
		InitializeComponent();
        BindingContext = this._changePasswordViewModel = changePasswordViewModel;
    }

    private async void ClosePopup_Tapped(object sender, TappedEventArgs e)
    {
        await CloseAsync();
    }
}