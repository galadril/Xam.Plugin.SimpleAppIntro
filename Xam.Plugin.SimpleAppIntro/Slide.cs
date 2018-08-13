namespace Xam.Plugin.SimpleAppIntro
{
   /// <summary>
   /// Data container for a Slide
   /// </summary>
   public class Slide
   {
      /// <summary>
      /// Constructor
      /// </summary>
      public Slide(string title, string description, string icon, string backgroundColor, string titleTextColor = "#FFFFFF", string descriptionTextColor = "#FFFFFF")
      {
         Title = title;
         Description = description;
         Icon = icon;
         Color = backgroundColor;
         TitleTextColor = titleTextColor;
         DescriptionTextColor = descriptionTextColor;
      }

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
   }
}
