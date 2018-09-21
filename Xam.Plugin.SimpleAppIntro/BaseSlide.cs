using Xamarin.Forms;

namespace Xam.Plugin.SimpleAppIntro
{
   /// <summary>
   /// Data container for a Slide
   /// </summary>
   public class BaseSlide
   {
      /// <summary>
      /// Title
      /// </summary>
      public string Title { get; set; }

      /// <summary>
      /// Description
      /// </summary>
      public string Description { get; set; }

      /// <summary>
      /// Icon Source
      /// </summary>
      public string Icon { get; set; }

      /// <summary>
      /// Background Color
      /// </summary>
      public string Color { get; set; }

      /// <summary>
      /// Title text color
      /// </summary>
      public string TitleTextColor { get; set; }

      /// <summary>
      /// Description text color
      /// </summary>
      public string DescriptionTextColor { get; set; }

      /// <summary>
      /// Description text color
      /// </summary>
      public FontAttributes TitleFontAttributes { get; set; }

      /// <summary>
      /// Description text color
      /// </summary>
      public FontAttributes DescriptionFontAttributes { get; set; }

      /// <summary>
      /// Title font size
      /// </summary>
      public int TitleFontSize { get; set; }

      /// <summary>
      /// Description font size
      /// </summary>
      public int DescriptionFontSize { get; set; }
   }
}
