using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomEntries
{
    static class SKCanvasViewExtensions
    {
        public static Rectangle FromPixels(this SKCanvasView skCanvasView, Rectangle rc) =>
            new Rectangle(skCanvasView.FromPixels(rc.Location), skCanvasView.FromPixels(rc.Size));

        public static Size FromPixels(this SKCanvasView skCanvasView, Size rc) =>
            (Size)skCanvasView.FromPixels(new Point(rc.Width, rc.Height));

        public static Point FromPixels(this SKCanvasView skCanvasView, Point pt)
        {
            double wf = skCanvasView.CanvasSize.Width / skCanvasView.Width;
            double hf = skCanvasView.CanvasSize.Height / skCanvasView.Height;
            return new Point(pt.X * wf, pt.Y * hf);
        }
    }
}
