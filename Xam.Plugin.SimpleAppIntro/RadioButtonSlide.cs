using System.Collections.Generic;
using Xamarin.Forms;

namespace Xam.Plugin.SimpleAppIntro
{
    /// <summary>
    /// Data container for a radio button Slide.
    /// </summary>
    public class RadioButtonSlide : BaseSlide
    {
        #region Constructor & Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RadioButtonSlide"/> class.
        /// </summary>
        /// <param name="config">The config<see cref="RadioButtonSlideConfig"/>.</param>
        public RadioButtonSlide(RadioButtonSlideConfig config)
        {
            Title = config.Title;
            Description = config.Description;
            Icon = config.Icon;
            Color = config.BackgroundColor;
            TitleTextColor = config.TitleTextColor;
            DescriptionTextColor = config.DescriptionTextColor;
            TitleFontAttributes = config.TitleFontAttributes;
            DescriptionFontAttributes = config.DescriptionFontAttributes;
            TitleFontSize = config.TitleFontSize;
            DescriptionFontSize = config.DescriptionFontSize;
            Items = config.Items;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Items.
        /// </summary>
        public List<RadioButtonItem> Items { get; set; }

        #endregion
    }

    /// <summary>
    /// Radiobutton item.
    /// </summary>
    public class RadioButtonItem
    {
        #region Variables

        /// <summary>
        /// Defines the isChecked.
        /// </summary>
        private bool isChecked;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether IsChecked.
        /// </summary>
        public bool IsChecked
        {
            get => isChecked;
            set
            {
                isChecked = value;
                if (Command != null)
                    Command.Execute(this);
            }
        }

        /// <summary>
        /// Gets or sets the Command.
        /// </summary>
        public Command Command { get; set; }

        /// <summary>
        /// Gets or sets the GroupName.
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Gets or sets the Content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the TextColor.
        /// </summary>
        public string TextColor { get; set; }

        /// <summary>
        /// Gets or sets the FontAttributes.
        /// </summary>
        public FontAttributes FontAttributes { get; set; }

        /// <summary>
        /// Font size
        /// </summary>
        public int FontSize { get; set; }

        #endregion
    }

    /// <summary>
    /// Slide config.
    /// </summary>
    public class RadioButtonSlideConfig
    {
        #region Constructor & Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RadioButtonSlideConfig"/> class.
        /// </summary>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <param name="description">The description<see cref="string"/>.</param>
        /// <param name="icon">The icon<see cref="string"/>.</param>
        /// <param name="backgroundColor">The backgroundColor<see cref="string"/>.</param>
        /// <param name="items">The items<see cref="List{RadioButtonItem}"/>.</param>
        /// <param name="titleTextColor">The titleTextColor<see cref="string"/>.</param>
        /// <param name="descriptionTextColor">The descriptionTextColor<see cref="string"/>.</param>
        /// <param name="titleFontAttributes">The titleFontAttributes<see cref="FontAttributes"/>.</param>
        /// <param name="descriptionFontAttributes">The descriptionFontAttributes<see cref="FontAttributes"/>.</param>
        /// <param name="titleFontSize">The titleFontSize<see cref="int"/>.</param>
        /// <param name="descriptionFontSize">The descriptionFontSize<see cref="int"/>.</param>
        public RadioButtonSlideConfig(string title, string description, string icon, string backgroundColor, List<RadioButtonItem> items = null,
           string titleTextColor = "#FFFFFF", string descriptionTextColor = "#FFFFFF",
           FontAttributes titleFontAttributes = FontAttributes.Bold, FontAttributes descriptionFontAttributes = FontAttributes.None,
           int titleFontSize = 24, int descriptionFontSize = 16)
        {
            Title = title;
            Description = description;
            Icon = icon;
            BackgroundColor = backgroundColor;
            TitleTextColor = titleTextColor;
            DescriptionTextColor = descriptionTextColor;
            TitleFontAttributes = titleFontAttributes;
            DescriptionFontAttributes = descriptionFontAttributes;
            TitleFontSize = titleFontSize;
            DescriptionFontSize = descriptionFontSize;
            Items = items;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Icon.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the BackgroundColor.
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the TitleTextColor.
        /// </summary>
        public string TitleTextColor { get; set; }

        /// <summary>
        /// Gets or sets the DescriptionTextColor.
        /// </summary>
        public string DescriptionTextColor { get; set; }

        /// <summary>
        /// Gets or sets the TitleFontAttributes.
        /// </summary>
        public FontAttributes TitleFontAttributes { get; set; }

        /// <summary>
        /// Gets or sets the DescriptionFontAttributes.
        /// </summary>
        public FontAttributes DescriptionFontAttributes { get; set; }

        /// <summary>
        /// Gets or sets the TitleFontSize.
        /// </summary>
        public int TitleFontSize { get; set; }

        /// <summary>
        /// Gets or sets the DescriptionFontSize.
        /// </summary>
        public int DescriptionFontSize { get; set; }

        /// <summary>
        /// Gets or sets the Items.
        /// </summary>
        public List<RadioButtonItem> Items { get; set; }

        #endregion
    }
}
