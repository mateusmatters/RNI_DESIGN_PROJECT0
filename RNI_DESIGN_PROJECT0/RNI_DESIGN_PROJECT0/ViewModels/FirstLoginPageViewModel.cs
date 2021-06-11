using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RNI_DESIGN_PROJECT0.ViewModels
{
    public class FirstLoginPageViewModel : INotifyPropertyChanged
    {
        string inputedUserName = "";
        string inputedPassword = "";

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        // public FirstLoginPageViewModel() {
        // }

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
    }
}