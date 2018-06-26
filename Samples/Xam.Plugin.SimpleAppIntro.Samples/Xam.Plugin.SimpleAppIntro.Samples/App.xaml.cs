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

         var welcomePage = new SimpleAppIntro();

         // Add some simple slides
         welcomePage.AddSlide("Welcome", "This is a sample app showing off the new App Intro", "cup_icon.png");
         welcomePage.AddSlide("Slides", "You can add slides and have a clean app intro", "cup_icon.png");
         welcomePage.AddSlide("Other", "Tell your user what they can do with your app", "cup_icon.png");

         // Properties
         welcomePage.ShowPositionIndicator = true;
         welcomePage.ShowSkipButton = true;
         welcomePage.DoneText = "Finish";
         welcomePage.SkipText = "Skip";

         // Theming
         welcomePage.BarColor = "#607D8B";
         welcomePage.SkipButtonBackgroundColor = "#FF9700";
         welcomePage.DoneButtonBackgroundColor = "#8AC149";

         // Callbacks
         welcomePage.OnSkipButtonClicked = OnSkipButtonClicked;
         welcomePage.OnDoneButtonClicked = OnDoneButtonClicked;

         MainPage.Navigation.PushModalAsync(welcomePage);
      }

      #region Private

      /// <summary>
      /// On skip button clicked
      /// </summary>
      private void OnSkipButtonClicked()
      {
         Console.Write("Skip button clicked");
      }

      /// <summary>
      /// On done button clicked
      /// </summary>
      private void OnDoneButtonClicked()
      {
         Console.Write("Done button clicked");
      }

      #endregion
   }
}
