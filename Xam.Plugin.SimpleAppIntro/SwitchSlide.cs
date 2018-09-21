using Xamarin.Forms;

namespace Xam.Plugin.SimpleAppIntro
{
   /// <summary>
   /// Data container for a Slide
   /// </summary>
   public class SwitchSlide : BaseSlide
   {
      private bool _SwitchIsChecked;

      public Command SwitchCommand { get; set; }
      public bool SwitchIsChecked
      {
         get { return _SwitchIsChecked; }
         set
         {
            _SwitchIsChecked = value;
            SwitchCommand.Execute(value);
         }
      }

      /// <summary>
      /// Constructor
      /// </summary>
      public SwitchSlide(SwitchSlideConfig config)
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
         SwitchCommand = config.SwitchCommand;
      }
   }

   /// <summary>
   /// Slide config
   /// </summary>
   public class SwitchSlideConfig
   {
      /// <summary>
      /// Constructor
      /// </summary>
      public SwitchSlideConfig(string title, string description, string icon, string backgroundColor, bool switchIsChecked = false, Command switchCommand = null,
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
         SwitchCommand = switchCommand;
         SwitchIsChecked = switchIsChecked;
      }

      public string Title { get; set; }
      public string Description { get; set; }
      public string Icon { get; set; }
      public string BackgroundColor { get; set; }
      public string TitleTextColor { get; set; }
      public string DescriptionTextColor { get; set; }
      public FontAttributes TitleFontAttributes { get; set; }
      public FontAttributes DescriptionFontAttributes { get; set; }
      public int TitleFontSize { get; set; }
      public int DescriptionFontSize { get; set; }
      public Command SwitchCommand { get; set; }
      public bool SwitchIsChecked { get; set; }
   }
}
