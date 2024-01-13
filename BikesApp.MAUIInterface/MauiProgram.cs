using Microsoft.Extensions.Logging;
using SztuderWiniecki.BikesApp.MAUIInterface.ViewModels;

namespace BikesApp.MAUIInterface
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<ProducersCollectionViewModel>();
            builder.Services.AddSingleton<ProducersIndexPage>();

            builder.Services.AddTransient<ProducerCreateViewModel>();
            builder.Services.AddTransient<ProducerCreatePage>();

            builder.Services.AddTransient<ProducerDetailsViewModel>();
            builder.Services.AddTransient<ProducerDetailsPage>();

            Routing.RegisterRoute(nameof(ProducerCreatePage), typeof(ProducerCreatePage));
            Routing.RegisterRoute(nameof(ProducerDetailsPage), typeof(ProducerDetailsPage));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
