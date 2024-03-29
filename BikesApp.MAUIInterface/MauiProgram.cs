﻿using CommunityToolkit.Maui;
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
                .UseMauiCommunityToolkit()
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

            builder.Services.AddTransient<ProducerEditViewModel>();
            builder.Services.AddTransient<ProducerEditPage>();

            builder.Services.AddTransient<ProducerDeleteViewModel>();
            builder.Services.AddTransient<ProducerDeletePage>();

            builder.Services.AddSingleton<BikeCollectionViewModel>();
            builder.Services.AddSingleton<BikesIndexPage>();

            builder.Services.AddTransient<BikeDetailsViewModel>();
            builder.Services.AddTransient<BikeDetailsPage>();

            builder.Services.AddTransient<BikeCreateViewModel>();
            builder.Services.AddTransient<BikeCreatePage>();

            builder.Services.AddTransient<BikeEditViewModel>();
            builder.Services.AddTransient<BikeEditPage>();

            builder.Services.AddTransient<BikeDeleteViewModel>();
            builder.Services.AddTransient<BikeDeletePage>();

            Routing.RegisterRoute(nameof(ProducerCreatePage), typeof(ProducerCreatePage));
            Routing.RegisterRoute(nameof(ProducerDetailsPage), typeof(ProducerDetailsPage));
            Routing.RegisterRoute(nameof(ProducerEditPage), typeof(ProducerEditPage));
            Routing.RegisterRoute(nameof(ProducerDeletePage), typeof(ProducerDeletePage));

            Routing.RegisterRoute(nameof(BikeDetailsPage), typeof(BikeDetailsPage));
            Routing.RegisterRoute(nameof(BikeCreatePage), typeof(BikeCreatePage));
            Routing.RegisterRoute(nameof(BikeEditPage), typeof(BikeEditPage));
            Routing.RegisterRoute(nameof(BikeDeletePage), typeof(BikeDeletePage));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
