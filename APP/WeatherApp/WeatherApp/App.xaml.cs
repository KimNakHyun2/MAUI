namespace WeatherApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
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
