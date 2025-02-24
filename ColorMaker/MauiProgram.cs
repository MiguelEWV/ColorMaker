using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui; //Se importa el paquete "CommunityToolkit.Maui" para poder usar el "Clipboard"

namespace ColorMaker;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();



		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()//Se inicializa el paquete "CommunityToolkit.Maui" para poder usar el "Clipboard"
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
