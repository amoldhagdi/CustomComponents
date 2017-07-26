using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomComponents
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SetErrorFlag(object sender, EventArgs e)
        {
            editorControl.IsError = true;
            entryControl.IsError = true;
            sliderControl.IsError = true;
        }

        private void ReSetErrorFlag(object sender, EventArgs e)
        {
            editorControl.IsError = false;
            entryControl.IsError = false;
            sliderControl.IsError = false;
        }
    }
}
