using Xamarin.Forms;

namespace Xam.Plugin.SimpleAppIntro.Selector
{
    /// <summary>
    /// Slide selector.
    /// </summary>
    public class SlideSelector : DataTemplateSelector
    {
        #region Properties

        /// <summary>
        /// Gets or sets the SlideTemplate.
        /// </summary>
        public DataTemplate SlideTemplate { get; set; }

        /// <summary>
        /// Gets or sets the ButtonTemplate.
        /// </summary>
        public DataTemplate ButtonTemplate { get; set; }

        /// <summary>
        /// Gets or sets the SwitchTemplate.
        /// </summary>
        public DataTemplate SwitchTemplate { get; set; }

        /// <summary>
        /// Gets or sets the CheckboxTemplate.
        /// </summary>
        public DataTemplate CheckboxTemplate { get; set; }

        /// <summary>
        /// Gets or sets the RadioButtonTemplate.
        /// </summary>
        public DataTemplate RadioButtonTemplate { get; set; }

        #endregion

        #region Protected

        /// <summary>
        /// On select template.
        /// </summary>
        /// <param name="item">The item<see cref="object"/>.</param>
        /// <param name="container">The container<see cref="BindableObject"/>.</param>
        /// <returns>The <see cref="DataTemplate"/>.</returns>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is ButtonSlide)
                return ButtonTemplate;
            else if (item is SwitchSlide)
                return SwitchTemplate;
            else if (item is CheckboxSlide)
                return CheckboxTemplate;
            else if (item is RadioButtonSlide)
                return RadioButtonTemplate;
            else if (item is Slide)
                return SlideTemplate;
            else
                return new DataTemplate(() => (ContentView)item);
        }

        #endregion
    }
}
