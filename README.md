# Nuget Builds 
[![Build Status](https://www.myget.org/BuildSource/Badge/xam-plugin-simpleappintro?identifier=ef243495-8aec-4134-af86-1d4e3d1bf1c3)](https://www.myget.org/)  [![nuget](https://img.shields.io/nuget/v/Xam.Plugin.SimpleAppIntro.svg)](https://www.nuget.org/packages/Xam.Plugin.SimpleAppIntro/)


# Xam.Plugin.SimpleAppIntro
Just a nice and simple AppIntro for your Xamarin Forms project 


# Setup
* Available on Nuget:
https://www.nuget.org/packages/Xam.Plugin.SimpleAppIntro

!!Install into your .net standaard project. !!


# Example
![simpleappintro](https://user-images.githubusercontent.com/14561640/45887098-2c072580-bdbb-11e8-9084-3136bd911062.gif)



# Usage
You can now create new simple sliders and add them to a SimpleAppIntro page.
We support 4 types of slides at this moment, Slide/ButtonSlide/SwitchSlide/CheckboxSlide

```
 var welcomePage = new SimpleAppIntro(new List<object>() {
            new Slide(new SlideConfig("Welcome", "This is a sample app showing off the new App Intro", "cup_icon.png",
            null, "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic, 24, 16)),

            new ButtonSlide(new ButtonSlideConfig("Slides", "You can add slides and have a clean app intro", "cup_icon.png",
            null, "Click here", null,"#FFFFFF", new Command(() => OnButtonClicked()), "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic, 24, 16)),

            new SwitchSlide(new SwitchSlideConfig("Other", "Tell your user what they can do with your app",  "cup_icon.png",
            null, true, new Command<bool>((value) => OnSwitchClicked(value)), "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic, 24, 16)),

            new SwitchSlide(new SwitchSlideConfig("Other", "Tell your user what they can do with your app",  "cup_icon.png",
            null, true, new Command<bool>((value) => OnSwitchClicked(value)), "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic, 24, 16)),
	    
	    new CheckboxSlide(new CheckboxSlideConfig("Checkbox", "Let your user set specific settings via a AppIntro screen.",  	     "cup_icon.png",
            null, true, new Command<bool>((value) => OnCheckboxClicked(value)), "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic, 24, 16)),
      });

MainPage.Navigation.PushModalAsync(welcomePage);
```


# Animated
You can also specify your own Lottie animated icon for each slide. Just create an AnimatedSimpleAppIntro like:
We support 4 types of slides at this moment, Slide/ButtonSlide/SwitchSlide/CheckboxSlide (same usage as above)

```
var welcomePage = new AnimatedSimpleAppIntro(new List<object>() {
            new Slide(new SlideConfig("Welcome", "This is a sample app showing off the new App Intro", "world.json",
            null, "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic, 24, 16))
```


# Properties
You can set the next properties

```
welcomePage.DoneText = "Finish";
welcomePage.SkipText = "Skip";
welcomePage.NextText = "Next";

welcomePage.ShowPositionIndicator = true;
welcomePage.ShowSkipButton = true;
welcomePage.ShowNextButton = true;

// Vibrate
// NOTE: you will probably need to ask VIBRATE permission in Manifest.
welcomePage.Vibrate = true,
welcomePage.VibrateDuration = 0.2,
```


# Theming
You can set the next colors

```
welcomePage.BarColor = "#607D8B";
welcomePage.SkipButtonBackgroundColor = "#FF9700";
welcomePage.DoneButtonBackgroundColor = "#8AC149";
welcomePage.NextButtonBackgroundColor = "#8AC149";

welcomePage.SkipButtonTextColor = "#FFFFFF";
welcomePage.NextButtonTextColor = "#FFFFFF";
welcomePage.DoneButtonTextColor = "#FFFFFF";
```

And you can also specify an image instead of the default skip/done/next buttons:

```
welcomePage.DoneButtonImage = "baseline_done_white_24.png";
```


# Callbacks
You can use the next callback methods to get more info on the events 

```
      welcomePage.OnSkipButtonClicked = OnSkipButtonClicked;
      welcomePage.OnDoneButtonClicked = OnDoneButtonClicked;
      welcomePage.OnPositionChanged = OnPositionChanged;
	  
      /// <summary>
      /// On skip button clicked
      /// </summary>
      private void OnSkipButtonClicked()
      {
         DisplayAlert("Result", "Skip", "OK");
      }

      /// <summary>
      /// On done button clicked
      /// </summary>
      private void OnDoneButtonClicked()
      {
         DisplayAlert("Result", "Done", "OK");
      }

	  /// <summary>
      /// On slide position changed event
      /// </summary>
      private void OnPositionChanged(int page)
      {
         Console.Write($"Slide changed to page {page}");
      }

```

