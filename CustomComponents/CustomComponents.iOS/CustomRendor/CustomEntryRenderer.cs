﻿using CoreGraphics;
using CustomComponents.CustomRendor;
using CustomComponents.iOS.CustomRendor;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace CustomComponents.iOS.CustomRendor
{

    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.TextColor = UIColor.Black;
                var newElement = e.NewElement as CustomEntry;
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
                Control.LeftView = new UIView(new CGRect(0, 0, 8, Control.Frame.Height));
                Control.RightView = new UIView(new CGRect(0, 0, 8, Control.Frame.Height));
                Control.LeftViewMode = UITextFieldViewMode.Always;
                Control.RightViewMode = UITextFieldViewMode.Always;
            }
        }
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null)
            {
                return;
            }

            var entry = (CustomEntry)Element;

            if (e.PropertyName == CustomEntry.IsErrorProperty.PropertyName)
            {
                SetBorderStyle(entry);
            }
        }
        void SetBorderStyle(CustomEntry entry)
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