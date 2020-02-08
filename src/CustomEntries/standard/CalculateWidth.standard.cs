using System;
using System.Collections.Generic;
using System.Text;

namespace CustomEntries
{
    public static partial class CalculateBounds
    {
        public static double TextWidthNative(string text, float fontSize) => throw new NotSupportedException("This function is not supported in .netstandard");
        public static double TextHeightNative(string text, float fontSize) => throw new NotSupportedException("This function is not supported in .netstandard");
    }
}
