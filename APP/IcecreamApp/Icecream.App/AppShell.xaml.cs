using Icecream.App.Pages;
using Icecream.App.Services;

namespace Icecream.App
{
    public partial class AppShell : Shell
    {
        private readonly AuthService _authService;
        public AppShell(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
            RegisterRoutes();
        }

        private readonly static Type[] _routablePageTypes =
            [
            typeof(SigninPage),
            typeof(SignupPage),
            typeof(MyOrdersPage),
            typeof(OrderDetailPage),
            typeof(DetailsPage),
            ];
        private static void RegisterRoutes()
        {
            foreach(var pageType in _routablePageTypes)
            {
                Routing.RegisterRoute(pageType.Name, pageType);
            }
            //Routing.RegisterRoute(nameof(SigninPage), typeof(SigninPage));
            //Routing.RegisterRoute(nameof(SignupPage), typeof(SignupPage));
        }

        private async void FooterTapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            await Launcher.OpenAsync("https://myhome/");
        }

        private async void SignoutMenuItem_Clicked(object sender, EventArgs e)
        {
            //await Shell.Current.DisplayAlert("Alert", "Signout menu item clicked", "OK");
            _authService.Signout();
            await Shell.Current.GoToAsync($"//{nameof(OnboardingPage)}");

        }
    }
}
