using CoreGraphics;
using CustomComponents.CustomRendor;
using CustomComponents.iOS.CustomRendor;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace CustomComponents.iOS.CustomRendor
{
    public class CustomEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.TextColor = UIColor.Black;
                var newElement = e.NewElement as CustomEditor;
                e.NewElement.Unfocused += (sender, evt) =>
                {
                    Control.Layer.BorderColor = UIColor.Black.CGColor;
                };

                e.NewElement.Focused += (sender, evt) =>
                {
                    newElement.IsError = false;
                    Control.Layer.BorderColor = UIColor.Blue.CGColor;
                };

                Control.Layer.BorderColor = UIColor.Black.CGColor;
                Control.Layer.BorderWidth = 3.0f;
                Control.TextContainerInset = new UIEdgeInsets(5, 5, 5, 5); 
            }
        }
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null)
            {
                return;
            }

            var entry = (CustomEditor)Element;

            if (e.PropertyName == CustomEntry.IsErrorProperty.PropertyName)
            {
                SetBorderStyle(entry);
            }
        }
        void SetBorderStyle(CustomEditor entry)
        {
            if (entry.IsError == true)
            {
                Control.Layer.BorderColor = UIColor.Red.CGColor;
            }
            else
            {
                Control.Layer.BorderColor = UIColor.Black.CGColor;
            }
        }
    }
}