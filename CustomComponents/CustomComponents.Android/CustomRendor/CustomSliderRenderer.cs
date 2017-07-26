using Android.Graphics;
using Android.Graphics.Drawables;
using CustomComponents.CustomRendor;
using CustomComponents.Droid.CustomRendor;
using Java.Lang;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

//https://blog.xamarin.com/customizing-xamarin-forms-controls-with-effects/

[assembly: ExportRenderer(typeof(CustomSlider), typeof(CustomSliderRenderer))]
namespace CustomComponents.Droid.CustomRendor
{
    public class CustomSliderRenderer : SliderRenderer
    { 
        global::Android.Widget.SeekBar nativeSlider { get; set; }
        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                nativeSlider = (global::Android.Widget.SeekBar)Control; 
                var newElement = e.NewElement as CustomSlider;

                if (newElement != null)
                {
                    //events                  
                }                
                Control.SetPadding(15, 0, 15, 0);                 
                nativeSlider.ProgressDrawable.SetColorFilter(new PorterDuffColorFilter(Xamarin.Forms.Color.Blue.ToAndroid(), PorterDuff.Mode.SrcIn));
                nativeSlider.Thumb.SetColorFilter(new PorterDuffColorFilter(Xamarin.Forms.Color.Blue.ToAndroid(), PorterDuff.Mode.SrcIn));
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null)
            {
                return;
            }

            var slider = (CustomSlider)Element;

            if (e.PropertyName == CustomSlider.IsErrorProperty.PropertyName)
            {
                SetBorderStyle(slider);
            }
        }

        void SetBorderStyle(CustomSlider slider)
        {
            if (slider.IsError == true)
            {
                nativeSlider.ProgressDrawable.SetColorFilter(new PorterDuffColorFilter(Xamarin.Forms.Color.Red.ToAndroid(), PorterDuff.Mode.SrcIn));
                nativeSlider.Thumb.SetColorFilter(new PorterDuffColorFilter(Xamarin.Forms.Color.Red.ToAndroid(), PorterDuff.Mode.SrcIn));               
            }
            else
            {
                nativeSlider.ProgressDrawable.SetColorFilter(new PorterDuffColorFilter(Xamarin.Forms.Color.Blue.ToAndroid(), PorterDuff.Mode.SrcIn));
                nativeSlider.Thumb.SetColorFilter(new PorterDuffColorFilter(Xamarin.Forms.Color.Blue.ToAndroid(), PorterDuff.Mode.SrcIn));               
            }
        }
    }
}