using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Widget;

namespace CustomEntries
{
    public static partial class CalculateBounds
    {
        public static double TextWidthNative(string text, float fontSize)
        {
            Rect bounds = new Rect();
            TextView textView = new TextView(Android.App.Application.Context) { TextSize = fontSize };
            textView.Paint.GetTextBounds(text, 0, text.Length, bounds);
            var length = bounds.Width();
            return length / Resources.System.DisplayMetrics.ScaledDensity;
        }

        public static double TextHeightNative(string text, float fontSize)
        {
            Rect bounds = new Rect();
            TextView textView = new TextView(Android.App.Application.Context) { TextSize = fontSize };
            textView.Paint.GetTextBounds(text, 0, text.Length, bounds);
            var height = bounds.Height();
            return height / Resources.System.DisplayMetrics.ScaledDensity;
        }
    }
}
