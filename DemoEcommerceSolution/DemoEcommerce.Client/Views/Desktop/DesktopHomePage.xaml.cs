using DemoEcommerce.Client.ViewModels;

namespace DemoEcommerce.Client.Views.Desktop
{
    public partial class DesktopHomePage : ContentPage
    {
        public DesktopHomePage(DesktopHomePageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}

