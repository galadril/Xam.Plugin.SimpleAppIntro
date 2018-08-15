using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.Plugin.SimpleAppIntro.Views
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class AnimatedSlideView : ContentView
   {
      public AnimatedSlideView()
      {
         InitializeComponent();

         SizeChanged += (sender, args) =>
         {
            string visualState = Width > Height ? "Landscape" : "Portrait";
            VisualStateManager.GoToState(mainStack, visualState);
            VisualStateManager.GoToState(mainGrid, visualState);
            foreach (View child in mainGrid.Children)
               VisualStateManager.GoToState(child, visualState);
         };
      }
   }
}