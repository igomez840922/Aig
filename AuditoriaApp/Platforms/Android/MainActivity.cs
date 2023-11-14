using Android.App;
using Android.Content.PM;
using Android.OS;

namespace AuditoriaApp
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            // Lock the screen orientation to portrait
            //RequestedOrientation = ScreenOrientation.Landscape;

            //HttpsURLConnection.DefaultHostnameVerifier = new AllowAllHostnameVerifier();
            base.OnCreate(savedInstanceState);
        }
    }
}
