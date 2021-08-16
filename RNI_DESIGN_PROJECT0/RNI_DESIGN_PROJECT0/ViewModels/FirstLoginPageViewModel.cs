using RNI_DESIGN_PROJECT0.Views;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using RNI_DESIGN_PROJECT0.Models;


namespace RNI_DESIGN_PROJECT0.ViewModels
{
    public class FirstLoginPageViewModel : INotifyPropertyChanged
    {
        
        private string inputedEmail = "";
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
                int user_id = ConnectToRNIDatabase.get_user_id(InputedEmail,InputedPassword);
                RNIConnectionObject.create_connection_object(user_id);
                _ = SignInRoute();
            }
        }

        public void ForgotPasswordHelperAsync() {
            _ = ForgotPasswordRoute();
        }

        public void CreateNewAccountHelperAsync() {
            _ = CreateNewAccountRoute();
        }


        //These "//" marks are very important. Called relative or absolute routes. Learn more about them later. 
        async Task SignInRoute() {
            await Shell.Current.GoToAsync($"//{nameof(DailyActivitiesPage)}");
        }

        async Task ForgotPasswordRoute()
        {
            await Shell.Current.GoToAsync($"{nameof(ForgotPasswordPage)}");
        }

        async Task CreateNewAccountRoute()
        {
            await Shell.Current.GoToAsync($"{nameof(CreateNewAccountPage)}");
        }

        public string InputedEmail
        {
            get { return inputedEmail; }
            set { inputedEmail = value; OnPropertyChanged(nameof(InputedEmail)); }
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

        public bool ValidUserNameAndPassword()
        {
            return ConnectToRNIDatabase.Correct_Email_And_Password(inputedEmail , inputedPassword);

        }
    }
}