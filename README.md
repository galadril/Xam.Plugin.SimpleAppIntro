# Nuget Builds 
[![Build Status](https://www.myget.org/BuildSource/Badge/xam-plugin-simpleappintro?identifier=ef243495-8aec-4134-af86-1d4e3d1bf1c3)](https://www.myget.org/)  [![nuget](https://img.shields.io/nuget/v/Xam.Plugin.SimpleAppIntro.svg)](https://www.nuget.org/packages/Xam.Plugin.SimpleAppIntro/) [![NuGet](https://img.shields.io/nuget/dt/Microsoft.AspNetCore.Mvc.svg)](https://www.nuget.org/packages/Xam.Plugin.SimpleAppIntro/)

# Xam.Plugin.SimpleAppIntro
Just a nice and simple AppIntro for your Xamarin Forms project 


# Setup
* Available on Nuget:
https://www.nuget.org/packages/Xam.Plugin.SimpleAppIntro

!!Install into your .net standaard project. !!


# Example
![simpleappintro](https://user-images.githubusercontent.com/14561640/44038383-f419aff2-9f16-11e8-92df-e448f7829905.gif)


# Usage
You can now create new simple sliders and add them to a SimpleAppIntro page 

```
 var welcomePage = new SimpleAppIntro(new List<Slide>() {
            new Slide("Welcome", "This is a sample app showing off the new App Intro", "world.json",
            null, "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic, 24, 16),
           
            new Slide("Slides", "You can add slides and have a clean app intro", "twitter_heart.json",
            null, "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic, 24, 16),
            
            new Slide("Other", "Tell your user what they can do with your app", "send_message_done.json",
            null, "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic, 24, 16),
      });

MainPage.Navigation.PushModalAsync(welcomePage);
```


# Animated
You can also specify your own Lottie animated icon for each slide. Just create an AnimatedSimpleAppIntro like:

```
var welcomePage = new SimpleAppIntro(new List<Slide>() {
            new Slide("Welcome", "This is a sample app showing off the new App Intro", "world.json",
            null, "#FFFFFF", "#FFFFFF",
            FontAttributes.Bold, FontAttributes.Italic, 24, 16),
      });
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


# Callback 
You can use the two callback methods to get more info on the events 

```
welcomePage.OnSkipButtonClicked = OnSkipButtonClicked;
welcomePage.OnDoneButtonClicked = OnDoneButtonClicked;
	  
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
```

