using Foundation;
using UIKit;

namespace CustomEntries
{
    public static partial class CalculateBounds
    {
        /// <summary>
        /// get the native width of the string
        /// </summary>
        /// <param name="text">the string to measure</param>
        /// <param name="fontSize">the font size of the displayed string</param>
        /// <returns>the width of the measured string</returns>
        public static double TextWidthNative(string text, float fontSize) =>
            ((NSString)text).GetSizeUsingAttributes(new UIStringAttributes() { Font = UIFont.SystemFontOfSize(fontSize) }).Width;

        /// <summary>
        /// get the height of the the string
        /// </summary>
        /// <param name="text">the string to measure</param>
        /// <param name="fontSize">the font size of the displayed string</param>
        /// <returns>the height of the measured string</returns>
        public static double TextHeightNative(string text, float fontSize) =>
            ((NSString)text).GetSizeUsingAttributes(new UIStringAttributes() { Font = UIFont.SystemFontOfSize(fontSize) }).Height;
    }
}
