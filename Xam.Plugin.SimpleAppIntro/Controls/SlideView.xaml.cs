using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.Plugin.SimpleAppIntro.Controls
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
         };
      }
	}
}