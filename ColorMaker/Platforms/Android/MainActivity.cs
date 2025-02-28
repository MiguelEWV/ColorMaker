using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace ColorMaker;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{

    //Todo este codigo es para que la aplicacion se ejecute en pantalla completa

    /* protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);

            if (this.Window != null)
            {
                this.Window.AddFlags(WindowManagerFlags.Fullscreen);
            }
        }
    */
//*****************************  Todo este codigo es para que la aplicacion se ejecute en pantalla completa  *********************************
    private void SetWindowLayout()
    {
        if (Window != null)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.R)
            {
#pragma warning disable CA1416

                IWindowInsetsController? wicController = Window.InsetsController;

                if (Build.VERSION.SdkInt < BuildVersionCodes.S)
                {
                    Window.SetDecorFitsSystemWindows(false);
                }
                else
                {
                    // Use alternative method for Android 35.0 and later
                    Window.SetDecorFitsSystemWindows(false); // This line is obsolete in Android 35.0 and later
                }

                Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);

                if (wicController != null)
                {
                    wicController.Hide(WindowInsets.Type.Ime());
                    wicController.Hide(WindowInsets.Type.NavigationBars());
                }
#pragma warning restore CA1416
            }
            else
            {
#pragma warning disable CS0618

                Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);

                Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(SystemUiFlags.Fullscreen |
                                                                             SystemUiFlags.HideNavigation |
                                                                             SystemUiFlags.Immersive |
                                                                             SystemUiFlags.ImmersiveSticky |
                                                                             SystemUiFlags.LayoutHideNavigation |
                                                                             SystemUiFlags.LayoutStable |
                                                                             SystemUiFlags.LowProfile);
#pragma warning restore CS0618
            }
        }
    }

    protected override void OnCreate(Bundle? bSavedInstanceState)
    {
        base.OnCreate(bSavedInstanceState);
        SetWindowLayout();
    }
//************************************************* Final del Codigo mas completo para pantalla completa *************************************************

}


