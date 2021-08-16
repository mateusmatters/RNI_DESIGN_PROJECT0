using RNI_DESIGN_PROJECT0.Views;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using RNI_DESIGN_PROJECT0.Models;

namespace RNI_DESIGN_PROJECT0.ViewModels
{

    
    class CreateNewAccountPageViewModel: INotifyPropertyChanged
    {
        private string inputedUserName = "";
        private string inputedPassword = "";
        private string inputedEmail = "";
        private string inputedFirstName = "";
        private string inputedLastName = "";
        private string errorTextMessage = "";

        public CreateNewAccountPageViewModel()
        {
            CreateAccountClick = new Command(CreateAccountHelperAsync);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand CreateAccountClick { get; }

        public void CreateAccountHelperAsync()
        {
            if (ConnectToRNIDatabase.Create_New_Account(InputedFirstName,InputedLastName,InputedUserName,InputedEmail,InputedPassword)) {
                _ = SuccessfulAccountRoute();
            }
            else {
                ErrorTextMessage = "Error making your account";
            }
            
        }

        async Task SuccessfulAccountRoute()
        {
            await Shell.Current.GoToAsync($"{nameof(MadeAccountPage)}");
        }







        public string InputedFirstName
        {
            get { return inputedFirstName; }
            set { inputedFirstName = value; OnPropertyChanged(nameof(InputedFirstName)); }
        }
        public string InputedLastName
        {
            get { return inputedLastName; }
            set { inputedLastName = value; OnPropertyChanged(nameof(InputedLastName)); }
        }
        public string InputedUserName
        {
            get { return inputedUserName; }
            set { inputedUserName = value; OnPropertyChanged(nameof(InputedUserName)); }
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

        public string ErrorTextMessage
        {
            get { return errorTextMessage; }
            set { errorTextMessage = value; OnPropertyChanged(nameof(ErrorTextMessage)); }
        }
    }
}
