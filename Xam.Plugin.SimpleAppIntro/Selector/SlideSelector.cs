using Xamarin.Forms;

namespace Xam.Plugin.SimpleAppIntro.Selector
{
   /// <summary>
   /// Slide selector
   /// </summary>
   public class SlideSelector : DataTemplateSelector
   {
      public DataTemplate SlideTemplate { get; set; }
      public DataTemplate ButtonTemplate { get; set; }

      /// <summary>
      /// On select template
      /// </summary>
      protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
      {
         if (item is ButtonSlide)
            return ButtonTemplate;
         else
            return SlideTemplate;
      }
   }
}
