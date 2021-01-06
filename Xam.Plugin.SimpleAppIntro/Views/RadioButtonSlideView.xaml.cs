using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.Plugin.SimpleAppIntro.Views
{
    /// <summary>
    /// Defines the <see cref="RadioButtonSlideView" />.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RadioButtonSlideView : ContentView
    {
        #region Constructor & Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RadioButtonSlideView"/> class.
        /// </summary>
        public RadioButtonSlideView()
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
