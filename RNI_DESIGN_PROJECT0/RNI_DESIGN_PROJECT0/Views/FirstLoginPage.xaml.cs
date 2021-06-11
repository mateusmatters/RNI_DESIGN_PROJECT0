using RNI_DESIGN_PROJECT0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RNI_DESIGN_PROJECT0.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstLoginPage : ContentPage
    {
        public FirstLoginPage()
        {
            InitializeComponent();
            BindingContext = new FirstLoginPageViewModel();
        }
    }
}