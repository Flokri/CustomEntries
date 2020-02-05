using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomEntries
{
    public static class ViewExtensions
    {
        private const string AnimationName = "ColorTo";

        public static Task<bool> ColorTo (this VisualElement self, Color startColor, Color endColor, Action<Color> callback, uint length = 200, Easing easing = null)
        {
            Func<double, Color> transform = (t) =>
            Color.FromRgba(startColor.R + t * (endColor.R - startColor.R),
            startColor.G + t * (endColor.G - startColor.G),
            startColor.B + t * (endColor.B - startColor.B),
            startColor.A + t * (endColor.A - startColor.A));

            return ColorAnimation(self, transform, callback, length, easing);
        }

        public static void CancelAnimation(this VisualElement self) => self.AbortAnimation(AnimationName);

        static Task<bool> ColorAnimation(VisualElement element, Func<double, Color> transform, Action<Color> callback, uint length, Easing easing)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            element.Animate<Color>(AnimationName, transform, callback, 16, length, easing, (v, c) => taskCompletionSource.SetResult(c));
            return taskCompletionSource.Task;
        }
    }
}
