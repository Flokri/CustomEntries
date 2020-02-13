using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomEntries
{
    public partial class ValidationWaveEntry : FloatingLabelBase
    {
        #region instances
        private SKPaint _paint;

        private SKPath _path;

        Stopwatch stopwatch = new Stopwatch();
        #endregion

        public ValidationWaveEntry()
        {
            InitializeComponent();

            // create the paint for drawing
            _paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.Blue.ToSKColor(),
                IsAntialias = true,
                StrokeWidth = 5
            };

            AnimationLoop();
        }

        /// <summary>
        /// Get called when drawing is required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SkCanvasViewRequiredPainting(object sender, SKPaintSurfaceEventArgs e)
        {
            // get and clear the canvas
            SKCanvas canvas = e.Surface.Canvas;
            canvas.Clear();

            _path = _path ?? SetPath(0.0f);

            canvas.DrawPath(_path, _paint);
        }

        private SKPath SetPath(float plus)
        {
            var viewBounds = SkCanvasView.FromPixels(Bounds);
            var strokeWidth = (float)SkCanvasView.FromPixels(new Point(0, _paint.StrokeWidth)).Y;

            var path = new SKPath();

            path.MoveTo(
                x: (float)viewBounds.X,
                y: (float)viewBounds.Height - strokeWidth);

            path.LineTo(800, path.LastPoint.Y);

            path.QuadTo(new SKPoint(path.LastPoint.X + 30, path.LastPoint.Y - 30), new SKPoint(path.LastPoint.X + 60, path.LastPoint.Y));

            path.LineTo(path.LastPoint.X + 100, path.LastPoint.Y);

            return path;
        }

        async Task AnimationLoop()
        {
            stopwatch.Start();

            float test = 0.1f;
            while (true)
            {
                SetPath(test);
                SkCanvasView.InvalidateSurface();
                await Task.Delay(TimeSpan.FromSeconds(1.0 / 20));

                test += 1.4f;
            }

            stopwatch.Stop();
        }
    }
}