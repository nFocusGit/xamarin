using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MvvmOpgave2.ViewModels
{
    public class LoginModel : INotifyPropertyChanged
    {
        private string versionsText = "v2.0";
        private string statusText = "Type your PIN...";
        private string pinText = "";
        private bool loginButton = false;

        public string VersionsText
        {
            get { return versionsText; }
        }
        public string StatusText
        {
            get { return statusText; }
            set
            {
                if (statusText != value)
                {
                    statusText = value;
                    OnPropertyChanged();
                }
            }
        }
        public string PinText
        {
            get { return pinText; }
            set
            {
                int n;
                var isNumeric = int.TryParse(value, out n);
                if (value != null)
                {
                    if (isNumeric)
                    {
                        if (pinText != value)
                        {
                            pinText = value;
                            OnPropertyChanged(); // implicit
                                                 // or OnPropertyChanged(); explicit:  The compiler sets thes string
                            if (String.IsNullOrEmpty(PinText) || String.IsNullOrWhiteSpace(PinText))
                            {
                                LoginButton = false;
                                StatusText = "Type your PIN...";
                            }
                            else
                            {
                                if (pinText.Length == 8)
                                {
                                    LoginButton = true;
                                }
                                else
                                {
                                    LoginButton = false;
                                }
                                StatusText = "PIN: " + PinText;
                            }
                        }
                    }
                    //else
                    //{
                    //    string s = value;
                    //    PinText = s.Remove(s.Length - 1);
                    //    OnPropertyChanged();
                    //}
                }
            }
        }
        public bool LoginButton
        {
            get { return loginButton; }
            set
            {
                if (loginButton != value)
                {
                    loginButton = value;
                    OnPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        // CallerMemberName is used to set propertyName if none...
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var myEvent = PropertyChanged;
            if (myEvent != null)
            {
                myEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
