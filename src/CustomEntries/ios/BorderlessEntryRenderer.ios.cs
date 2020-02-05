using CustomEntries;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryRenderer))]
namespace CustomEntries
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            // remove the border form the entry
            if (Control != null) 
                Control.BorderStyle = UIKit.UITextBorderStyle.None;
        }
    }
}
