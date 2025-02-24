
using CommunityToolkit.Maui.Alerts;

namespace ColorMaker
{
    public partial class MainPage : ContentPage
    {
        bool isRAndom;

        //Para copiar o valor exadecimal en el "Clipboard" del dispositivo se usa paquetes NuGet
        //Para instalar el paquete, se debe ir al NuGet Package Manager y buscar por "CommunityToolkit.Maui" y seleccionar "Instalar"
        //Para llegar al NuGet Packet Manager se debe ir a la pestaña "Proyecto" y seleccionar "Administrar paquetes NuGet"
        //Para copiar el valor hexadecimal en el "Clipboard" se debe usar la siguiente linea de codigo:
        //Clipboard.SetTextAsync(color.ToHex());
        //Para usar el "Clipboard" se debe importar el paquete "Microsoft.Maui.Essentials" en el archivo "MainPage.xaml.cs"
        //Para importar el paquete se debe usar la siguiente linea de codigo:
        //using Microsoft.Maui.Essentials;
        /* Despues de instalar aparece esta explicacion de como usar el paquete 
                    
            In order to use the .NET MAUI Community Toolkit you need to call the extension method in your `MauiProgram.cs` file as follows:
            Buscar en este archivo las lineas de codigo que ya acrescente y comente.
            ## XAML usage
            
            In order to make use of the toolkit within XAML you can use this namespace:
            
            xmlns:toolkit="http://schemas.microsoft.com/dotnet/2022/maui/toolkit"
            
            ## Further information
            
            For more information please visit:
            
            - Our documentation site: https://docs.microsoft.com/dotnet/communitytoolkit/maui
            
            - Our GitHub repository: https://github.com/CommunityToolkit/Maui
        */

        public MainPage()
        {
            InitializeComponent();
        }
        //Uso solo este manejador de eventos para todos los sliders, ya que todos hacen lo mismo
        private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (!isRAndom) //Ejecuta unicamente el codigo si es diferente el Booleano isRAndom
            { 
            var rojo = slRojo.Value;
            var verde = slVerde.Value;
            var azul = slAzul.Value;

            Color color = Color.FromRgb(rojo, verde, azul); //extrae segun el valor el color 
            
            SetColor(color);// estabiliza el color dentro de "color"
            }
        }

        private void SetColor(Color color)
        {
            btnRandom.BackgroundColor = color;
            slRojo.MinimumTrackColor = color;
            slRojo.ThumbColor = color;
            slVerde.ThumbColor = color;
            slVerde.MinimumTrackColor = color;
            slAzul.ThumbColor = color;// Muda el color de los slider, solo el circulo 
            slAzul.MinimumTrackColor = color;
            Content.BackgroundColor = color;// colorea el contenido del aplicativo

            lblHex.Text = color.ToHex(); // Use the instance method ToHex() on the color object, transforma el color en hexadecimal string
            
        }

        private void btnRandom_Clicked(object sender, EventArgs e)
        {

            isRAndom = true;

            var random = new Random();
            var color = Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));
            SetColor(color);

            slRojo.Value = color.Red;
            slVerde.Value = color.Green;
            slAzul.Value = color.Blue;

            isRAndom = false;

        }

        private  void ImageButton_Clicked(object sender, EventArgs e) 
        {
            Clipboard.SetTextAsync(lblHex.Text); //Copia el valor hexadecimal en el "Clipboard". Se usa el metodo "SetTextAsync" del paquete "Microsoft.Maui.Essentials"
            var mensaje = Toast.Make(
                "Valor copiado en el Clipboard", //Mira que todos los valores o campos estan separados por comas
                CommunityToolkit.Maui.Core.ToastDuration.Short, // Este valor es para definir el tiempo del Toast
                14); // Este valor define el tamano del texto
            mensaje.Show(); //Muestra el mensaje en la pantalla


        }
        
    }

}
