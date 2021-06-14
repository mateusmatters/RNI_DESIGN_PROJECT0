using RNI_DESIGN_PROJECT0.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RNI_DESIGN_PROJECT0.ViewModels
{
    public class FirstLoginPageViewModel : INotifyPropertyChanged
    {
        private string inputedUserName = "";
        private string inputedPassword = "";
        private string incorrectUsernamePasswordText = "";


        public FirstLoginPageViewModel() {
            SignInClick = new Command(SignInClickHelperAsync);
            ForgotPasswordClick = new Command(ForgotPasswordHelperAsync);
            CreateNewAccountClick = new Command(CreateNewAccountHelperAsync);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand SignInClick { get; }
        public ICommand ForgotPasswordClick { get; }
        public ICommand CreateNewAccountClick { get; }
        public void SignInClickHelperAsync() {
            if (!ValidUserNameAndPassword())
            {
                InputedPassword = "";
                IncorrectUsernamePasswordText = "Incorrect Username or Password";

            }
            else
            {
                _ = SignInRoute();
            }
        }

        public void ForgotPasswordHelperAsync() {
            _ = ForgotPasswordRoute();
        }

        public void CreateNewAccountHelperAsync() {
            _ = CreateNewAccountRoute();
        }

        async Task SignInRoute() {
            await Shell.Current.GoToAsync($"{nameof(DailyActivitiesPage)}");
        }

        async Task ForgotPasswordRoute()
        {
            await Shell.Current.GoToAsync($"{nameof(ForgotPasswordPage)}");
        }

        async Task CreateNewAccountRoute()
        {
            await Shell.Current.GoToAsync($"{nameof(CreateNewAccountPage)}");
        }

        public string InputedUserName
        {
            get { return inputedUserName; }
            set { inputedUserName = value; OnPropertyChanged(nameof(InputedUserName)); }
        }

        public string InputedPassword
        {
            get { return inputedPassword; }
            set { inputedPassword = value; OnPropertyChanged(nameof(InputedPassword)); }
        }

        public string IncorrectUsernamePasswordText
        { 
            get { return incorrectUsernamePasswordText; }
            set { incorrectUsernamePasswordText = value; OnPropertyChanged(nameof(IncorrectUsernamePasswordText)); }
        }

        public bool ValidUserNameAndPassword() //simple version for now, once app becomes more advanced have to change it
        {
            return inputedPassword != "" && inputedUserName != "";
        }
    }
}