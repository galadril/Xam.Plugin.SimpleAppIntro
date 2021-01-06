using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.Plugin.SimpleAppIntro.Views
{
    /// <summary>
    /// Defines the <see cref="AnimatedRadioButtonSlideView" />.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimatedRadioButtonSlideView : ContentView
    {
        #region Constructor & Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimatedRadioButtonSlideView"/> class.
        /// </summary>
        public AnimatedRadioButtonSlideView()
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

        #endregion

        #region Private

        /// <summary>
        /// The ListView_ItemSelected.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="SelectedItemChangedEventArgs"/>.</param>
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listview.SelectedItem = null;
        }

        #endregion
    }
}
