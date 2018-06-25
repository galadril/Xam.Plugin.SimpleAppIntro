using System;
using System.Collections.Generic;
using System.Text;

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
      /// <param name="title"></param>
      /// <param name="description"></param>
      /// <param name="icon"></param>
      /// <param name="color"></param>
      public Slide(string title, string description, string icon, string color)
      {
         Title = title;
         Description = description;
         Icon = icon;
         Color = color;
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
   }
}
