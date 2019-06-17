using Xamarin.Forms;

namespace Xam.Plugin.SimpleAppIntro
{
   /// <summary>
   /// Data container for a Slide
   /// </summary>
   public class CheckboxSlide : BaseSlide
   {
      private bool _CheckboxIsChecked;
      public Command CheckboxCommand { get; set; }
      public bool CheckboxIsChecked
      {
         get { return _CheckboxIsChecked; }
         set
         {
            _CheckboxIsChecked = value;
            CheckboxCommand?.Execute(value);
         }
      }

      /// <summary>
      /// Constructor
      /// </summary>
      public CheckboxSlide(CheckboxSlideConfig config)
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
         CheckboxCommand = config.CheckboxCommand;
      }
   }

   /// <summary>
   /// Slide config
   /// </summary>
   public class CheckboxSlideConfig
   {
      /// <summary>
      /// Constructor
      /// </summary>
      public CheckboxSlideConfig(string title, string description, string icon, string backgroundColor, bool checkboxIsChecked = false, Command checkboxCommand = null,
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
         CheckboxCommand = checkboxCommand;
         CheckboxIsChecked = checkboxIsChecked;
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
      public Command CheckboxCommand { get; set; }
      public bool CheckboxIsChecked { get; set; }
   }
}
