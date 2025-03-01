namespace ColorMaker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage());
        }
    }

    //PAra publicar el proyecto para Windows se debe usar el siguiente comando en la terminal
    //dotnet build -t:Publish -f net6.0-windows -r win-x64
    //Para publicar el proyecto para Android se debe usar el siguiente comando en la terminal
    //dotnet build -t:Publish -f net6.0-android -r android
    //Para publicar el proyecto para iOS se debe usar el siguiente comando en la terminal
    //dotnet build -t:Publish -f net6.0-ios -r ios
    //Para publicar el proyeto para Windows y colocar en la tienda de Windows se debe usar el siguiente comando en la terminal
    //dotnet build -t:Publish -f net6.0-windows -r win-x64 -p:PublishSingleFile=true
    //Para publicar el proyeto para Android y colocar en la tienda de Google se debe usar el siguiente comando en la terminal
    //dotnet build -t:Publish -f net6.0-android -r android -p:PublishSingleFile=true
    //Para publicar el proyeto para iOS y colocar en la tienda de Apple se debe usar el siguiente comando en la terminal
    //dotnet build -t:Publish -f net6.0-ios -r ios -p:PublishSingleFile=true
    // Manuales de publicacion en:
    //Windows: https://learn.microsoft.com/pt-br/dotnet/maui/windows/deployment/publish?view=net-maui-9.0
    //https://learn.microsoft.com/pt-br/dotnet/maui/windows/deployment/overview?view=net-maui-9.0
    //Android: https://learn.microsoft.com/pt-br/dotnet/maui/android/deployment/publish?view=net-maui-9.0
    //https://learn.microsoft.com/pt-br/dotnet/maui/android/deployment/overview?view=net-maui-9.0
    //iOS: https://learn.microsoft.com/pt-br/dotnet/maui/ios/deployment/publish?view=net-maui-9.0
    //https://learn.microsoft.com/pt-br/dotnet/maui/ios/deployment/overview?view=net-maui-9.0
    //https://learn.microsoft.com/pt-br/dotnet/maui/ios/deployment/publish?view=net-maui-9.0






}