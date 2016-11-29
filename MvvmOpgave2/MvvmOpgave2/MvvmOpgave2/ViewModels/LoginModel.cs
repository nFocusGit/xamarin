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
        private string version = "v2.0";
        private string status = "Type your PIN...";
        private string pin = "";
        private bool loginButtonEnabled = false;

        public string VersionsText
        {
            get { return version; }
        }
        public string StatusText
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged();
                }
            }
        }
        public string PinText
        {
            get { return pin; }
            set
            {
                int n;
                var isNumeric = int.TryParse(value, out n);
                if (value != null)
                {
                    if (isNumeric)
                    {
                        if (pin != value)
                        {
                            pin = value;
                            OnPropertyChanged(); // implicit
                                                 // or OnPropertyChanged(); explicit:  The compiler sets thes string
                            if (String.IsNullOrEmpty(PinText) || String.IsNullOrWhiteSpace(PinText))
                            {
                                LoginButton = false;
                                StatusText = "Type your PIN...";
                            }
                            else
                            {
                                if (pin.Length == 8)
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
            get { return loginButtonEnabled; }
            set
            {
                if (loginButtonEnabled != value)
                {
                    loginButtonEnabled = value;
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
