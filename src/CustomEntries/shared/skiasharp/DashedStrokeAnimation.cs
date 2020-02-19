using System;

using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomEntries
{
    /// <summary>
    /// create a aimation for a dashed stroke
    /// </summary>
    class DashedStrokeAnimation
    {
        DashedStroke _strokeDash;

        public DashedStroke From { get; }
        public DashedStroke To { get; }
        public uint Duration { get; }
        public Easing Easing { get; }

        public DashedStrokeAnimation(DashedStroke from, DashedStroke to, uint duration)
        {
            From = from;
            To = to;
            Duration = duration;
        }

        /// <summary>
        /// animate a dashed storke animation form the "from" dashed stroke to the "to" dashes stroke
        /// </summary>
        /// <param name="onValueCallback">the callback to set the changed dashed stroke</param>
        /// <returns>a task contains the animation</returns>
        public Task<bool> Start(Action<DashedStroke> onValueCallback)
        {
            _strokeDash = From;

            var taskCompletionSource = new TaskCompletionSource<bool>();
            var anim = new Animation(_ => onValueCallback(_strokeDash));

            anim.Add(0, 1, new Animation(
                callback: v => _strokeDash.Phase = (float)v,
                start: From.Phase,
                end: To.Phase,
                easing: Easing));

            anim.Add(0, 1, new Animation(
                callback: v => _strokeDash.Intervals[0] = (float)v,
                start: From.Intervals[0],
                end: To.Intervals[0],
                easing: Easing));

            anim.Add(0, 1, new Animation(
                callback: v => _strokeDash.Intervals[1] = (float)v,
                start: From.Intervals[1],
                end: To.Intervals[1],
                easing: Easing));

            anim.Commit(
                owner: Application.Current.MainPage,
                name: "highlightAnimation",
                length: Duration,
                easing: Easing,
                finished: (v, c) => taskCompletionSource.SetResult(c));

            return taskCompletionSource.Task;
        }
    }
}
