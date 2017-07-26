using Android.Graphics;
using Android.Graphics.Drawables;
using CustomComponents.CustomRendor;
using CustomComponents.Droid.CustomRendor;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace CustomComponents.Droid.CustomRendor
{
    public class CustomEditorRenderer :EditorRenderer
    {
        ShapeDrawable shape { get; set; }
        global::Android.Widget.EditText nativeEditText { get; set; }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                nativeEditText = (global::Android.Widget.EditText)Control;
                shape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RectShape());
                var newElement = e.NewElement as CustomEditor;
                if (newElement != null)
                {
                    e.NewElement.Unfocused += (sender, evt) =>
                    {
                        shape.Paint.Color = Xamarin.Forms.Color.Gray.ToAndroid();
                    };

                    e.NewElement.Focused += (sender, evt) =>
                    {
                        newElement.IsError = false;
                        shape.Paint.Color = Xamarin.Forms.Color.Blue.ToAndroid();
                    };
                }
                Control.SetMinHeight(200);
                Control.SetPadding(5, 5, 5, 5);
                shape.Paint.Color = Xamarin.Forms.Color.Gray.ToAndroid();
                shape.Paint.SetStyle(Paint.Style.Stroke);
                nativeEditText.Background = shape;
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

            if (e.PropertyName == CustomEditor.IsErrorProperty.PropertyName)
            {
                SetBorderStyle(entry);
            }
        }

        void SetBorderStyle(CustomEditor entry)
        {
            if (entry.IsError == true)
            {
                shape.Paint.Color = Xamarin.Forms.Color.Red.ToAndroid();
                Control.SetBackgroundColor(Android.Graphics.Color.Red);
                nativeEditText.Background = shape;
            }
            else
            {
                shape.Paint.Color = Xamarin.Forms.Color.Gray.ToAndroid();
                Control.SetBackgroundColor(Android.Graphics.Color.Gray);
                nativeEditText.Background = shape;
            }
        }
    }
}