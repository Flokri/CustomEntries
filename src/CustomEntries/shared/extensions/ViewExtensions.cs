using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomEntries
{
    /// <summary>
    /// animation extensions for visual elements
    /// </summary>
    public static class ViewExtensions
    {
        /// <summary>
        /// animate the color change of a visual element
        /// </summary>
        /// <param name="self">the visual element</param>
        /// <param name="startColor">the start color of the animation</param>
        /// <param name="endColor">the end color of the animation</param>
        /// <param name="callback">the callback to set the color value</param>
        /// <param name="length">the length of the animation</param>
        /// <param name="easing">easing (optional)</param>
        /// <returns>the animatin as task</returns>
        public static Task<bool> ColorTo(this VisualElement self, Color startColor, Color endColor, Action<Color> callback, uint length = 200, Easing easing = null)
        {
            Color transform(double t) =>
            Color.FromRgba(startColor.R + t * (endColor.R - startColor.R),
            startColor.G + t * (endColor.G - startColor.G),
            startColor.B + t * (endColor.B - startColor.B),
            startColor.A + t * (endColor.A - startColor.A));

            return StartAnimation(self, "ColorTo", transform, callback, length, easing);
        }

        /// <summary>
        /// cancle a running animation
        /// </summary>
        /// <param name="self">the parent of the animation</param>
        /// <param name="animationName">the name of the animation</param>
        public static void CancelAnimation(this VisualElement self, string animationName) => self.AbortAnimation(animationName);

        /// <summary>
        /// start a animation for a visual element
        /// </summary>
        /// <typeparam name="T">the type of the transform fucntion</typeparam>
        /// <param name="element">the parent</param>
        /// <param name="animationName">the name of the animation</param>
        /// <param name="transform">the transform function</param>
        /// <param name="callback">the callback of the animation</param>
        /// <param name="length">the length of the animation</param>
        /// <param name="easing">the easing</param>
        /// <param name="easing">easing (optional)</param>
        /// <returns>the animatin as task</returns>
        static Task<bool> StartAnimation<T>(VisualElement element, string animationName, Func<double, T> transform, Action<T> callback, uint length, Easing easing)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            element.Animate<T>(animationName, transform, callback, 16, length, easing, (v, c) => taskCompletionSource.SetResult(c));
            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Animate the size change of a visual element
        /// </summary>
        /// <param name="self">the parent of the animamtion</param>
        /// <param name="startSize">the start size of the animation</param>
        /// <param name="endSize">the end size of the animation</param>
        /// <param name="callback">the callback to set the changed size</param>
        /// <param name="length">the lenght of the animation</param>
        /// <param name="easing">the optinal easing</param>
        /// <param name="easing">easing (optional)</param>
        /// <returns>the animatin as task</returns>
        public static Task<bool> SizeTo(this VisualElement self, double startSize, double endSize, Action<double> callback, uint length, Easing easing = null)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();
            self.Animate("SizeTo", callback, startSize, endSize, 16, length, easing, (v, c) => taskCompletionSource.SetResult(c));

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// animate the maring change of a visual element
        /// </summary>
        /// <param name="self">the partent of the animation</param>
        /// <param name="startMargin">the start margin of the animation</param>
        /// <param name="endMargin">the end margin of the animation</param>
        /// <param name="callback">the callback to set changed animation</param>
        /// <param name="length">the lenght of the animation</param>
        /// <param name="easing">the optional easing</param>
        /// <param name="easing">easing (optional)</param>
        /// <returns>the animatin as task</returns>
        public static Task<bool> MarginTo(this VisualElement self, Thickness startMargin, Thickness endMargin, Action<Thickness> callback, uint length, Easing easing = null)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            Thickness transform(double t) =>
            new Thickness(startMargin.Left + t * (endMargin.Left - startMargin.Left),
            startMargin.Top + t * (endMargin.Top - startMargin.Top),
            startMargin.Right + t * (endMargin.Right - startMargin.Right),
            startMargin.Bottom + t * (endMargin.Bottom - startMargin.Bottom));

            return StartAnimation(self, "MarginTo", transform, callback, length, easing);
        }

        /// <summary>
        /// animate the opacity change of a visual element (fade in, fade out)
        /// </summary>
        /// <param name="self">the parent ofthe animation</param>
        /// <param name="startOpacity">the start opacity of the animation</param>
        /// <param name="endOpacity">the end opacity of the animation</param>
        /// <param name="callback">the callback to set the changed opacity</param>
        /// <param name="length">the lenght of the animation</param>
        /// <param name="easing">the optional easing</param>
        /// <param name="easing">easing (optional)</param>
        /// <returns>the animatin as task</returns>
        public static Task<bool> OpacityTo(this VisualElement self, double startOpacity, double endOpacity, Action<double> callback, uint length, Easing easing = null)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            double transform(double t) =>
            (startOpacity + t * (endOpacity - startOpacity));

            return StartAnimation(self, "OpacityTo", transform, callback, length, easing);
        }
    }
}
