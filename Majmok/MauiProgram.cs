﻿using Microsoft.Extensions.Logging;

namespace Majmok
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<MonkeyService>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<DetailPage>();

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<DetailViewModel>();


            return builder.Build();
        }
    }
}
