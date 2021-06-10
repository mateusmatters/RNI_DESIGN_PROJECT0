using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RNI_DESIGN_PROJECT0.ViewModels
{
    public class FirstLoginPageViewModel : BindableObject
    {
        string inputedUserName = "Bob";

        public FirstLoginPageViewModel() {
            UserEntry = new Command(OnUserEntry);
        }

        public string InputedUserName {
            get => inputedUserName;
            set {
                if (value == inputedUserName) {
                    return;
                }
                inputedUserName = value;
                OnPropertyChanged();
            }
        }

        public ICommand UserEntry;
        void OnUserEntry() {
            inputedUserName = "Bob";
        }
    }
}
