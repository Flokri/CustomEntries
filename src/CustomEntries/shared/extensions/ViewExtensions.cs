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
        public static Task<bool> ColorTo(this VisualElement self, Color startColor, Color endColor, Action<Color> callback, uint length = 200, Easing easing = null)
        {
            Color transform(double t) =>
            Color.FromRgba(startColor.R + t * (endColor.R - startColor.R),
            startColor.G + t * (endColor.G - startColor.G),
            startColor.B + t * (endColor.B - startColor.B),
            startColor.A + t * (endColor.A - startColor.A));

            return StartAnimation<Color>(self, "ColorTo", transform, callback, length, easing);
        }

        public static void CancelAnimation(this VisualElement self, string animationName) => self.AbortAnimation(animationName);

        static Task<bool> StartAnimation<T>(VisualElement element, string animationName, Func<double, T> transform, Action<T> callback, uint length, Easing easing)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            element.Animate<T>(animationName, transform, callback, 16, length, easing, (v, c) => taskCompletionSource.SetResult(c));
            return taskCompletionSource.Task;
        }

        public static Task<bool> SizeTo(this VisualElement self, double startSize, double endSize, Action<double> callback, uint length, Easing easing = null)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();
            self.Animate("SizeTo", callback, startSize, endSize, 16, length, easing, (v, c) => taskCompletionSource.SetResult(c));

            return taskCompletionSource.Task;
        }

        public static Task<bool> MarginTo(this VisualElement self, Thickness startMargin, Thickness endMargin, Action<Thickness> callback, uint length, Easing easing = null)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            Thickness transform(double t) =>
            new Thickness(startMargin.Left + t * (endMargin.Left - startMargin.Left),
            startMargin.Top + t * (endMargin.Top - startMargin.Top),
            startMargin.Right + t * (endMargin.Right - startMargin.Right),
            startMargin.Bottom + t * (endMargin.Bottom - startMargin.Bottom));

            return StartAnimation<Thickness>(self, "MarginTo", transform, callback, length, easing);
        }

        public static Task<bool> OpacityTo(this VisualElement self, double startOpacity, double endOpacity, Action<double> callback, uint length, Easing easing = null)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            double transform(double t) =>
            (startOpacity + t * (endOpacity - startOpacity));

            return StartAnimation<double>(self, "OpacityTo", transform, callback, length, easing);
        }
    }
}
