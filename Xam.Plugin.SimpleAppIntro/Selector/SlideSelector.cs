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
      public DataTemplate SwitchTemplate { get; set; }
      public DataTemplate CheckboxTemplate { get; set; }

      /// <summary>
      /// On select template
      /// </summary>
      protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
      {
         if (item is ButtonSlide)
            return ButtonTemplate;
         else if (item is SwitchSlide)
            return SwitchTemplate;
         else if (item is CheckboxSlide)
            return CheckboxTemplate;
         else
            return SlideTemplate;
      }
   }
}
