using System;
using Xam.Plugin.SimpleAppIntro.Samples;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Xam.Plugin.SimpleAppIntro
{
   /// <summary>
   /// Sample app for SimpleAppIntro
   /// </summary>
   public partial class App : Application
   {
      /// <summary>
      /// Default constructor
      /// </summary>
      public App()
      {
         InitializeComponent();

         MainPage = new NavigationPage(new MainPage());
      }
   }
}
