using System;
using System.Collections;
using System.Linq;
using Xamarin.Forms;

namespace Xam.Plugin.SimpleAppIntro.Controls
{
   /// <summary>
   /// Carousel Indicator
   /// </summary>
   public class CarouselIndicators : Grid
   {
      #region Variables

      ImageSource _unselectedImageSource;
      ImageSource _selectedImageSource;
      readonly StackLayout _indicators = new StackLayout { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.CenterAndExpand };

      int _currentlySelected;

      #endregion

      #region Properties

      public static readonly BindableProperty PositionProperty = BindableProperty.Create(nameof(Position), typeof(int), typeof(CarouselIndicators), 0, BindingMode.TwoWay,
          propertyChanging: PositionChanging);

      public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(CarouselIndicators),
          Enumerable.Empty<object>(), BindingMode.OneWay, propertyChanged: ItemsChanged);

      public static readonly BindableProperty SelectedIndicatorProperty = BindableProperty.Create(nameof(SelectedIndicator), typeof(string), typeof(CarouselIndicators), "");

      public static readonly BindableProperty UnselectedIndicatorProperty = BindableProperty.Create(nameof(UnselectedIndicator), typeof(string), typeof(CarouselIndicators), "");

      public static readonly BindableProperty IndicatorWidthProperty = BindableProperty.Create(nameof(IndicatorWidth), typeof(double), typeof(CarouselIndicators), 0.0);

      public static readonly BindableProperty IndicatorHeightProperty = BindableProperty.Create(nameof(IndicatorHeight), typeof(double), typeof(CarouselIndicators), 0.0);

      public string SelectedIndicator
      {
         get { return (string)GetValue(SelectedIndicatorProperty); }
         set { SetValue(SelectedIndicatorProperty, value); }
      }

      public string UnselectedIndicator
      {
         get { return (string)GetValue(UnselectedIndicatorProperty); }
         set { SetValue(UnselectedIndicatorProperty, value); }
      }

      public double IndicatorWidth
      {
         get { return (double)GetValue(IndicatorWidthProperty); }
         set { SetValue(IndicatorWidthProperty, value); }
      }

      public double IndicatorHeight
      {
         get { return (double)GetValue(IndicatorHeightProperty); }
         set { SetValue(IndicatorHeightProperty, value); }
      }

      public int Position
      {
         get { return (int)GetValue(PositionProperty); }
         set { SetValue(PositionProperty, value); }
      }

      public IEnumerable ItemsSource
      {
         get { return (IEnumerable)GetValue(ItemsSourceProperty); }
         set
         {
            SetValue(ItemsSourceProperty, value);
            SetItemSource();
         }
      }

      #endregion

      #region Public

      public void Clear()
      {
         _indicators.Children.Clear();
      }

      public CarouselIndicators()
      {
         HorizontalOptions = LayoutOptions.CenterAndExpand;
         RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
         Children.Add(_indicators);
      }

      public void Init(int position)
      {
         if (_unselectedImageSource == null)
            _unselectedImageSource = ImageSource.FromFile(UnselectedIndicator);

         if (_selectedImageSource == null)
            _selectedImageSource = ImageSource.FromFile(SelectedIndicator);

         if (_indicators.Children.Count > 0)
         {
            ((Image)_indicators.Children[_currentlySelected]).Source = _unselectedImageSource;
            ((Image)_indicators.Children[position]).Source = _selectedImageSource;
         }
         else
         {
            var enumerator = ItemsSource.GetEnumerator();
            var count = 0;
            while (enumerator.MoveNext())
            {
               var image = BuildImage(position == count ? State.Selected : State.Unselected, count);
               _indicators.Children.Add(image);
               count++;
            }
         }

         _currentlySelected = position;
      }

      public Image BuildImage(State state, int position)
      {
         var image = new Image()
         {
            WidthRequest = IndicatorWidth,
            HeightRequest = IndicatorHeight,
            ClassId = state.ToString()
         };

         switch (state)
         {
            case State.Selected:
               image.Source = _selectedImageSource;
               break;
            case State.Unselected:
               image.Source = _unselectedImageSource;
               break;
            default:
               throw new Exception("Invalid state selected");
         }

         image.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { Position = position; }) });
         return image;
      }

      public static void PositionChanging(object bindable, object oldValue, object newValue)
      {
         var carouselIndicators = bindable as CarouselIndicators;
         carouselIndicators?.Init(Convert.ToInt32(newValue));
      }

      public static void ItemsChanged(object bindable, object oldValue, object newValue)
      {
         var carouselIndicators = bindable as CarouselIndicators;

         carouselIndicators?.Clear();
         carouselIndicators?.Init(0);
      }

      public void SetItemSource()
      {
         this.Clear();
         this.Init(0);
      }

      public enum State
      {
         Selected,
         Unselected
      }

      #endregion
   }
}
