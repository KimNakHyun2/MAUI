using CommunityToolkit.Maui;
using Icecream.App.Pages;
using Icecream.App.Services;
using Icecream.App.ViewModels;
using Microsoft.Extensions.Logging;
using Refit;

#if ANDROID
using System.Net.Security;
using Xamarin.Android.Net;
#elif IOS
using Security;
#endif

namespace Icecream.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureMauiHandlers(h =>
                {
#if ANDROID || IOS
                    h.AddHandler<Shell, TabbarBadgeRenderer>();
#endif
                }
                )
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<DatabaseService>();

            builder.Services.AddTransient<AuthViewModel>()
                .AddTransient<SignupPage>()
                .AddTransient<SigninPage>();

            builder.Services.AddSingleton<AuthService>();
            builder.Services.AddTransient<OnboardingPage>();
            builder.Services.AddSingleton<HomeViewModel>()
                .AddSingleton<HomePage>();

            builder.Services.AddTransient<DetailsViewModel>()
                .AddTransient<DetailsPage>();

            builder.Services.AddSingleton<CartViewModel>()
                .AddTransient<CartPage>();

            builder.Services.AddTransient<ProfileViewModel>()
                .AddTransient<ProfilePage>();

            builder.Services.AddTransient<OrderViewModel>()
                .AddTransient<MyOrdersPage>();

            builder.Services.AddTransient<OrderDetailViewModel>()
                .AddTransient<OrderDetailPage>();

            builder.Services.AddTransient<ChangePasswordViewModel>();


            ConfigureRefit(builder.Services);

            return builder.Build();
        }

        private static void ConfigureRefit(IServiceCollection services)
        {
            

            services.AddRefitClient<IAuthApi>(GetRefitSetting)
                .ConfigureHttpClient(SetHttpClient);

            services.AddRefitClient<IIcecreamApi>(GetRefitSetting)
                .ConfigureHttpClient(SetHttpClient);

            services.AddRefitClient<IOrderApi>(GetRefitSetting)
                .ConfigureHttpClient(SetHttpClient);

            static void SetHttpClient(HttpClient httpClient)
            {
                var baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                    ? "https://10.0.2.2:7282" : "https://localhost:7282";

                if (DeviceInfo.DeviceType == DeviceType.Physical)
                {
                    baseUrl = "https://82s5gr41-7282.asse.devtunnels.ms";
                }
                httpClient.BaseAddress = new Uri(baseUrl);
            }

            static RefitSettings GetRefitSetting(IServiceProvider serviceProvider)
            {
                var authService = serviceProvider.GetRequiredService<AuthService>();

                var refitSettings = new RefitSettings
                {
                    HttpMessageHandlerFactory = () =>
                    {
#if ANDROID
                        return new AndroidMessageHandler
                        {
                            ServerCertificateCustomValidationCallback = (httpRequestMessage, certificate, chain, sslPolicyErrors) =>
                            {

                                return certificate?.Issuer == "CN=localhost" || sslPolicyErrors == SslPolicyErrors.None;
                            }
                        };
#elif IOS
                    return new NSUrlSessionHandler
                    {
                        TrustOverrideForUrl = (NSUrlSessionHandler sender, string url, SecTrust trust) =>
                        url.StartsWith("https://localhost")
                    };
#endif
                        return null;
                    },
                    AuthorizationHeaderValueGetter = (_, __) => 
                        Task.FromResult(authService.Token ?? string.Empty)
                };

                return refitSettings;
            }
        }
    }
}
