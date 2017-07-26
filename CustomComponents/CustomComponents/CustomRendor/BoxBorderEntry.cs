using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Trafigura.ITMS.App.CustomRendor
{
    public class BoxBorderEntry : Entry
    {
        /// <summary>
        /// Custom Property for Error only
        /// </summary>
        public static readonly BindableProperty IsErrorProperty = BindableProperty.Create("IsError", typeof(bool), typeof(BoxBorderEntry), false);

        public bool IsError
        {
            get { return (bool)GetValue(IsErrorProperty); }
            set { SetValue(IsErrorProperty, value); }
        }
        public BoxBorderEntry()
        {

        }
    }
}
