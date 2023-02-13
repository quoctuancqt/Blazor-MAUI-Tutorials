﻿using Microsoft.Extensions.Logging;
using ToDoShared.Extensions;

namespace ToDoMobile
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            builder.Services.AddBmsApiClient("http://sss-iot-api.azurewebsites.net/");

            builder.Services.AddCoreServices();

            return builder.Build();
        }
    }
}