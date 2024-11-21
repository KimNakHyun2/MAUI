using Icecream.App.ViewModels;

namespace Icecream.App.Pages;

public partial class ProfilePage : ContentPage
{
	private readonly ProfileViewModel _profileViewModel;
	public ProfilePage(ProfileViewModel profileViewModel)
	{
		InitializeComponent();
		BindingContext = _profileViewModel = profileViewModel;

    }

    protected override void OnAppearing()
    {
        _profileViewModel.Initialize();
    }
}