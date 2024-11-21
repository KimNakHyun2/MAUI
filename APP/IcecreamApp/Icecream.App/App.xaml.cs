using Icecream.App.Services;
using Icecream.App.ViewModels;

namespace Icecream.App
{
    public partial class App : Application
    {
        private readonly CartViewModel _cartViewModel;
        public App(AuthService authService, CartViewModel cartViewModel)
        {
            InitializeComponent();

            authService.Initialize();
            _cartViewModel = cartViewModel;

            MainPage = new AppShell(authService);
        }

        protected override async void OnStart()
        {
            await _cartViewModel.InitializeCartAsync();
        }

#if WINDOWS
        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);

            const int newWidth = 540;
            const int newHeight = 960;

            window.Width = newWidth;
            window.Height = newHeight;

            return window;
        }
#endif
    }
}
