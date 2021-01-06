[![nuget](https://img.shields.io/nuget/v/Xam.Plugin.SimpleAppIntro.svg)](https://www.nuget.org/packages/Xam.Plugin.SimpleAppIntro/) ![Nuget](https://img.shields.io/nuget/dt/Xam.Plugin.SimpleAppIntro)

![Icon](https://raw.githubusercontent.com/galadril/Xam.Plugin.SimpleAppIntro/master/Samples/Xam.Plugin.SimpleAppIntro.Samples/Xam.Plugin.SimpleAppIntro.Samples.Android/Resources/mipmap-xxhdpi/Icon.png)


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
We support 5 per-build types of slides at this moment, Slide/ButtonSlide/SwitchSlide/CheckboxSlide/RadioButtonSlide(new).
I these doesn't work for you, you can always use a custom ContentView as a slide

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


            new RadioButtonSlide(new RadioButtonSlideConfig("RadioButtons", "Let users flip some radiobuttons via the app intro:",  "world.json",
                null, new List<RadioButtonItem>()
                {
                    new RadioButtonItem(){Content= "option 1 - group 1", GroupName="slide1", IsChecked = false, TextColor =  "#FFFFFF", FontAttributes = FontAttributes.None, FontSize = 16, Command =new Command<RadioButtonItem>((value) => OnRadioButtonChanged(value)) },
                    new RadioButtonItem(){Content= "option 2 - group 1", GroupName="slide1", IsChecked = false, TextColor =  "#FFFFFF", FontAttributes = FontAttributes.None, FontSize = 16, Command =new Command<RadioButtonItem>((value) => OnRadioButtonChanged(value)) },
                    new RadioButtonItem(){Content= "option 3 - group 2", GroupName="slide2", IsChecked = false, TextColor =  "#FFFFFF", FontAttributes = FontAttributes.None, FontSize = 16, Command =new Command<RadioButtonItem>((value) => OnRadioButtonChanged(value)) },
                    new RadioButtonItem(){Content= "option 4 - group 2", GroupName="slide2", IsChecked = false, TextColor =  "#FFFFFF", FontAttributes = FontAttributes.None, FontSize = 16, Command =new Command<RadioButtonItem>((value) => OnRadioButtonChanged(value)) }
                }, "#FFFFFF", "#FFFFFF",

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
welcomePage.BackText = "Next";

welcomePage.ShowPositionIndicator = true;
welcomePage.ShowSkipButton = true;
welcomePage.ShowNextButton = true;
welcomePage.ShowBackButton = true;

// Vibrate
// NOTE: you will probably need to ask VIBRATE permission in Manifest.
welcomePage.Vibrate = true;
welcomePage.VibrateDuration = 0.2;

```


# Theming
You can set the next colors

```

welcomePage.BarColor = "#607D8B";
welcomePage.SkipButtonBackgroundColor = "#FF9700";
welcomePage.DoneButtonBackgroundColor = "#8AC149";
welcomePage.NextButtonBackgroundColor = "#8AC149";
welcomePage.BackButtonBackgroundColor = "#8AC149";

welcomePage.SkipButtonTextColor = "#FFFFFF";
welcomePage.NextButtonTextColor = "#FFFFFF";
welcomePage.BackButtonTextColor = "#FFFFFF";
welcomePage.DoneButtonTextColor = "#FFFFFF";

```

And you can also specify an image instead of the default skip/done/next buttons:

```

welcomePage.DoneButtonImage = "baseline_done_white_24.png";
welcomePage.BackButtonImage = "baseline_done_white_24.png";
welcomePage.NextButtonImage = "baseline_done_white_24.png";
welcomePage.SkipButtonImage = "baseline_done_white_24.png";

```

# Custom ContentViews
You can now set a ContentView as a custom slide in this control!

```

 var welcomePage = new SimpleAppIntro(new List<object>() {
            
                new CustomSlide
                {
                    BindingContext = this
                },
               
      })
      
```

You can also use 2 interfaces while using custom slide views, ISave and IValidate.
For example you have a custom contentview slide with a profile firstname/lastname view that needs to be validated and saved on the slide.


(See sample project for a custom view with implemented interfaces)
```
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomSlide : ContentView, IValidate, ISave
    {


    ...

      public async void Save()
      {
         await viewmodel.SaveProfileName();
      }

      public bool Validate()
      {
         return viewmodel.ValidateName();
      }


      ...

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




# Donation

If you like to say thanks, you could always buy me a cup of coffee (/beer)!   
(Thanks!)  
[![PayPal donate button](https://img.shields.io/badge/paypal-donate-yellow.svg)](https://www.paypal.me/markheinis)
