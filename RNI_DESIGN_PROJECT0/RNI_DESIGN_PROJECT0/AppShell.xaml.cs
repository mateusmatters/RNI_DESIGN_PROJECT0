using RNI_DESIGN_PROJECT0.Views;
using System;
using Xamarin.Forms;

namespace RNI_DESIGN_PROJECT0
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ForgotPasswordPage), typeof(ForgotPasswordPage));
            Routing.RegisterRoute(nameof(CreateNewAccountPage), typeof(CreateNewAccountPage));
            Routing.RegisterRoute(nameof(MadeAccountPage), typeof(MadeAccountPage));
        }
    }
}
