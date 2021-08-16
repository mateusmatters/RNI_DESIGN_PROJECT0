using RNI_DESIGN_PROJECT0.Views;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using RNI_DESIGN_PROJECT0.Models;

namespace RNI_DESIGN_PROJECT0.ViewModels
{
    class DailyActivitiesPageViewModel : INotifyPropertyChanged
    {
        private string welcomeMessage = "Welcome back "  + RNIConnectionObject.current_user_first_name;
        public DailyActivitiesPageViewModel() {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string WelcomeMessage
        { 
            get { return welcomeMessage; }
            set { welcomeMessage = value; OnPropertyChanged(nameof(WelcomeMessage)); }
        }
    }
}
