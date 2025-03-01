using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui; //Se importa el paquete "CommunityToolkit.Maui" para poder usar el "Clipboard"
#if WINDOWS //Util para ejecutar el codigo para plataformas Windows 
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
﻿using Microsoft.Maui.LifecycleEvents;
#endif

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

#if WINDOWS //Codigo para ejecutar en plataformas Windows (Permite reajustar el tamano de pantalla, y controles)
        builder.ConfigureLifecycleEvents(events =>
        {
            events.AddWindows(wndLifeCycleBuilder =>
            {
                wndLifeCycleBuilder.OnWindowCreated(window =>
                {
                    IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                   
                    WindowId win32WindowsId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
                    
                    AppWindow winuiAppWindow = AppWindow.GetFromWindowId(win32WindowsId);    
                   
                    //Se define el tamano de la ventana en pixeles alto y ancho
                    const int width = 400; 
                    const int height = 650;

                    if(winuiAppWindow.Presenter is OverlappedPresenter p)
                        { 
                          
                        //p.Maximize();          //Ventana maximizada
                          p.IsAlwaysOnTop=true;  //Permite que siempre se mantenga por arriba la ventana
                          p.IsResizable=false;   //Permite Que la ventava cambie de tamano
                                                 //Muestra, Oculta o desabilita los controles de la ventana
                          p.IsMaximizable=false;
                          p.IsMinimizable=true; 
                                                 //solicita al SO el tamano de la pantalla para guardar y convertir en varibles
                          var displayInfo = DeviceDisplay.Current.MainDisplayInfo;
                          var screenWidth = (int)displayInfo.Width;
                          var screenHeight = (int)displayInfo.Height;
                                                 //Comando que altera el tamano de la ventana, y la posiciona en el centro de la pantalla
                          winuiAppWindow.MoveAndResize(new RectInt32(screenWidth / 2 - width / 2, screenHeight / 2 - height / 2, width, height));
                        //winuiAppWindow.Resize(new SizeInt32(width, height)); // solo cambia el tamano de la ventana

                          
                        }                     
                        else
                        {
                        //solicita al SO el tamano de la pantalla para guardar y convertir en varibles
                          var displayInfo = DeviceDisplay.Current.MainDisplayInfo;
                          var screenWidth = (int)displayInfo.Width;
                          var screenHeight = (int)displayInfo.Height;

                          winuiAppWindow.MoveAndResize(new RectInt32(screenWidth / 2 - width / 2, screenHeight / 2 - height / 2, width, height));
                                         
                        }  
                        
                });
            });
        });
#endif





        return builder.Build();
	}
}
