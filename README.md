[![xam-plugin-simpleappintro MyGet Build Status](https://www.myget.org/BuildSource/Badge/xam-plugin-simpleappintro?identifier=bb7ae114-8bb3-4aa8-90f6-371fe9287f79)](https://www.myget.org/)

# Xam.Plugin.SimpleAppIntro
Just a nice and simple AppIntro for your Xamarin Forms project 


# Screenshots


# Setup
* Available on NuGet: https://www.nuget.org/packages/Xam.Plugin.SimpleAppIntro/ 
* Install into your .net standaard project. 


# Usage
You can now create new simple sliders and add them to a SimpleAppIntro page 

```
     var welcomePage = new SimpleAppIntro();

     // Add some simple slides
     welcomePage.AddSlide("Welcome", "This is a sample app showing off the new App Intro", "cup_icon.png");
     welcomePage.AddSlide("Slides", "You can add slides and have a clean app intro", "cup_icon.png");
     welcomePage.AddSlide("Other", "Tell your user what they can do with your app", "cup_icon.png");

     // Properties
     welcomePage.ShowPositionIndicator = true;
     welcomePage.ShowSkipButton = true;
     welcomePage.BarColor = "#607D8B";

     MainPage.Navigation.PushModalAsync(welcomePage);
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

