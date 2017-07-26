using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomComponents.CustomRendor
{
    public class CustomEditor : Editor
    {
        public static readonly BindableProperty IsErrorProperty = BindableProperty.Create("IsError", typeof(bool), typeof(CustomEntry), false);

        public bool IsError
        {
            get { return (bool)GetValue(IsErrorProperty); }
            set { SetValue(IsErrorProperty, value); }
        }
        public CustomEditor()
        {
            
        }
    }
}
