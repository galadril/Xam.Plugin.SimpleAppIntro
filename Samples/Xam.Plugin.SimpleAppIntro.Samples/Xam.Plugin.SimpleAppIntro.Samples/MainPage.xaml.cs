using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.Plugin.SimpleAppIntro.Samples
{
   /// <summary>
   /// Main Page
   /// </summary>
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class MainPage : ContentPage
   {
      /// <summary>
      /// Simple main page
      /// </summary>
      public MainPage()
      {
         InitializeComponent();
      }

      #region Private


      /// <summary>
      /// Open the welcome page
      /// </summary>
      private void Open_Static_Clicked(object sender, EventArgs e)
      {
         var welcomePage = new SimpleAppIntro();

         // Add some simple slides
         welcomePage.AddSlide("Welcome", "This is a sample app showing off the new App Intro", "cup_icon.png",
            null, "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic);
         welcomePage.AddSlide("Slides", "You can add slides and have a clean app intro", "cup_icon.png",
            null, "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic);
         welcomePage.AddSlide("Other", "Tell your user what they can do with your app", "cup_icon.png",
            null, "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic);

         // Properties
         welcomePage.ShowPositionIndicator = true;
         welcomePage.ShowSkipButton = true;
         welcomePage.ShowNextButton = true;
         welcomePage.DoneText = "Finish";
         welcomePage.NextText = "Next";
         welcomePage.SkipText = "Skip";

         // Theming
         welcomePage.BarColor = "#607D8B";
         welcomePage.SkipButtonBackgroundColor = "#FF9700";
         welcomePage.DoneButtonBackgroundColor = "#8AC149";
         welcomePage.NextButtonBackgroundColor = "#8AC149";

         // Use images instead of buttons
         welcomePage.DoneButtonImage = "baseline_done_white_24.png";

         // Callbacks
         welcomePage.OnSkipButtonClicked = OnSkipButtonClicked;
         welcomePage.OnDoneButtonClicked = OnDoneButtonClicked;

         Navigation.PushModalAsync(welcomePage);
      }

      /// <summary>
      /// Open the welcome page
      /// </summary>
      private void Open_Clicked(object sender, EventArgs e)
      {
         var welcomePage = new AnimatedSimpleAppIntro();

         // Add some simple slides
         welcomePage.AddSlide("Welcome", "This is a sample app showing off the new App Intro", "world.json",
            null, "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic, 24, 24);
         welcomePage.AddSlide("Slides", "You can add slides and have a clean app intro", "twitter_heart.json",
            null, "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic, 24, 16);
         welcomePage.AddSlide("Other", "Tell your user what they can do with your app", "send_message_done.json",
            null, "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic, 24, 16);

         // Properties
         welcomePage.ShowPositionIndicator = true;
         welcomePage.ShowSkipButton = true;
         welcomePage.ShowNextButton = true;
         welcomePage.DoneText = "Finish";
         welcomePage.NextText = "Next";
         welcomePage.SkipText = "Skip";

         // Theming
         welcomePage.BarColor = "#607D8B";
         welcomePage.SkipButtonBackgroundColor = "#FF9700";
         welcomePage.DoneButtonBackgroundColor = "#8AC149";
         welcomePage.NextButtonBackgroundColor = "#8AC149";

         // Use images instead of buttons
         welcomePage.DoneButtonImage = "baseline_done_white_24.png";

         // Callbacks
         welcomePage.OnSkipButtonClicked = OnSkipButtonClicked;
         welcomePage.OnDoneButtonClicked = OnDoneButtonClicked;

         Navigation.PushModalAsync(welcomePage);
      }

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