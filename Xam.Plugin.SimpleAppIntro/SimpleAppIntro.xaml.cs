using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.Plugin.SimpleAppIntro
{
   /// <summary>
   /// App intro
   /// </summary>
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class SimpleAppIntro : ContentPage
   {
      #region Variables

      private readonly string[] DefaultColors = new string[20] { "#E91E63", "#F44336", "#9C27B0", "#2196F3", "#3F51B5", "#009688", "#4CAF50", "#FFEB3B", "#FF9800", "#607D8B", "#E91E63", "#F44336", "#9C27B0", "#2196F3", "#3F51B5", "#009688", "#4CAF50", "#FFEB3B", "#FF9800", "#607D8B" };
      private List<string> UsedColors = new List<string>();
      private int _position;
      private bool _showSkip = true;
      private bool _showNext = true;
      private bool _shipIndicator = true;
      private string _barColor = "#607D8B";

      private string _DoneButtonBackgroundColor = "#8BC34A";
      private string _NextButtonBackgroundColor = "#8BC34A";
      private string _SkipButtonBackgroundColor = "#8BC34A";

      private string _DoneButtonTextColor = "#FFFFFF";
      private string _NextButtonTextColor = "#FFFFFF";
      private string _SkipButtonTextColor = "#FFFFFF";

      private string _NextButtonImage = "";
      private string _DoneButtonImage = "";
      private string _SkipButtonImage = "";

      private string _skipText = "Skip";
      private string _doneText = "Done";
      private string _nextText = "Next";

      private List<Slide> _slides;

      #endregion

      #region Constructor

      /// <summary>
      /// Default Constructor
      /// </summary>
      public SimpleAppIntro(IEnumerable<Slide> slides)
      {
         InitializeComponent();

         if (slides != null)
         {
            Slides = slides.ToList();
            foreach (Slide s in Slides)
               s.Color = GetColor(s.Color);
         }

         BindingContext = this;
         carouselView.ItemsSource = Slides;
         carouselIndicators.ItemsSource = Slides;

         SizeChanged += (sender, args) =>
         {
            string visualState = Width > Height ? "Landscape" : "Portrait";
            VisualStateManager.GoToState(mainGrid, visualState);
            foreach (View child in mainGrid.Children)
               VisualStateManager.GoToState(child, visualState);
         };
      }

      #endregion

      #region Delegates

      /// <summary>
      /// Delegate for the callback method
      /// </summary>
      public delegate void CallbackDelegate();

      #endregion

      #region Properties

      /// <summary>
      /// Callback on skip button
      /// </summary>
      public CallbackDelegate OnSkipButtonClicked { get; set; }

      /// <summary>
      /// Callback on Done button
      /// </summary>
      public CallbackDelegate OnDoneButtonClicked { get; set; }

      /// <summary>
      /// List of slides
      /// </summary>
      public List<Slide> Slides { get { return _slides; } set { _slides = value; OnPropertyChanged(); } }

      /// <summary>
      /// Bottom bar color
      /// </summary>
      public string BarColor { get { return _barColor; } set { _barColor = value; OnPropertyChanged(); } }

      /// <summary>
      /// Done Button Background Color
      /// </summary>
      public string DoneButtonBackgroundColor { get { return _DoneButtonBackgroundColor; } set { _DoneButtonBackgroundColor = value; OnPropertyChanged(); } }

      /// <summary>
      /// Next Button Background Color
      /// </summary>
      public string NextButtonBackgroundColor { get { return _NextButtonBackgroundColor; } set { _NextButtonBackgroundColor = value; OnPropertyChanged(); } }

      /// <summary>
      /// Skip Button Background Color
      /// </summary>
      public string SkipButtonBackgroundColor { get { return _SkipButtonBackgroundColor; } set { _SkipButtonBackgroundColor = value; OnPropertyChanged(); } }

      /// <summary>
      /// Next Button Text Color
      /// </summary>
      public string NextButtonTextColor { get { return _NextButtonTextColor; } set { _NextButtonTextColor = value; OnPropertyChanged(); } }

      /// <summary>
      /// Done Button Text Color
      /// </summary>
      public string DoneButtonTextColor { get { return _DoneButtonTextColor; } set { _DoneButtonTextColor = value; OnPropertyChanged(); } }

      /// <summary>
      /// Skip Button Text Color
      /// </summary>
      public string SkipButtonTextColor { get { return _SkipButtonTextColor; } set { _SkipButtonTextColor = value; OnPropertyChanged(); } }

      /// <summary>
      /// NExt button image source
      /// </summary>
      public string NextButtonImage { get { return _NextButtonImage; } set { _NextButtonImage = value; OnPropertyChanged(); } }

      /// <summary>
      /// Done button image source
      /// </summary>
      public string DoneButtonImage { get { return _DoneButtonImage; } set { _DoneButtonImage = value; OnPropertyChanged(); } }

      /// <summary>
      /// Skip Button Image Source
      /// </summary>
      public string SkipButtonImage { get { return _SkipButtonImage; } set { _SkipButtonImage = value; OnPropertyChanged(); } }

      /// <summary>
      /// Current position
      /// </summary>
      public int Position { get { return _position; } set { _position = value; OnPropertyChanged(); PositionChangedAsync(); } }

      /// <summary>
      /// Show position indicator
      /// </summary>
      public bool ShowPositionIndicator { get { return _shipIndicator; } set { _shipIndicator = value; OnPropertyChanged(); } }

      /// <summary>
      /// Show skip button
      /// </summary>
      public bool ShowSkipButton { get { return _showSkip; } set { _showSkip = value; OnPropertyChanged(); PositionChangedAsync(); } }

      /// <summary>
      /// Show next button
      /// </summary>
      public bool ShowNextButton { get { return _showNext; } set { _showNext = value; OnPropertyChanged(); PositionChangedAsync(); } }

      /// <summary>
      /// Show skip text
      /// </summary>
      public string SkipText { get { return _skipText; } set { _skipText = value; OnPropertyChanged(); } }

      /// <summary>
      /// Show done text
      /// </summary>
      public string DoneText { get { return _doneText; } set { _doneText = value; OnPropertyChanged(); } }

      /// <summary>
      /// Show next text
      /// </summary>
      public string NextText { get { return _nextText; } set { _nextText = value; OnPropertyChanged(); } }

      #endregion

      #region Protected

      /// <summary>
      /// On page appearing
      /// </summary>
      protected override async void OnAppearing()
      {
         base.OnAppearing();

         if (ShowSkipButton)
         {
            if (string.IsNullOrEmpty(SkipButtonImage))
            {
               skipImage.IsVisible = false;
               await skipButton.FadeTo(1, 200);
               skipButton.IsVisible = true;
            }
            else
            {
               skipButton.IsVisible = false;
               await skipImage.FadeTo(1, 200);
               skipImage.IsVisible = true;
            }
         }
         else
         {
            skipButton.IsVisible = false;
            skipImage.IsVisible = false;
         }

         if (ShowNextButton)
         {
            if (string.IsNullOrEmpty(NextButtonImage))
            {
               nextImage.IsVisible = false;
               await nextButton.FadeTo(1, 200);
               nextButton.IsVisible = true;
            }
            else
            {
               nextButton.IsVisible = false;
               await nextImage.FadeTo(1, 200);
               nextImage.IsVisible = true;
            }
         }
         else
         {
            nextButton.IsVisible = false;
            nextImage.IsVisible = false;
         }
      }

      #endregion

      #region private

      /// <summary>
      /// Get the new color of a slide
      /// </summary>
      private string GetColor(string color)
      {
         if (string.IsNullOrEmpty(color))
         {
            do
            {
               color = DefaultColors[new Random().Next(0, 20)];
            } while (UsedColors.Contains(color));
         }
         UsedColors.Add(color);
         return color;
      }

      /// <summary>
      /// Next button clicked, pop navigation
      /// </summary>
      private void Next_Clicked(object sender, EventArgs e)
      {
         if (Position < (Slides.Count - 1))
            this.Position++;
      }

      /// <summary>
      /// Skip button clicked, pop navigation
      /// </summary>
      private void Skip_Clicked(object sender, EventArgs e)
      {
         OnSkipButtonClicked?.Invoke();
         Navigation.PopModalAsync();
      }

      /// <summary>
      /// Done clicked
      /// </summary>
      private void Done_Clicked(object sender, EventArgs e)
      {
         OnDoneButtonClicked?.Invoke();
         Navigation.PopModalAsync();
      }

#pragma warning disable S3168
      /// <summary>
      /// Position Changed
      /// </summary>
      private async void PositionChangedAsync()
#pragma warning restore S3168 
      {
         if (Position == (Slides.Count - 1)) ///last slide
         {
            if (string.IsNullOrEmpty(DoneButtonImage)) doneButton.IsVisible = true;
            else doneImage.IsVisible = true;
            Task hideNextButton = Task.Delay(0);
            if (ShowNextButton)
            {
               if (string.IsNullOrEmpty(NextButtonImage))
               {
                  nextButton.IsVisible = false;
                  hideNextButton = nextButton.FadeTo(0, 200);
               }
               else
               {
                  nextImage.IsVisible = false;
                  hideNextButton = nextImage.FadeTo(0, 200);
               }
            }
            if (string.IsNullOrEmpty(DoneButtonImage) && string.IsNullOrEmpty(SkipButtonImage))
               await Task.WhenAll(doneButton.FadeTo(1, 200), skipButton.FadeTo(0, 200), hideNextButton);
            else if (string.IsNullOrEmpty(DoneButtonImage))
               await Task.WhenAll(doneButton.FadeTo(1, 200), skipImage.FadeTo(0, 200), hideNextButton);
            else if (string.IsNullOrEmpty(SkipButtonImage))
               await Task.WhenAll(doneImage.FadeTo(1, 200), skipButton.FadeTo(0, 200), hideNextButton);
            else
               await Task.WhenAll(doneImage.FadeTo(1, 200), skipImage.FadeTo(0, 200), hideNextButton);

            if (string.IsNullOrEmpty(SkipButtonImage)) skipButton.IsVisible = true;
            else skipImage.IsVisible = true;
         }
         else
         {
            if (ShowSkipButton)
            {
               if (string.IsNullOrEmpty(SkipButtonImage)) skipButton.IsVisible = true;
               else skipImage.IsVisible = true;
               Task showNextButton = Task.Delay(0);
               if (ShowNextButton)
               {
                  if (string.IsNullOrEmpty(NextButtonImage))
                  {
                     nextButton.IsVisible = true;
                     showNextButton = nextButton.FadeTo(1, 200);
                  }
                  else
                  {
                     nextImage.IsVisible = true;
                     showNextButton = nextImage.FadeTo(1, 200);
                  }
               }

               if (string.IsNullOrEmpty(DoneButtonImage) && string.IsNullOrEmpty(SkipButtonImage))
                  await Task.WhenAll(skipButton.FadeTo(1, 200), doneButton.FadeTo(0, 200), showNextButton);
               else if (string.IsNullOrEmpty(DoneButtonImage))
                  await Task.WhenAll(skipImage.FadeTo(1, 200), doneButton.FadeTo(0, 200), showNextButton);
               else if (string.IsNullOrEmpty(SkipButtonImage))
                  await Task.WhenAll(skipButton.FadeTo(1, 200), doneImage.FadeTo(0, 200), showNextButton);
               else
                  await Task.WhenAll(skipImage.FadeTo(1, 200), doneImage.FadeTo(0, 200), showNextButton);

               if (string.IsNullOrEmpty(DoneButtonImage)) doneButton.IsVisible = false;
               else doneImage.IsVisible = false;
            }
            else
            {
               Task showNextButton = Task.Delay(0);
               if (ShowNextButton)
               {
                  if (string.IsNullOrEmpty(NextButtonImage))
                  {
                     nextButton.IsVisible = true;
                     showNextButton = nextButton.FadeTo(1, 200);
                  }
                  else
                  {
                     nextImage.IsVisible = true;
                     showNextButton = nextImage.FadeTo(1, 200);
                  }
               }

               if (string.IsNullOrEmpty(DoneButtonImage))
                  await Task.WhenAll(doneButton.FadeTo(0, 200), showNextButton);
               else
                  await Task.WhenAll(doneImage.FadeTo(0, 200), showNextButton);

               if (string.IsNullOrEmpty(DoneButtonImage)) doneButton.IsVisible = false;
               else doneImage.IsVisible = false;
            }
         }
      }

      #endregion
   }
}