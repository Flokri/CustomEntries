using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace CustomEntries
{
    /// <summary>
    /// Extensions for the skcanvas view
    /// </summary>
    static class SKCanvasViewExtensions
    {
        /// <summary>
        /// Calculate a rectange (from pixel) to skvcanvas view size
        /// </summary>
        /// <param name="skCanvasView">the skcanvas view</param>
        /// <param name="rc">the rectangle to convert from pixel</param>
        /// <returns>a rectangle with the converted skcanvas view size</returns>
        public static Rectangle FromPixels(this SKCanvasView skCanvasView, Rectangle rc) =>
            new Rectangle(skCanvasView.FromPixels(rc.Location), skCanvasView.FromPixels(rc.Size));

        /// <summary>
        /// calculate a size (from pixel) to skcanvas view size
        /// </summary>
        /// <param name="skCanvasView">the skcanvas view</param>
        /// <param name="sz">the size to convert</param>
        /// <returns>a size with the converted skcanvas view size</returns>
        public static Size FromPixels(this SKCanvasView skCanvasView, Size sz) =>
            (Size)skCanvasView.FromPixels(new Point(sz.Width, sz.Height));

        /// <summary>
        /// calculate a point (from pixel) to skcanvas view size
        /// </summary>
        /// <param name="skCanvasView">the skcanvas view</param>
        /// <param name="sz">the point to convert</param>
        /// <returns>a point with the converted skcanvas view size</returns>
        public static Point FromPixels(this SKCanvasView skCanvasView, Point pt)
        {
            double wf = skCanvasView.CanvasSize.Width / skCanvasView.Width;
            double hf = skCanvasView.CanvasSize.Height / skCanvasView.Height;
            return new Point(pt.X * wf, pt.Y * hf);
        }
    }
}
