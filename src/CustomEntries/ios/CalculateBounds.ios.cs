using CoreGraphics;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace CustomEntries
{
    public static partial class CalculateBounds
    {
        public static double TextWidthNative(string text, float fontSize)
        {
            UILabel uiLabel = new UILabel() { Text = text, Font = UIFont.SystemFontOfSize(fontSize) };
            CGSize length = uiLabel.Text.StringSize(uiLabel.Font);
            return length.Width;
        }

        public static double TextHeightNative(string text, float fontSize)
        {
            UILabel uiLabel = new UILabel() { Text = text, Font = UIFont.SystemFontOfSize(fontSize) };
            CGSize size = uiLabel.Text.StringSize(uiLabel.Font);
            return size.Height;
        }
    }
}
