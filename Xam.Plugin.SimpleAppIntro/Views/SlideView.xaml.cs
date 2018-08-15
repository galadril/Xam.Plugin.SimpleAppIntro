using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.Plugin.SimpleAppIntro.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SlideView : ContentView
	{
		public SlideView ()
		{
			InitializeComponent ();

         SizeChanged += (sender, args) =>
         {
            string visualState = Width > Height ? "Landscape" : "Portrait";
            VisualStateManager.GoToState(mainStack, visualState);
            foreach (View child in mainStack.Children)
               VisualStateManager.GoToState(child, visualState);
         };
      }
	}
}