using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using HelloWorld.CustomControls;
using HelloWorld.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientLayout), typeof(GradientLayoutRenderer))]
namespace HelloWorld.iOS.CustomRenderers
{
    public class GradientLayoutRenderer : VisualElementRenderer<StackLayout>
    {
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            GradientLayout layout = (GradientLayout)this.Element;
            CGColor startColor = layout.StartColor.ToCGColor();
            CGColor endColor = layout.EndColor.ToCGColor();

            var gradient = new CAGradientLayer()
            {
                StartPoint = new CGPoint(0, 0.5),
                EndPoint = new CGPoint(1, 0.5)
            };

            gradient.Frame = rect;
            gradient.Colors = new CGColor[] { startColor, endColor };
            NativeView.Layer.InsertSublayer(gradient, 0);
        }

    }
}