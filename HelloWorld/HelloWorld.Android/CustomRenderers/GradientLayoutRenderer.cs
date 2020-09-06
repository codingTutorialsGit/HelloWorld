using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HelloWorld.CustomControls;
using HelloWorld.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.FastRenderers;

[assembly: ExportRenderer(typeof(GradientLayout), typeof(GradientLayoutRenderer))]
namespace HelloWorld.Droid.CustomRenderers
{
    public class GradientLayoutRenderer : VisualElementRenderer<StackLayout>
    {
        private Color StartColor { get; set; }
        private Color EndColor { get; set; }

        public GradientLayoutRenderer(Context context) : base(context)
        {
        }

        protected override void DispatchDraw(Android.Graphics.Canvas canvas)
        {

            var gradient = new Android.Graphics.LinearGradient(0, 0, Width, Height, this.StartColor.ToAndroid(), this.EndColor.ToAndroid(), Android.Graphics.Shader.TileMode.Mirror);

            var paint = new Android.Graphics.Paint()
            {
                Dither = true
            };

            paint.SetShader(gradient);
            canvas.DrawPaint(paint);

            base.DispatchDraw(canvas);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null) return;

            try
            {
                var layout = e.NewElement as GradientLayout;
                this.StartColor = layout.StartColor;
                this.EndColor = layout.EndColor;
            }
            catch (Exception ex) { }
        }
    }
}