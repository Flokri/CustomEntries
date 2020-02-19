using System;
using System.Collections.Generic;
using System.Text;

namespace CustomEntries
{
    /// <summary>
    /// calculate the bounds of a string
    /// </summary>
    public static partial class CalculateBounds
    {
        /// <summary>
        /// get the native width of the string
        /// </summary>
        /// <param name="text">the string to measure</param>
        /// <param name="fontSize">the font size of the displayed string</param>
        /// <returns>the width of the measured string</returns>
        public static double GetTextWidth(string text, float fontSize) => TextWidthNative(text, fontSize);

        /// <summary>
        /// get the height of the the string
        /// </summary>
        /// <param name="text">the string to measure</param>
        /// <param name="fontSize">the font size of the displayed string</param>
        /// <returns>the height of the measured string</returns>
        public static double GetTextHeight(string text, float fontSize) => TextHeightNative(text, fontSize);
    }
}
