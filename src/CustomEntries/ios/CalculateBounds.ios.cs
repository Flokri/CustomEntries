using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace CustomEntries
{
    public static partial class CalculateBounds
    {
        public static double TextWidthNative(string text, float fontSize) =>
            ((NSString)text).GetSizeUsingAttributes(new UIStringAttributes() { Font = UIFont.SystemFontOfSize(fontSize) }).Width;

        public static double TextHeightNative(string text, float fontSize) =>
            ((NSString)text).GetSizeUsingAttributes(new UIStringAttributes() { Font = UIFont.SystemFontOfSize(fontSize) }).Height;
    }
}
