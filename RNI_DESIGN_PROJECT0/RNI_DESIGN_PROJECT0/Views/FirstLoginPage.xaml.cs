using RNI_DESIGN_PROJECT0.ViewModels;
using RNI_DESIGN_PROJECT0.Models;
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
        protected override void OnAppearing() {
            RNIConnectionObject.kill_connection_object();
            RNIConnectionObject.Logged_In = false;
        }
    }
}