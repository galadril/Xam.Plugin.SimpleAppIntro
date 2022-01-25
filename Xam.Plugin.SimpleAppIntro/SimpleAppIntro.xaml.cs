using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xam.Plugin.SimpleAppIntro.Interface;
using Xamarin.Essentials;
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
        private bool _showBack = false;
        private bool _showNext = true;
        private bool _shipIndicator = true;
        private string _barColor = "#607D8B";

        private string _DoneButtonBackgroundColor = "#8BC34A";
        private string _NextButtonBackgroundColor = "#8BC34A";
        private string _SkipButtonBackgroundColor = "#8BC34A";
        private string _BackButtonBackgroundColor = "#8BC34A";

        private string _DoneButtonTextColor = "#FFFFFF";
        private string _NextButtonTextColor = "#FFFFFF";
        private string _SkipButtonTextColor = "#FFFFFF";
        private string _BackButtonTextColor = "#FFFFFF";

        private string _NextButtonImage = "";
        private string _DoneButtonImage = "";
        private string _SkipButtonImage = "";
        private string _BackButtonImage = "";

        private string _skipText = "Skip";
        private string _doneText = "Done";
        private string _nextText = "Next";
        private string _backText = "Back";

        private bool _vibrate = true;
        private double _vibrateDuration = 0;

        private List<object> _slides;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SimpleAppIntro(IEnumerable<object> slides)
        {
            InitializeComponent();
            if (slides != null)
            {
                Slides = slides.ToList();
                foreach (object s in Slides)
                {
                    if (s is Slide slide)
                        slide.Color = GetColor(slide.Color);
                    else if (s is ButtonSlide bslide)
                    {
                        bslide.Color = GetColor(bslide.Color);
                        bslide.ButtonBackgroundColor = GetColor(bslide.ButtonBackgroundColor);
                    }
                    else if (s is SwitchSlide sslide)
                        sslide.Color = GetColor(sslide.Color);
                    else if (s is CheckboxSlide sclide)
                        sclide.Color = GetColor(sclide.Color);
                    else if (s is RadioButtonSlide srlide)
                        srlide.Color = GetColor(srlide.Color);
                }
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

        /// <summary>
        /// Delegate for the callback method
        /// </summary>
        public delegate void PositionCallbackDelegate(int page);

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
        /// Callback on slide change
        /// </summary>
        public PositionCallbackDelegate OnPositionChanged { get; set; }

        /// <summary>
        /// List of slides
        /// </summary>
        public List<object> Slides { get { return _slides; } set { _slides = value; OnPropertyChanged(); } }

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
        /// Back Button Background Color
        /// </summary>
        public string BackButtonBackgroundColor { get { return _BackButtonBackgroundColor; } set { _BackButtonBackgroundColor = value; OnPropertyChanged(); } }

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
        /// Back Button Text Color
        /// </summary>
        public string BackButtonTextColor { get { return _BackButtonTextColor; } set { _BackButtonTextColor = value; OnPropertyChanged(); } }

        /// <summary>
        /// NExt button image source
        /// </summary>
        public string NextButtonImage { get { return _NextButtonImage; } set { _NextButtonImage = value; OnPropertyChanged(); } }

        /// <summary>
        /// Done button image source
        /// </summary>
        public string DoneButtonImage { get { return _DoneButtonImage; } set { _DoneButtonImage = value; OnPropertyChanged(); } }

        /// <summary>
        /// Back Button Image Source
        /// </summary>
        public string BackButtonImage { get { return _BackButtonImage; } set { _BackButtonImage = value; OnPropertyChanged(); } }

        /// <summary>
        /// Skip Button Image Source
        /// </summary>
        public string SkipButtonImage { get { return _SkipButtonImage; } set { _SkipButtonImage = value; OnPropertyChanged(); } }

        /// <summary>
        /// Current position
        /// </summary>
        public int Position
        {
            get { return _position; }
            set
            {
                if (_position == value)
                    return;

                var _oldposition = _position;
                _position = value;
                if (isValid(_oldposition))
                {
                    isSave(_position);
                    OnPropertyChanged();
                    PositionChangedAsync();
                }
            }
        }

        /// <summary>
        /// Vibrate
        /// </summary>
        public bool Vibrate { get { return _vibrate; } set { _vibrate = value; OnPropertyChanged(); } }

        /// <summary>
        /// Vibrate Duration
        /// </summary>
        public double VibrateDuration { get { return _vibrateDuration; } set { _vibrateDuration = value; OnPropertyChanged(); } }

        /// <summary>
        /// Show position indicator
        /// </summary>
        public bool ShowPositionIndicator { get { return _shipIndicator; } set { _shipIndicator = value; OnPropertyChanged(); } }

        /// <summary>
        /// Show skip button
        /// </summary>
        public bool ShowSkipButton { get { return _showSkip; } set { _showSkip = value; OnPropertyChanged(); } }

        /// <summary>
        /// Show back button
        /// </summary>
        public bool ShowBackButton { get { return _showBack; } set { _showBack = value; OnPropertyChanged(); } }

        /// <summary>
        /// Show next button
        /// </summary>
        public bool ShowNextButton { get { return _showNext; } set { _showNext = value; OnPropertyChanged(); } }

        /// <summary>
        /// Show back text
        /// </summary>
        public string BackText { get { return _backText; } set { _backText = value; OnPropertyChanged(); } }

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

            if (ShowBackButton)
            {
                skipLabel.Text = Position == 0 ? SkipText : BackText;
                skipImage.Source = Position == 0 ? SkipButtonImage : BackButtonImage;
            }
            else
            {
                skipLabel.Text = SkipText;
                skipImage.Source = SkipButtonImage;
            }

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
            if (!isValid(Position))
                return;
            CheckVibrate();
            if (Position < (Slides.Count - 1))
                this.Position++;
        }

        /// <summary>
        /// Skip button clicked, pop navigation
        /// </summary>
        private void Skip_Clicked(object sender, EventArgs e)
        {
            if (!isValid(Position))
                return;
            CheckVibrate();
            if (ShowBackButton && Position > 0)
                this.Position--;
            else
            {
                OnSkipButtonClicked?.Invoke();
                Navigation.PopModalAsync();
            }
        }

        /// <summary>
        /// Is the slide valide?
        /// </summary>
        public bool isValid(int position)
        {
            var currentSlide = Slides[position];
            if (currentSlide is IValidate validateSlide)
                return validateSlide.Validate();
            return true;
        }

        /// <summary>
        /// Does the slide support saving
        /// </summary>
        public void isSave(int position)
        {
            var currentSlide = Slides[position];
            if (currentSlide is ISave saveSlide)
                saveSlide.Save();
        }

        /// <summary>
        /// Done clicked
        /// </summary>
        private void Done_Clicked(object sender, EventArgs e)
        {
            if (!isValid(Position))
                return;
            isSave(_position);
            CheckVibrate();
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
            OnPositionChanged?.Invoke(Position);

            if (ShowBackButton)
            {
                skipLabel.Text = BackText;
                skipImage.Source = BackButtonImage;
                if (ShowSkipButton && Position == 0)
                {
                    skipLabel.Text = SkipText;
                    skipImage.Source = SkipButtonImage;
                }
            }
            else
            {
                skipLabel.Text = SkipText;
                skipImage.Source = SkipButtonImage;
            }

            Task hideNextButton = Task.Delay(0);
            Task showNextButton = Task.Delay(0);
            if (ShowNextButton)
            {
                if (string.IsNullOrEmpty(NextButtonImage))
                {
                    nextButton.IsVisible = false;
                    hideNextButton = nextButton.FadeTo(0, 200);
                    showNextButton = nextButton.FadeTo(1, 200);
                }
                else
                {
                    nextImage.IsVisible = false;
                    hideNextButton = nextImage.FadeTo(0, 200);
                    showNextButton = nextImage.FadeTo(1, 200);
                }
            }

            if (Position == (Slides.Count - 1)) ///last slide
            {
                if (ShowNextButton)
                {
                    if (string.IsNullOrEmpty(NextButtonImage)) nextButton.IsVisible = false;
                    else nextImage.IsVisible = false;
                }

                if (string.IsNullOrEmpty(DoneButtonImage)) doneButton.IsVisible = true;
                else doneImage.IsVisible = true;

                if (string.IsNullOrEmpty(DoneButtonImage) && string.IsNullOrEmpty(SkipButtonImage))
                    await Task.WhenAll(doneButton.FadeTo(1, 200), !ShowBackButton ? skipButton.FadeTo(0, 200) : skipButton.FadeTo(1, 200), hideNextButton);
                else if (string.IsNullOrEmpty(DoneButtonImage))
                    await Task.WhenAll(doneButton.FadeTo(1, 200), !ShowBackButton ? skipButton.FadeTo(0, 200) : skipButton.FadeTo(1, 200), hideNextButton);
                else if (string.IsNullOrEmpty(SkipButtonImage))
                    await Task.WhenAll(doneImage.FadeTo(1, 200), !ShowBackButton ? skipButton.FadeTo(0, 200) : skipButton.FadeTo(1, 200), hideNextButton);
                else
                    await Task.WhenAll(doneImage.FadeTo(1, 200), !ShowBackButton ? skipButton.FadeTo(0, 200) : skipButton.FadeTo(1, 200), hideNextButton);

                if (string.IsNullOrEmpty(SkipButtonImage)) skipButton.IsVisible = true;
                else skipImage.IsVisible = true;
            }
            else
            {
                if (ShowNextButton)
                {
                    if (string.IsNullOrEmpty(NextButtonImage)) nextButton.IsVisible = true;
                    else nextImage.IsVisible = true;
                }

                if (ShowSkipButton)
                {
                    if (string.IsNullOrEmpty(SkipButtonImage)) skipButton.IsVisible = true;
                    else skipImage.IsVisible = true;

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
                    if (ShowBackButton)
                    {
                        if (string.IsNullOrEmpty(BackButtonImage)) skipButton.IsVisible = true;
                        else skipImage.IsVisible = true;

                        if (string.IsNullOrEmpty(DoneButtonImage) && string.IsNullOrEmpty(BackButtonImage))
                            await Task.WhenAll(skipButton.FadeTo(Position <= 0 ? 0:1, 200), doneButton.FadeTo(0, 200), showNextButton);
                        else if (string.IsNullOrEmpty(DoneButtonImage))
                            await Task.WhenAll(skipImage.FadeTo(Position <= 0 ? 0 : 1, 200), doneButton.FadeTo(0, 200), showNextButton);
                        else if (string.IsNullOrEmpty(BackButtonImage))
                            await Task.WhenAll(skipButton.FadeTo(Position <= 0 ? 0 : 1, 200), doneImage.FadeTo(0, 200), showNextButton);
                        else
                            await Task.WhenAll(skipImage.FadeTo(Position <= 0 ? 0 : 1, 200), doneImage.FadeTo(0, 200), showNextButton);

                        if (string.IsNullOrEmpty(DoneButtonImage)) doneButton.IsVisible = false;
                        else doneImage.IsVisible = false;

                        if (string.IsNullOrEmpty(BackButtonImage)) skipLabel.IsVisible = Position <= 0 ? false : true;
                        else skipImage.IsVisible = Position <= 0 ? false : true;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(DoneButtonImage))
                            await Task.WhenAll(doneButton.FadeTo(0, 200), showNextButton);
                        else
                            await Task.WhenAll(doneImage.FadeTo(0, 200), showNextButton);

                        if (string.IsNullOrEmpty(DoneButtonImage)) doneButton.IsVisible = false;
                        else doneImage.IsVisible = false;
                    }
                }
            }
        }

        /// <summary>
        /// Check if we need to do a vibration
        /// </summary>
        public void CheckVibrate()
        {
            try
            {
                if (Vibrate)
                {
                    if (VibrateDuration > 0)
                        Vibration.Vibrate(TimeSpan.FromSeconds(VibrateDuration));
                    else
                        Vibration.Vibrate();
                }
            }
            catch (FeatureNotSupportedException)
            {
                // Feature not supported on device
            }
            catch (Exception)
            {
                // Other error has occurred.
            }
        }

        #endregion
    }
}