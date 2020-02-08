using System;
using System.Collections.Generic;
using System.Text;

namespace CustomEntries
{
    public static partial class CalculateBounds
    {
        public static double GetTextWidth(string text, float fontSize) => TextWidthNative(text, fontSize);

        public static double GetTextHeight(string text, float fontSize) => TextHeightNative(text, fontSize);
    }
}
