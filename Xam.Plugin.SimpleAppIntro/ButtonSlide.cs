using Xamarin.Forms;

namespace Xam.Plugin.SimpleAppIntro
{
   /// <summary>
   /// Data container for a Slide
   /// </summary>
   public class ButtonSlide : BaseSlide
   {
      /// <summary>
      /// Constructor
      /// </summary>
      public ButtonSlide(ButtonSlideConfig config)
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
      }
   }

   /// <summary>
   /// Slide config
   /// </summary>
   public class ButtonSlideConfig
   {
      /// <summary>
      /// Constructor
      /// </summary>
      public ButtonSlideConfig(string title, string description, string icon, string backgroundColor,
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
   }
}
