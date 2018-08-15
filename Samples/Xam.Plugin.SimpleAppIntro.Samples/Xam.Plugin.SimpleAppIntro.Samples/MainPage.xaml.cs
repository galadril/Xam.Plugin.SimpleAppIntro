using System;
using System.Collections.Generic;

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
         var welcomePage = new SimpleAppIntro(new List<Slide>() {
            new Slide("Welcome", "This is a sample app showing off the new App Intro", "cup_icon.png",
            null, "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic, 24, 16),
            new Slide("Slides", "You can add slides and have a clean app intro", "cup_icon.png",
            null, "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic, 24, 16),
            new Slide("Other", "Tell your user what they can do with your app", "cup_icon.png",
            null, "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic, 24, 16),
      })
         {
            // Properties
            ShowPositionIndicator = true,
            ShowSkipButton = true,
            ShowNextButton = true,
            DoneText = "Finish",
            NextText = "Next",
            SkipText = "Skip",

            // Theming
            BarColor = "#607D8B",
            SkipButtonBackgroundColor = "#FF9700",
            DoneButtonBackgroundColor = "#8AC149",
            NextButtonBackgroundColor = "#8AC149",

            //// Use images instead of buttons
            DoneButtonImage = "baseline_done_white_24.png",
            //NextButtonImage = "baseline_done_white_24.png",

            // Callbacks
            OnSkipButtonClicked = OnSkipButtonClicked,
            OnDoneButtonClicked = OnDoneButtonClicked
         };

         Navigation.PushModalAsync(welcomePage);
      }

      /// <summary>
      /// Open the welcome page
      /// </summary>
      private void Open_Clicked(object sender, EventArgs e)
      {
         var welcomePage = new AnimatedSimpleAppIntro(new List<Slide>() {
            new Slide("Welcome", "This is a sample app showing off the new App Intro", "world.json",
            null, "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic, 24, 16),
            new Slide("Slides", "You can add slides and have a clean app intro", "twitter_heart.json",
            null, "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic, 24, 16),
            new Slide("Other", "Tell your user what they can do with your app", "send_message_done.json",
            null, "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic, 24, 16),
      })
         {
            // Properties
            ShowPositionIndicator = true,
            ShowSkipButton = true,
            ShowNextButton = true,
            DoneText = "Finish",
            NextText = "Next",
            SkipText = "Skip",

            // Theming
            BarColor = "#607D8B",
            SkipButtonBackgroundColor = "#FF9700",
            DoneButtonBackgroundColor = "#8AC149",
            NextButtonBackgroundColor = "#8AC149",

            // Use images instead of buttons
            DoneButtonImage = "baseline_done_white_24.png",

            // Callbacks
            OnSkipButtonClicked = OnSkipButtonClicked,
            OnDoneButtonClicked = OnDoneButtonClicked
         };

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