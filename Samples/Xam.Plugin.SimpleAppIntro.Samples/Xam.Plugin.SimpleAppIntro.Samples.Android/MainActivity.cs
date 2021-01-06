using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Xam.Plugin.SimpleAppIntro.Droid
{
   [Activity(Label = "Xam.Plugin.SimpleAppIntro", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
   public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
   {
      protected override void OnCreate(Bundle savedInstanceState)
      {
         base.OnCreate(savedInstanceState);

         global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

         LoadApplication(new App());
      }
   }
}

