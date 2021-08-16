using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNI_DESIGN_PROJECT0.ViewModels;
using RNI_DESIGN_PROJECT0.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RNI_DESIGN_PROJECT0.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DailyActivitiesPage : ContentPage
    {
        public DailyActivitiesPage()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            if (RNIConnectionObject.Logged_In == false) {
                BindingContext = new DailyActivitiesPageViewModel();
                RNIConnectionObject.Logged_In = true;
            }
 
        }
    }
}